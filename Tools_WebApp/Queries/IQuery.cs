using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools_WebApp.Queries
{
    public interface IQuery<T>
    {
        List<T> ReadAll();

        T ReadById(string id);

        T ReadById(string id, string id2);

        List<T> ReadByPartialId(string id);

        bool Insert(T item);

        bool Update(T item, string key);


    }
}
