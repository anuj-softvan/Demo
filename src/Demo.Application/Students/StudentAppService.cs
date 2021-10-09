using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Demo.Students
{
    public class StudentAppService : DemoAppService, IStudentAppService
    {

        private readonly IStudentRepository _studentRepository;
        public StudentAppService(
         IStudentRepository studentRepository
           )
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto> CreateAsync(CreateUpdateStudentDto input)
        {
            try
            {

                var student = new Student(
               GuidGenerator.Create(),
               input.Email,
               input.Name,
               input.Class,
               input.BookId
              );
                await _studentRepository.InsertAsync(student);
                return ObjectMapper.Map<Student, StudentDto>(student);
            }catch(Exception ex)
            {
                return new StudentDto();
            }

        }

        public async Task DeleteAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<StudentDto> GetAsync(Guid id)
        {
            var student_data = await _studentRepository.GetAsync(id);
            return ObjectMapper.Map<Student, StudentDto>(student_data);
        }

        public async Task<PagedResultDto<StudentDto>> GetListAsync(GetStudentListDto input)
        {

            var result = await _studentRepository.GetListAsync();
            var totalCount = await _studentRepository.GetCountAsync();

            return new PagedResultDto<StudentDto>(totalCount, ObjectMapper.Map<List<Student>, List<StudentDto>>(result));
        }

        public async Task UpdateAsync(Guid id, CreateUpdateStudentDto input)
        {
            var existing_student = await _studentRepository.GetAsync(id);
            if (existing_student != null)
            {
                existing_student.Name = input.Name;
                existing_student.Email = input.Email;
                existing_student.Class = input.Class;
                existing_student.BookId = input.BookId;
                await _studentRepository.UpdateAsync(existing_student);
            }
        }
    }
}


