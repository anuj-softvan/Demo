using Demo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.Books
{
    public class BookRepository : EfCoreRepository<DemoDbContext, Book, Guid>,
            IBookRepository
    {


        public BookRepository(
          IDbContextProvider<DemoDbContext> dbContextProvider)
          : base(dbContextProvider)
        {
        }
    }
}
