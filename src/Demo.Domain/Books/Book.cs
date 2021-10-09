using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public Guid AuthorId { get; set; }


        public Book(Guid id,
           string name,
           BookType type,
           DateTime publishDate,
           float price,
           Guid authorId)
           : base(id)
        {

            Name = name;
            Type = type;
            PublishDate = publishDate;
            Price = price;
            AuthorId = authorId;
        }
    }
}
