using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();

        Task<BookDto> GetAsync(Guid id);

        Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input);

        Task<BookDto> CreateAsync(CreateUpdateBookDto input);

        Task UpdateAsync(Guid id, CreateUpdateBookDto input);

        Task DeleteAsync(Guid id);
    }
}
