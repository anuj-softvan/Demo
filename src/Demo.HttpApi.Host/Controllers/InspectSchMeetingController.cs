using Demo.InspectSchMeetings;
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
    public class InspectSchMeetingController : ControllerBase
    {
        private readonly IInspectSchMeetingAfl _inspectSchMeetingAfl;
        public InspectSchMeetingController(IInspectSchMeetingAfl inspectSchMeetingAfl)
        {
            _inspectSchMeetingAfl = inspectSchMeetingAfl;
        }

        [HttpGet]
        [Route("getInspectSchMeeting/{id}")]
        public async Task<IActionResult> getInspectMeetingDetail(int id)
        {
            var data_result = await _inspectSchMeetingAfl.GetAsync(id);
            return Ok(data_result);
        }
        [HttpPost]
        [Route("createInspectSchMeeting")]
        public async Task<IActionResult> CreateInspectSchMeeting(int InsProjHeadID,CreateUpdateInspectSchMeetingDto createUpdateInspectSchMeetingDto)
        {
            var data_Result = await _inspectSchMeetingAfl.CreateAsync(InsProjHeadID,createUpdateInspectSchMeetingDto);
            return Ok(data_Result);
        }


        [HttpPut]
        [Route("updateInspectSchMeeting")]
        public async Task<IActionResult> UpdateInspectSchMeeing(int id, CreateUpdateInspectSchMeetingDto createUpdateInspectSchMeetingDto)
        {
            await _inspectSchMeetingAfl.UpdateAsync(id, createUpdateInspectSchMeetingDto);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteInspectSchMeeting")]
        public async Task<IActionResult> DeleteInspectSchMeeting(int id)
        {
            await _inspectSchMeetingAfl.DeleteAsync(id);
            return Ok();
        }


    }
}
