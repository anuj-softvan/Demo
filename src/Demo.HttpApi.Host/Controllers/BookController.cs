using Demo.Books;
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
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        [HttpGet]
        [Route("getbook/{id}")]
        public async Task<IActionResult> getBookDetail(Guid id)
        {
            var data_result = await _bookAppService.GetAsync(id);
            return Ok(data_result);
        }

        [HttpGet]
        [Route("booklist")]
        public async Task<IActionResult> getAllStudents(GetBookListDto input)
        {
            var data_result = await _bookAppService.GetListAsync(input);
            //return data_result;
            //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data_result));
            return Ok(data_result);
        }

        [HttpPost]
        [Route("createbook")]
        public async Task<IActionResult> createStudent(CreateUpdateBookDto createUpdateBookDto)
        {
            var data_Result = await _bookAppService.CreateAsync(createUpdateBookDto);
            return Ok(data_Result);
        }


        [HttpPut]
        [Route("updatebook")]
        public async Task<IActionResult> updateStudent(Guid id, CreateUpdateBookDto createUpdateBookDto)
        {
            await _bookAppService.UpdateAsync(id, createUpdateBookDto);
            return Ok();
        }

        [HttpDelete]
        [Route("deletebook")]
        public async Task<IActionResult> deleteStudent(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
            return Ok();
        }
    }
}
