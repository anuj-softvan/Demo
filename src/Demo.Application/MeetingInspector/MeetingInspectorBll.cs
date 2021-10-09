using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.MeetingInspector
{
    public class MeetingInspectorBll : DemoAppService, IMeetingInspectorAfl
    {
        private readonly IMeetingInspectorRepo _meetingInspectorsrepo;
        public MeetingInspectorBll(IMeetingInspectorRepo meetingInspectorsrepo)
        {
            _meetingInspectorsrepo = meetingInspectorsrepo;
        }

        public async Task<MeetingInspectorDto> CreateAsync(CreateUpdateMeetingDto input)
        {

            //var meeting_inspector = new MeetingInspectors(
            // GuidGenerator.Create(),
            // input.Name,
            // input.InspectorId,
            // input.MeetingId);
            var result = ObjectMapper.Map<CreateUpdateMeetingDto, MeetingInspectors>(input);
            await _meetingInspectorsrepo.InsertAsync(result);
            return ObjectMapper.Map<MeetingInspectors, MeetingInspectorDto>(result);

        }

        public async Task DeleteAsync(int id)
        {
            await _meetingInspectorsrepo.DeleteAsync(id);
        }

        public async Task<MeetingInspectorDto> GetAsync(int id)
        {
            var meeting_Insprector_Data = await _meetingInspectorsrepo.GetAsync(id);
            return ObjectMapper.Map<MeetingInspectors, MeetingInspectorDto>(meeting_Insprector_Data);
        }

        public async Task UpdateAsync(int id, CreateUpdateMeetingDto input)
        {
            var existing_data = await _meetingInspectorsrepo.GetAsync(id);

            existing_data.Name = input.Name;
            existing_data.InspectorId = input.InspectorId;
            existing_data.MeetingId = input.MeetingId;
            await _meetingInspectorsrepo.UpdateAsync(existing_data);

        }
    }
}
