using Demo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.InspectSchMeetings
{
    public class InspectSchMeetingRepo : EfCoreRepository<DemoDbContext, InspectSchMeeting, int>,
            IInspectSchMeetingRepo
    {
        public InspectSchMeetingRepo(
         IDbContextProvider<DemoDbContext> dbContextProvider)
         : base(dbContextProvider)
    {

    }
}

    public class InspectProjHeadRepo : EfCoreRepository<DemoDbContext, InspectProjHead, int>,
        IInspectProjHeadRepo
    {
        public InspectProjHeadRepo(
         IDbContextProvider<DemoDbContext> dbContextProvider)
         : base(dbContextProvider)
        {

        }
    }


    public class InspectSchAssignStaffRepo : EfCoreRepository<DemoDbContext, InspectSchAssignStaff, int>,
        IInspectSchAssignStaffRepo
    {
        public InspectSchAssignStaffRepo(
         IDbContextProvider<DemoDbContext> dbContextProvider)
         : base(dbContextProvider)
        {

        }
    }


}
