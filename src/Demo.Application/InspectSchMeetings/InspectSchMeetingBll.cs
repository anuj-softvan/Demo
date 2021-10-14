using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeetingBll : DemoAppService, IInspectSchMeetingAfl
    {
        private readonly IInspectSchMeetingRepo _inspectSchMeetings;
        private readonly IInspectProjHeadRepo _inspectProjHeads;
        private readonly IInspectSchAssignStaffRepo _inspectSchAssignStaffs;
        public InspectSchMeetingBll(IInspectSchMeetingRepo inspectSchMeetings, IInspectProjHeadRepo inspectProjHeads, IInspectSchAssignStaffRepo inspectSchAssignStaffs)
        {
            _inspectSchMeetings = inspectSchMeetings;
            _inspectProjHeads = inspectProjHeads;
            _inspectSchAssignStaffs = inspectSchAssignStaffs;
        }

        public async Task<InspectSchMeetingDto> CreateAsync(int InsProjHeadID, CreateUpdateInspectSchMeetingDto input)
        {
            var insProjectHead = (await _inspectProjHeads.WithDetailsAsync(x => x.InspectSchMeeting, x => x.InspectSchMeeting.InspectSchVirtualMeetInfo)).FirstOrDefault(x => x.Id == InsProjHeadID);
            InspectSchMeeting inspectSchMeeting;
            if (input.Id > 0)
            {
                if (insProjectHead.InspectSchMeeting.Id != input.Id)
                {
                    throw new UserFriendlyException("");
                }

                ObjectMapper.Map(input, insProjectHead.InspectSchMeeting);
                inspectSchMeeting = insProjectHead.InspectSchMeeting;

            }
            else
            {
                inspectSchMeeting = ObjectMapper.Map<CreateUpdateInspectSchMeetingDto, InspectSchMeeting>(input);
                if (input.MeetingMode == MeetingType.AR_VR || input.MeetingMode == MeetingType.Video)
                {
                    InspectSchVirtualMeetInfo inspectSchVirtualMeetInfo = new InspectSchVirtualMeetInfo();
                    inspectSchVirtualMeetInfo.VirtualMeetApp = 0;
                    inspectSchMeeting.InspectSchVirtualMeetInfo = inspectSchVirtualMeetInfo;
                }
                inspectSchMeeting.InspectSchAssignStaffs = new List<InspectSchAssignStaff>()
                {
                    new InspectSchAssignStaff()
                    {
                        StaffID = GuidGenerator.Create(),
                        IsAccepted = 0,
                        AcceptedOn = DateTime.Now,
                        AcceptRemarks = "",
                    }
                };

                insProjectHead.InspectSchMeeting = inspectSchMeeting;
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<InspectSchMeeting, InspectSchMeetingDto>(inspectSchMeeting);
        }

        public async Task DeleteAsync(int id)
        {
            await _inspectSchMeetings.DeleteAsync(id);
        }

        public async Task<InspectSchMeetingDto> GetAsync(int id)
        {
            var meeting_Inspect_Data = await _inspectSchMeetings.GetAsync(id);
            return ObjectMapper.Map<InspectSchMeeting, InspectSchMeetingDto>(meeting_Inspect_Data);
        }

        public async Task UpdateAsync(int id, CreateUpdateInspectSchMeetingDto input)
        {
            var existing_data = await _inspectSchMeetings.GetAsync(id);
            //existing_data.InsProjHeadID = input.InsProjHeadID;
            existing_data.MeetingDate = input.MeetingDate;
            existing_data.MeetingMode = input.MeetingMode;
            existing_data.MeetingStatus = input.MeetingStatus;
            existing_data.SlotEnd = input.SlotEnd;
            existing_data.SlotStart = input.SlotStart;
            await _inspectSchMeetings.UpdateAsync(existing_data);
        }



        public async Task<List<DateTime>> GetFullSlotDateList(Guid StaffID)
        {
            TimeSpan Morningstart = new TimeSpan(9, 0, 0); //9:00 AM
            TimeSpan Morningend = new TimeSpan(12, 0, 0); //12:00 PM
            TimeSpan Eveningstart = new TimeSpan(15, 0, 0); //3:00 PM
            TimeSpan Eveningend = new TimeSpan(18, 0, 0); //6:00 PM
            
            var SlotFullDates = (await _inspectSchAssignStaffs.WithDetailsAsync(x => x.InspectSchMeeting)).Where(x => x.StaffID == StaffID).Select(c => c.InspectSchMeeting).Where(x => (x.SlotStart.TimeOfDay == Eveningstart && x.SlotEnd.TimeOfDay == Eveningend) || (x.SlotStart.TimeOfDay == Morningstart && x.SlotEnd.TimeOfDay == Morningend))
                .GroupBy(x=>x.MeetingDate.Date)
                .Where(z=>z.Count()==2)
                .Select(z=>z.Key).ToList();            
                        
            return SlotFullDates;
        }

        public async Task<InspectSchAssignStaffDto> CreateInspectAssignStaff(int InspectSchID, CreateInspectSchAssignStaffDto createInspectSchAssignStaffDto)
        {
            var inspectSchMeeting = (await _inspectSchMeetings.WithDetailsAsync(x => x.InspectSchAssignStaffs)).FirstOrDefault(x => x.Id == InspectSchID);
            var inpectAssignStaff = ObjectMapper.Map<CreateInspectSchAssignStaffDto, InspectSchAssignStaff>(createInspectSchAssignStaffDto);
            if (inspectSchMeeting.InspectSchAssignStaffs.Any(x => x.StaffID == createInspectSchAssignStaffDto.StaffID && x.InspectSchID == InspectSchID))
            {
                throw new UserFriendlyException("");
            }
            else
            {
                inspectSchMeeting.InspectSchAssignStaffs.Add(inpectAssignStaff);
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<InspectSchAssignStaff, InspectSchAssignStaffDto>(inpectAssignStaff);

        }
    }
}
