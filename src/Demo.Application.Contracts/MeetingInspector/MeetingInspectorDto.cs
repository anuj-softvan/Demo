using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demo.MeetingInspector
{
    public class MeetingInspectorDto : FullAuditedEntityDto<int>
    {
        public Guid InspectorId { get; set; }
        public int MeetingId { get; set; }
        public string Name { get; set; }
    }
}
