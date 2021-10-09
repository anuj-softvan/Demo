using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demo.Students
{
    public class StudentDto : AuditedEntityDto<Guid>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public Guid? BookId { get; set; }
    }
}
