using EntityFrameWorkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    public interface IUnitOfWork : IDisposable
    {
         IRepository<Teacher> TeacherRepository { get; set; }
         IRepository<Student> StudentRepository { get; set; }
         IRepository<Class> CLassRepository { get; set; }
         IRepository<Subject> SubjectRepository { get; set; }
         IReadOnlyRepository<Teacher> TeacherReadOnlyRepository { get; set; }
         IReadOnlyRepository<Student> StudentReadOnlyRepository { get; set; }
         IReadOnlyRepository<Class> CLassReadOnlyRepository { get; set; }
         IReadOnlyRepository<Subject> SubjectReadOnlyRepository { get; set; }
        Task CompleteAsyn();
    }
}
