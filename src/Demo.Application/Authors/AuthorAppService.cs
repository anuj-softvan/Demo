using Demo.Books;
using Demo.Permissions;
using Demo.Students;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Application.Services;
using Demo.Borrowers;

namespace Demo.Authors
{
    //[Authorize(DemoPermissions.Authors.Default)]
    public class AuthorAppService : DemoAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Borrow, Guid> _borrowRepository;
        public AuthorAppService(
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
            IRepository<Student, Guid> studentRepository,
            IRepository<Book, Guid> bookRepository,
             IRepository<Borrow, Guid> borrowRepository
           )
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _studentRepository = studentRepository;
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;

        }
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(input.Name, input.BirthDate, input.ShortBio);

            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
        //[Authorize(DemoPermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<EntityListDto>> GetAsync(Guid id)
        {
            var book_data = await _bookRepository.GetQueryableAsync();
            var query = (from book in book_data
                        join author in _authorRepository on book.AuthorId equals author.Id
                        join student in _studentRepository on book.Id equals student.BookId
                        join borrowers in _borrowRepository on book.Id equals borrowers.BookID
                        where author.Id == id
                        select new EntityListDto()
                        {                            
                            Student_Name = student.Name,
                            Author_Name = author.Name,
                            Name = book.Name,
                            Duration = borrowers.Duration,
                            Price = book.Price
                        }).ToList();
            return query;

        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var totalCount = input.Filter == null ? await _authorRepository.CountAsync() : await _authorRepository.CountAsync(
            author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(totalCount, ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));
        }

        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var existing_author = await _authorRepository.GetAsync(id);

            if (existing_author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(existing_author, input.Name);
            }
            existing_author.BirthDate = input.BirthDate;
            existing_author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(existing_author);
        }
    }
}
