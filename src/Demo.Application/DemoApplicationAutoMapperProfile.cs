using AutoMapper;
using Demo.Authors;
using Demo.Books;
using Demo.CivitMeetings;
using Demo.InspectSchMeetings;
using Demo.MeetingInspector;
using Demo.MeetingParticipent;
using Demo.Students;
using System.Collections.Generic;

namespace Demo
{
    public class DemoApplicationAutoMapperProfile : Profile
    {
        public DemoApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<MeetingInspectors, MeetingInspectorDto>();
            CreateMap<CreateUpdateMeetingDto, MeetingInspectors>();
            CreateMap<CreateCivitMeetingDto, CivitMeeting>();
            //.ForMember(dest => dest.MeetingParticipents, map => map.MapFrom(src => src.CreateMeetingParticipentDtos.ConvertAll<MeetingParticipent.MeetingParticipents>(y => new MeetingParticipent.MeetingParticipents() { Name = y.Name, Email = y.Email, Mobile = y.Mobile, ParticipentID = y.ParticipentId })));
            CreateMap<CreateCivitMeetingDto,MeetingParticipents>();
            CreateMap<CivitMeeting, CivitMeetingDto>();
            CreateMap<CreateMeetingParticipentDto,MeetingParticipents>();
            CreateMap<CreateUpdateInspectSchMeetingDto, InspectSchMeeting>();
            CreateMap<InspectSchMeeting, InspectSchMeetingDto>();
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}
