using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.MeetingInspector
{
    public class CreateUpdateMeetingDto
    {
        public Guid InspectorId { get; set; }
        [Required]
        public int MeetingId { get; set; }
        public string Name { get; set; }
    }
}
