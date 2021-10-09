using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.MeetingInspector
{
    public class MeetingInspectors : FullAuditedAggregateRoot<int>
    {
        public Guid InspectorId { get; set; }
        public int MeetingId { get; set; }
        public string Name { get; set; }

        //public MeetingInspectors(Guid id,
        //    string name,
        //   Guid inspectorId,
        //   int meetingId
        //    )
        //    : base(id)
        //{
        //    Name = name;
        //    InspectorId = inspectorId;
        //    MeetingId = meetingId;
        //}


    }
}
