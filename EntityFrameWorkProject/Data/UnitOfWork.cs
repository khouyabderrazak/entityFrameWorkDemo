using EntityFrameWorkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    internal class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _db;
        public IRepository<Teacher> TeacherRepository { get ; set; }
        public IRepository<Student> StudentRepository { get ; set ; }
        public IRepository<Class> CLassRepository { get ; set ; }
        public IRepository<Subject> SubjectRepository { get ; set ; }
        public IReadOnlyRepository<Teacher> TeacherReadOnlyRepository { get ; set ; }
        public IReadOnlyRepository<Student> StudentReadOnlyRepository { get ; set ; }
        public IReadOnlyRepository<Class> CLassReadOnlyRepository { get ; set ; }
        public IReadOnlyRepository<Subject> SubjectReadOnlyRepository { get ; set ; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            this.TeacherRepository = new Repository<Teacher>(_db); 
            this.StudentRepository = new Repository<Student>(_db); 
            this.CLassRepository = new Repository<Class>(_db); 
            this.SubjectRepository = new Repository<Subject>(_db);

            this.TeacherReadOnlyRepository = new ReadOnlyRepository<Teacher>(_db);
            this.StudentReadOnlyRepository = new ReadOnlyRepository<Student>(_db);
            this.CLassReadOnlyRepository = new ReadOnlyRepository<Class>(_db);
            this.SubjectReadOnlyRepository = new ReadOnlyRepository<Subject>(_db);
        }

        public async Task CompleteAsyn()
        {
           await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.DisposeAsync();
        }

    }
}
