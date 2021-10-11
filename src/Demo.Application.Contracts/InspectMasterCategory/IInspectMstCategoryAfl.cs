using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Demo.InspectMasterCategory
{
    public interface IInspectMstCategoryAfl : IApplicationService
    {
        Task<InspectMstCategoryDto> CreateAsync(CreateUpdateInspectMstCategoryDto input);

        Task UpdateAsync(int id, CreateUpdateInspectMstCategoryDto input);
    }
}
