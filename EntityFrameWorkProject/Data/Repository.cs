using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public Repository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<T> addOne(T t)
        {
             await _db.Set<T>().AddAsync(t);
            return t;
        }

        public async Task<bool> DeleteOne(int id)
        {
            var itm = await _db.Set<T>().FindAsync(id);
            if (itm is not null)
            {
                _db.Set<T>().Remove(itm);
            }

            return false;
                
        }

       
        public async Task<T> UpdateOne(T t)
        {
             _db.Set<T>().Update(t);

            return t;
        }
    }
}
