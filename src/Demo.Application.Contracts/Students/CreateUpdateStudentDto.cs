using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Students
{
    public class CreateUpdateStudentDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public int Class { get; set; }
        public Guid? BookId { get; set; }
    }
}
