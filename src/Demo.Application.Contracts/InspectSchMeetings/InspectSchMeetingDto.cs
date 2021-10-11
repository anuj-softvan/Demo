using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeetingDto
    {
        public int InsProjHeadID { get; set; }
        public MeetingType MeetingMode { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte MeetingStatus { get; set; }
    }
    public class InspectSchVirtualMeetInfoDto 
    {
        public int InspectSchID { get; set; }
        public VirtualMeetApp VirtualMeetApp { get; set; }
        public string MeetingLink { get; set; }       
    }
}
