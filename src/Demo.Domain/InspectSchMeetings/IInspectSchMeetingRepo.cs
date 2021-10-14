using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Demo.InspectSchMeetings
{
    public interface IInspectSchMeetingRepo : IRepository<InspectSchMeeting,int>
    {
    }

    public interface IInspectProjHeadRepo : IRepository<InspectProjHead, int>
    {
    }

    public interface IInspectSchAssignStaffRepo : IRepository<InspectSchAssignStaff, int>
    {
    }
}
