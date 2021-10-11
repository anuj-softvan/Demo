using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Demo.InspectSchMeetings
{
    public interface IInspectSchMeetingAfl : IApplicationService
    {
        Task<InspectSchMeetingDto> GetAsync(int id);

        Task<InspectSchMeetingDto> CreateAsync(int InsProjHeadID,CreateUpdateInspectSchMeetingDto input);

        Task UpdateAsync(int id, CreateUpdateInspectSchMeetingDto input);

        Task DeleteAsync(int id);
    }
}
