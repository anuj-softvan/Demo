using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.InspectMasterCategory
{
    public class InspectMstCategory : FullAuditedAggregateRoot<int>
    {
        public int OrgID { get; set; }
        public string InspectCatIdnCode { get; set; }
        public string PermitIdnCode { get; set; }
        public string AppTypeIdnCode { get; set; }
        public Guid ChkFormID { get; set; }
    }
}
