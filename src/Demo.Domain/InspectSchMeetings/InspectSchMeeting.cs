using Demo.InspectMasterCategory;
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
        public ICollection<InspectSchAssignStaff> InspectSchAssignStaffs { get; set; }

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

    public class InspectSchAssignStaff: FullAuditedAggregateRoot<int>
    {
        public Guid StaffID { get; set; }
        public byte IsAccepted { get; set; }
        public DateTime AcceptedOn { get; set; }
        public string AcceptRemarks { get; set; }
        public int InspectSchID { get; set; }
        public InspectSchMeeting InspectSchMeeting { get; set; }

    }

    public class InspectAppCategory : FullAuditedAggregateRoot<int>
    {
        public int InsProjHeadID { get; set; }
        public int PermitID { get; set; }
        public int InsMstCatID { get; set; }
        public InspectProjHead InspectProjHead { get; set; }
        public InspectMstCategory InspectMstCategory { get; set; }
    }
}
