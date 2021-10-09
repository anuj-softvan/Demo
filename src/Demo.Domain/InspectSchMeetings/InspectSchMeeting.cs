using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeeting : FullAuditedAggregateRoot<int>
    {
        public int InsProjHeadID { get; set; }
        public byte MeetingMode { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte MeetingStatus { get; set; }
    }
}
