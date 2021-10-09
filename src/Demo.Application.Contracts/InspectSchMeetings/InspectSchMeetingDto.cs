using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeetingDto
    {
        public int InsProjHeadID { get; set; }
        public byte MeetingMode { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte MeetingStatus { get; set; }
    }
}
