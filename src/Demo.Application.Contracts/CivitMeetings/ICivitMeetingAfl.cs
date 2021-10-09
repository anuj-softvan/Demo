using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Demo.CivitMeetings
{

    public interface ICivitMeetingAfl : IApplicationService
    {
        Task<CivitMeetingDto> CreateAsync(CreateCivitMeetingDto input);
    }
}
