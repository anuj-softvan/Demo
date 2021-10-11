using Demo.EntityFrameworkCore;
using Demo.InspectSchMeetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.InspectMasterCategory
{
    public class InspectMstCategoryRepo : EfCoreRepository<DemoDbContext, InspectMstCategory, int>,
            IInspectMstCategoryRepo
    {
        public InspectMstCategoryRepo(
        IDbContextProvider<DemoDbContext> dbContextProvider)
        : base(dbContextProvider)
        {

        }
    }
}
