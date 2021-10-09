using Demo.Students;
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
    public class StudentController : ControllerBase
    {

        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }
        [HttpGet]
        [Route("getstudent/{id}")]
        public async Task<IActionResult> getStudewntDetail(Guid id)
        {
            var data_result = await _studentAppService.GetAsync(id);
            return Ok(data_result);
        }

        [HttpGet]
        [Route("studentlist")]
        public async Task<IActionResult> getAllStudents(GetStudentListDto input)
        {
            var data_result = await _studentAppService.GetListAsync(input);
            //return data_result;
            //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data_result));
            return Ok(data_result);
        }

        [HttpPost]
        [Route("createstudent")]
        public async Task<IActionResult> createStudent(CreateUpdateStudentDto createStudentDto)
        {
            var data_Result = await _studentAppService.CreateAsync(createStudentDto);
            return Ok(data_Result);
        }


        [HttpPut]
        [Route("updatestudent")]
        public async Task<IActionResult> updateStudent(Guid id, CreateUpdateStudentDto updateStudentDto)
        {
            await _studentAppService.UpdateAsync(id, updateStudentDto);
            return Ok();
        }

        [HttpDelete]
        [Route("deletestudent")]
        public async Task<IActionResult> deleteStudent(Guid id)
        {
            await _studentAppService.DeleteAsync(id);
            return Ok();
        }
    }
}
