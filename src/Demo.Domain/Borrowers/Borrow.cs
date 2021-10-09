using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Borrowers
{
    public class Borrow : AuditedAggregateRoot<Guid>
    {
        public Guid BookID { get; set; }
        public Guid StudentID { get; set; }
        public string Duration { get; set; }
        public float Price { get; set; }
    }
}
