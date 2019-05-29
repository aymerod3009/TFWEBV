using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICrudRepository<T>
    {
        bool insert(T t);
        bool update(T t);
        bool delete(int id);
        List<T> FindAll();
        T FindbyID(int? id);
    }
}
