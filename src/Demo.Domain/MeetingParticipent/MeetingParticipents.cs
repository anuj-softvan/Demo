using Demo.CivitMeetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.MeetingParticipent
{
    public class MeetingParticipents : FullAuditedAggregateRoot<int>
    {
        public Guid ParticipentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public int MeetingID { get; set; }
        public CivitMeeting CivitMeeting { get; set; }

    }
}
