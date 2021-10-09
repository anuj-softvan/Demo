using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CivitMeetings
{
    public class CivitMeetingDto
    {
        public int OrgID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public byte MeetingMode { get; set; }
        public string Meetinginvitation { get; set; }
        public DateTime SlotDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte ScheduleStatus { get; set; }
        public byte Compliancestatus { get; set; }
        public bool IsCanceled { get; set; }
        public Guid CanceledById { get; set; }
        public DateTime CanceledOn { get; set; }
        public string CancelationReason { get; set; }
    }
}
