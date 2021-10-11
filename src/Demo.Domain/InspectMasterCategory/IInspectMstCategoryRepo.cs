using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Demo.InspectMasterCategory
{
    public interface IInspectMstCategoryRepo : IRepository<InspectMstCategory, int>
    {
    }
}
