using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.MeetingParticipent
{
    public class CreateMeetingParticipentDto
    {
        public Guid ParticipentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
