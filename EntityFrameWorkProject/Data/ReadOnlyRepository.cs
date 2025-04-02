using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    public class ReadOnlyRepository<T>: IReadOnlyRepository<T> where T: class
    {
        private readonly AppDbContext _db;
        public ReadOnlyRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);

        }

    }
}
