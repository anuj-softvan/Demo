using Demo.MeetingInspector;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingInspectorController : ControllerBase
    {
        private readonly IMeetingInspectorAfl _meetingInspectorservice;

        public MeetingInspectorController(IMeetingInspectorAfl meetingInspectorservice)
        {
            _meetingInspectorservice = meetingInspectorservice;
        }
        [HttpGet]
        [Route("getMeetingInspector/{id}")]
        public async Task<IActionResult> getMeetingInspectorDetail(int id)
        {
            var data_result = await _meetingInspectorservice.GetAsync(id);
            return Ok(data_result);
        }

        [HttpPost]
        [Route("createMeetingInspector")]
        public async Task<IActionResult> createMeetingInspector(CreateUpdateMeetingDto createStudentDto)
        {
            var data_Result = await _meetingInspectorservice.CreateAsync(createStudentDto);
            return Ok(data_Result);
        }


        [HttpPut]
        [Route("updateMeetingInspector")]
        public async Task<IActionResult> updateMeetingInspector(int id, CreateUpdateMeetingDto updateStudentDto)
        {
            await _meetingInspectorservice.UpdateAsync(id, updateStudentDto);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteMeetingInspector")]
        public async Task<IActionResult> deleteMeetingInspector(int id)
        {
            await _meetingInspectorservice.DeleteAsync(id);
            return Ok();
        }
    }
}
