using Demo.CivitMeetings;
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
    public class CivitMeetingController : ControllerBase
    {
        private readonly ICivitMeetingAfl _civitMeetingAfl;

        public CivitMeetingController(ICivitMeetingAfl civitMeetingAfl)
        {
            _civitMeetingAfl = civitMeetingAfl;
        }

        [HttpPost]
        [Route("createCivitMeeting")]
        public async Task<IActionResult> createCivitMeeting(CreateCivitMeetingDto createCivitMeetingDto)
        {
            var data_Result = await _civitMeetingAfl.CreateAsync(createCivitMeetingDto);
            return Ok(data_Result);
        }
    }
}
