using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfsMvcDemo.DataAcces.Abstract
{
    internal interface ICrudOperation<T>
    {
        List<T> GetAll();
        void Add(T p);
        void Delete(int id);
    }
}
