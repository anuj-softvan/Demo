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
        public InspectSchMeetingBll(IInspectSchMeetingRepo inspectSchMeetings)
        {
            _inspectSchMeetings = inspectSchMeetings;
        }

        public async Task<InspectSchMeetingDto> CreateAsync(CreateUpdateInspectSchMeetingDto input)
        {
            var result = ObjectMapper.Map<CreateUpdateInspectSchMeetingDto, InspectSchMeeting>(input);
            await _inspectSchMeetings.InsertAsync(result);
            return ObjectMapper.Map<InspectSchMeeting, InspectSchMeetingDto>(result);           
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
            existing_data.InsProjHeadID = input.InsProjHeadID;
            existing_data.MeetingDate = input.MeetingDate;
            existing_data.MeetingMode = input.MeetingMode;
            existing_data.MeetingStatus = input.MeetingStatus;
            existing_data.SlotEnd = input.SlotEnd;
            existing_data.SlotStart = input.SlotStart;           
            await _inspectSchMeetings.UpdateAsync(existing_data);
        }
    }
}
