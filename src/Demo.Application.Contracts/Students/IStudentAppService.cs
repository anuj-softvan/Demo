using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo.Students
{
    public interface IStudentAppService : IApplicationService
    {
        Task<StudentDto> GetAsync(Guid id);

        Task<PagedResultDto<StudentDto>> GetListAsync(GetStudentListDto input);

        Task<StudentDto> CreateAsync(CreateUpdateStudentDto input);

        Task UpdateAsync(Guid id, CreateUpdateStudentDto input);

        Task DeleteAsync(Guid id);
    }
}
