using Demo.InspectMasterCategory;
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
    public class InspectMstCategoryController : ControllerBase
    {
        private readonly IInspectMstCategoryAfl _inspectMstCategoryAfl;
        public InspectMstCategoryController(IInspectMstCategoryAfl inspectMstCategoryAfl)
        {
            _inspectMstCategoryAfl = inspectMstCategoryAfl;
        }
        [HttpPost]
        [Route("createInspectMstCategory")]
        public async Task<IActionResult> CreateInspectMstCategroy(CreateUpdateInspectMstCategoryDto createUpdateInspectMstCategoryDto)
        {
            var data_Result = await _inspectMstCategoryAfl.CreateAsync(createUpdateInspectMstCategoryDto);
            return Ok(data_Result);
        }


        [HttpPut]
        [Route("updateInspectMstCategory")]
        public async Task<IActionResult> UpdateInspectMstCategory(int id, CreateUpdateInspectMstCategoryDto createUpdateInspectMstCategoryDto)
        {
            await _inspectMstCategoryAfl.UpdateAsync(id, createUpdateInspectMstCategoryDto);
            return Ok();
        }
    }
}
