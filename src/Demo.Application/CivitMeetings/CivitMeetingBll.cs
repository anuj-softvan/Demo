using Demo.CivitMeetings;
using Demo.MeetingParticipent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;




namespace Demo.CivitMeetings
{
    public class CivitMeetingBll : DemoAppService, ICivitMeetingAfl 
    {
        private readonly ICivitMeetingRepo _civitMeetingRepo;
        public CivitMeetingBll(ICivitMeetingRepo civitMeetingRepo)
        {
            _civitMeetingRepo = civitMeetingRepo;     
        }

        public async Task<CivitMeetingDto> CreateAsync(CreateCivitMeetingDto input)
        {
            CivitMeeting civitMeeting;
            civitMeeting = ObjectMapper.Map<CreateCivitMeetingDto, CivitMeeting>(input);
            await _civitMeetingRepo.InsertAsync(civitMeeting, true);
            //civitMeeting = await _civitMeetingRepo.InsertAsync(civitMeeting, true);
            // var obj_participent = ObjectMapper.Map<CreateCivitMeetingDto,MeetingParticipents>(input);
            var result = ObjectMapper.Map<List<CreateMeetingParticipentDto>, List<MeetingParticipents>>(input.CreateMeetingParticipentDtos);
            civitMeeting.MeetingParticipents = result;

            //2nd method
            //foreach (var item in input.CreateMeetingParticipentDtos)
            //{
            //    var result = ObjectMapper.Map<CreateMeetingParticipentDto, MeetingParticipents>(item);
            //    civitMeeting.MeetingParticipents.Add(result);
            //}
            var objData = ObjectMapper.Map<CivitMeeting, CivitMeetingDto>(civitMeeting);
            await CurrentUnitOfWork.SaveChangesAsync();
            return objData;
        }

    }
}
