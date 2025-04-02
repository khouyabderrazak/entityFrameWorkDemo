using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    public interface IReadOnlyRepository<T>
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
    }
}
