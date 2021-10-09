using Demo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.CivitMeetings
{
    class CivitMeetingRepo : EfCoreRepository<DemoDbContext, CivitMeeting, int>,
            ICivitMeetingRepo
    {
        public CivitMeetingRepo(
         IDbContextProvider<DemoDbContext> dbContextProvider)
         : base(dbContextProvider)
    {

    }
       
    }
}
