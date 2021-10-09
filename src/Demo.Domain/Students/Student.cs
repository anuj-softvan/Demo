using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Students
{
    public class Student : AuditedAggregateRoot<Guid>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public Guid? BookId { get; set; }


        public Student(Guid id,
          string email,
          string name,
          int Class,
          Guid? bookId)
          : base(id)
        {
            Email = email;
            Name = name;
            this.Class = Class;
            BookId = bookId;
        }
    }

    
}
