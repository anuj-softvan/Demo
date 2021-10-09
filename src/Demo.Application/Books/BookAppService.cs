using Demo.Authors;
using Demo.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Demo.Books
{
    public class BookAppService : DemoAppService, IBookAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookrepository;
        public BookAppService(
            IBookRepository bookrepository,
            IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _bookrepository = bookrepository;
            //GetPolicyName = DemoPermissions.Books.Default;
            //GetListPolicyName = DemoPermissions.Books.Default;
            //CreatePolicyName = DemoPermissions.Books.Create;
            //UpdatePolicyName = DemoPermissions.Books.Edit;
            //DeletePolicyName = DemoPermissions.Books.Create;
        }

        public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
        {
            var book = new Book(
                GuidGenerator.Create(),
                input.Name,
                input.Type,
                input.PublishDate,
                input.Price,
                input.AuthorId);
            try
            {
                await _bookrepository.InsertAsync(book);  
            }catch(Exception ex)
            {
                return new BookDto();
            }

            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await _bookrepository.GetQueryableAsync();
            //Prepare a query to join books and authors
            var query = from book in queryable
                        join author in _authorRepository on book.AuthorId equals author.Id
                        where book.Id == id
                        select new { book, author };
            //Execute the query and get the book with author
            var result = await AsyncExecuter.FirstOrDefaultAsync(query);
            if(result == null)
            {
                throw new EntityNotFoundException(typeof(Book), id);
            }
            var bookdto = ObjectMapper.Map<Book, BookDto>(result.book);
            bookdto.AuthorName = result.author.Name;
            return bookdto;
        }
        public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        {
            var queryable = await _bookrepository.GetQueryableAsync();

            var query = from book in queryable
                        join author in _authorRepository on book.AuthorId equals author.Id
                        select new { book, author };

            query = query.Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var result = await AsyncExecuter.ToListAsync(query);

            // convert query result to a list of bookdto object
            var bookdtos = result.Select(x =>
            {
                var bookdto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookdto.AuthorName = x.author.Name;
                return bookdto;
            }).ToList();

            var totalCount = await _bookrepository.GetCountAsync();

            return new PagedResultDto<BookDto>(totalCount, bookdtos);

        }
        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authors = await _authorRepository.GetListAsync();

            return new ListResultDto<AuthorLookupDto>(
                ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
            );
        }

        public async Task UpdateAsync(Guid id,CreateUpdateBookDto input)
        {
            var existing_book = await _bookrepository.GetAsync(id);
            if (existing_book != null)
            {
                existing_book.Name = input.Name;
                existing_book.Type = input.Type;
                existing_book.PublishDate = input.PublishDate;
                existing_book.Price = input.Price;
                await _bookrepository.UpdateAsync(existing_book);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            await _bookrepository.DeleteAsync(id);
        }
    }
}
