using Demo.Authors;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }
        [HttpGet]
        [Route("recordlist/{id}")]
        public IActionResult getAllBookDetails(Guid id)
        {
            var data_result = _authorAppService.GetAsync(id);
            return Ok(data_result);
        }

        [HttpGet]
        [Route("authorlist")]
        public async Task<IActionResult> getAllAuthors(GetAuthorListDto input)
        {
            var data_result =await _authorAppService.GetListAsync(input);
            //return data_result;
            //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data_result));
            return Ok(data_result);
        }

        [HttpPost]
        [Route("createauthor")]
        public async Task<IActionResult> createAuthor(CreateAuthorDto createAuthorDto)
        {
            var data_Result = await _authorAppService.CreateAsync(createAuthorDto);
            return Ok(data_Result);
        }


        [HttpPut]
        [Route("updateauthor")]
        public async Task<IActionResult> updateAuthor(Guid id,UpdateAuthorDto updateAuthorDto)
        {
            await _authorAppService.UpdateAsync(id,updateAuthorDto);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteauthor")]
        public async Task<IActionResult> deleteAuthor(Guid id)
        {
            await _authorAppService.DeleteAsync(id);
            return Ok();
        }


    }
}
