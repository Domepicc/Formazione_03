using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools_WebApp.Models;
using Tools_WebApp.Commands;

namespace Tools_WebApp
{
    public interface IRepositoryTools
    {

        List<Tool> ReadByPartialId(string id);

        bool Insert(CreateToolCommand item);

        bool Delete(string id);

        bool UpdateToolQuantity(string id, int? quantity);

    }
}
