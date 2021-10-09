using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Demo.MeetingInspector
{
    public interface IMeetingInspectorAfl : IApplicationService
    {
        Task<MeetingInspectorDto> GetAsync(int id);

        Task<MeetingInspectorDto> CreateAsync(CreateUpdateMeetingDto input);

        Task UpdateAsync(int id, CreateUpdateMeetingDto input);

        Task DeleteAsync(int id);
    }
}

