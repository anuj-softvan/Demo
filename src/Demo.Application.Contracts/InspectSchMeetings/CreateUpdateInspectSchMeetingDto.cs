using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InspectSchMeetings
{
    public class CreateUpdateInspectSchMeetingDto
    {
       // public int InsProjHeadID { get; set; }
        public int Id { get; set; }
        public MeetingType MeetingMode { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte MeetingStatus { get; set; }       
    }
}
