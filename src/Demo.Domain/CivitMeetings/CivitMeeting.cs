using Demo.MeetingParticipent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.CivitMeetings
{
    public class CivitMeeting : FullAuditedAggregateRoot<int>
    {
        public CivitMeeting()
        {
            MeetingParticipents = new HashSet<MeetingParticipents>();
        }
        public int OrgID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public byte MeetingMode { get; set; }
        [Column(TypeName = "ntext")]
        public string Meetinginvitation { get; set; }
        public DateTime SlotDate { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public byte ScheduleStatus { get; set; }
        public byte Compliancestatus { get; set; }
        public bool IsCanceled { get; set; }
        public Guid CanceledById { get; set; }
        public DateTime CanceledOn { get; set; }
        [Column(TypeName = "ntext")]
        public string CancelationReason { get; set; }

        public ICollection<MeetingParticipents> MeetingParticipents { get; set; }
    }
}
