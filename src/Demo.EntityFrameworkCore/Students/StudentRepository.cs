using Demo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.Students
{
    public class StudentRepository:
     EfCoreRepository<DemoDbContext, Student, Guid>,
            IStudentRepository
    {
        public StudentRepository(
           IDbContextProvider<DemoDbContext> dbContextProvider)
           : base(dbContextProvider)
    {
    }
}
}
