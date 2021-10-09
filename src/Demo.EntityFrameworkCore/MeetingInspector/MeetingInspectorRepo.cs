using Demo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.MeetingInspector
{
    public class MeetingInspectorRepo : EfCoreRepository<DemoDbContext, MeetingInspectors, int>,
            IMeetingInspectorRepo
    {
        public MeetingInspectorRepo(
         IDbContextProvider<DemoDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
        }
    }
}
