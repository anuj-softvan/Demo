using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InspectMasterCategory
{
    public class InspectMstCategoryDto
    {
        public int OrgID { get; set; }
        public string InspectCatIdnCode { get; set; }
        public string PermitIdnCode { get; set; }
        public string AppTypeIdnCode { get; set; }
        public Guid ChkFormID { get; set; }
    }
}
