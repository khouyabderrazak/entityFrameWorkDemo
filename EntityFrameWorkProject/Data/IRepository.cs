using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> addOne(T t);
        Task<bool> DeleteOne(int id);
        //Task<T> GetById(int id);
        //Task<IList<T>> GetAll();
        Task<T> UpdateOne(T t);
    }
}
