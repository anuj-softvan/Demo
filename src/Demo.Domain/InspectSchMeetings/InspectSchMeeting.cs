using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeeting : FullAuditedAggregateRoot<int>
    {
       
        public MeetingType MeetingMode { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte MeetingStatus { get; set; }       
        public int? InsProjHeadID { get; set; }       
        public InspectProjHead InspectProjHead { get; set; }
        public InspectSchVirtualMeetInfo InspectSchVirtualMeetInfo { get; set; }

    }
    public class InspectProjHead : FullAuditedAggregateRoot<int>
    {
        public int OrgID { get; set; }
        public int ProjectID { get; set; }
        public string InspectSeqNum { get; set; }
        public byte Status { get; set; }
        public InspectSchMeeting InspectSchMeeting { get; set; }

    }
    public class InspectSchVirtualMeetInfo : FullAuditedAggregateRoot<int>
    {
        public int InspectSchID { get; set; }
        public VirtualMeetApp VirtualMeetApp { get; set; }
        public string MeetingLink { get; set; }
        public InspectSchMeeting InspectSchMeeting { get; set; }

    }
}
