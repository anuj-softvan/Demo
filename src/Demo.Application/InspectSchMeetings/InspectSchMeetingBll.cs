using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeetingBll : DemoAppService,IInspectSchMeetingAfl
    {
        private readonly IInspectSchMeetingRepo _inspectSchMeetings;
        private readonly IInspectProjHeadRepo _inspectProjHeads;
        public InspectSchMeetingBll(IInspectSchMeetingRepo inspectSchMeetings, IInspectProjHeadRepo inspectProjHeads)
        {
            _inspectSchMeetings = inspectSchMeetings;
            _inspectProjHeads = inspectProjHeads;
        }

        public async Task<InspectSchMeetingDto> CreateAsync(int InsProjHeadID,CreateUpdateInspectSchMeetingDto input)
        {
            InspectSchMeeting inspectSchMeetings;
            var insProjectHead = await _inspectProjHeads.GetAsync(InsProjHeadID);
            if (input.Id > 0)
            {
                var result = await _inspectSchMeetings.WithDetailsAsync(x => x.InspectSchVirtualMeetInfo);
                var data  = result.FirstOrDefault(x => x.Id == input.Id);
                inspectSchMeetings = ObjectMapper.Map(input,data);
                inspectSchMeetings.InsProjHeadID = InsProjHeadID;
                if (input.MeetingMode == MeetingType.AR_VR || input.MeetingMode == MeetingType.Video)
                {
                    inspectSchMeetings.InspectSchVirtualMeetInfo.VirtualMeetApp = VirtualMeetApp.Zoom;
                }
                await _inspectSchMeetings.UpdateAsync(inspectSchMeetings);
            }
            else
            {
                inspectSchMeetings = ObjectMapper.Map<CreateUpdateInspectSchMeetingDto, InspectSchMeeting>(input);
                inspectSchMeetings.InsProjHeadID = InsProjHeadID;
                if (input.MeetingMode == MeetingType.AR_VR || input.MeetingMode == MeetingType.Video)
                {
                    InspectSchVirtualMeetInfo inspectSchVirtualMeetInfo = new InspectSchVirtualMeetInfo();
                    inspectSchVirtualMeetInfo.VirtualMeetApp = 0;
                    inspectSchMeetings.InspectSchVirtualMeetInfo = inspectSchVirtualMeetInfo;
                }
                await _inspectSchMeetings.InsertAsync(inspectSchMeetings);
            }                                                                    
            return ObjectMapper.Map<InspectSchMeeting, InspectSchMeetingDto>(inspectSchMeetings);           
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
    }
}
