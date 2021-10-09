using Demo.Authors;
using Demo.Books;
using Demo.Borrowers;
using Demo.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Demo
{
    public class DemoDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Borrow, Guid> _borrowRepository;
        private readonly AuthorManager _authorManager;

        public DemoDataSeederContributor(IRepository<Book, Guid> bookRepository, IAuthorRepository authorRepository,
            AuthorManager authorManager, IRepository<Student, Guid> studentRepository, IRepository<Borrow, Guid> borrowRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _studentRepository = studentRepository;
            _borrowRepository = borrowRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            //if (await _bookRepository.GetCountAsync() <= 0)
            //{
            //    await _bookRepository.InsertAsync(
            //        new Book
            //        {
            //            Name = "1984",
            //            Type = BookType.Dystopia,
            //            PublishDate = new DateTime(1949, 6, 8),
            //            Price = 19.84f
            //        },
            //        autoSave: true
            //    );

            //    await _bookRepository.InsertAsync(
            //        new Book
            //        {
            //            Name = "The Hitchhiker's Guide to the Galaxy",
            //            Type = BookType.ScienceFiction,
            //            PublishDate = new DateTime(1995, 9, 27),
            //            Price = 42.0f
            //        },
            //        autoSave: true
            //    );
            //}
            if (await _authorRepository.GetCountAsync() <= 0)
            {
                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "George Orwell",
                        new DateTime(1903, 06, 25),
                        "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                    )
                );

                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "Douglas Adams",
                        new DateTime(1952, 03, 11),
                        "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                    )
                );
            }
            //if (await _studentRepository.GetCountAsync() <= 0)
            //{
            //    await _studentRepository.InsertAsync(
            //        new Student
            //        {
            //            Name = "Jay",
            //            Email = "jay.patel@gmail.com",
            //            Class = 12

            //        },
            //        autoSave: true
            //    );

            //    await _studentRepository.InsertAsync(
            //        new Student
            //        {
            //            Name = "Jayshil",
            //            Email = "jayshil.shah@gmail.com",
            //            Class = 12
            //        },
            //        autoSave: true
            //    );
            //}
            //if (await _bookRepository.GetCountAsync() <= 0)
            //{
            //    await _bookRepository.InsertAsync(
            //        new Book
            //        {
            //            Name = "Tech Book",
            //            Type = BookType.Dystopia,
            //            PublishDate = new DateTime(1949, 6, 8),
            //            Price = 19.84f
            //        },
            //        autoSave: true
            //    );


            //}

            //if (await _borrowRepository.GetCountAsync() <= 0)
            //{
            //    await _borrowRepository.InsertAsync(
            //        new Borrow
            //        {
            //     BookID = Guid.NewGuid(),
            //            StudentID = 6c483c9e - 70e1 - ab80 - 4b5a - 39ff4c82df16,
            //     Duration = "Jab-2020 to March-2020",
            //     Price = 150

            //        },
            //        autoSave: true
            //    );

            //    await _borrowRepository.InsertAsync(
            //        new Borrow
            //        {
            //            BookID = Guid.NewGuid(),
            //            StudentID = Guid.NewGuid(),
            //            Duration = "Jab-2020 to March-2020",
            //            Price = 150

            //        },
            //        autoSave: true
            //    );
            //}
        }
    }
}
