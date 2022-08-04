using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools_WebApp.Models;

namespace Tools_WebApp.Queries
{
    public class Query : IQuery<Tool>
    {
        public bool Insert(Tool item)
        {
            throw new NotImplementedException();
        }

        public List<Tool> ReadAll()
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.ToList();
            }
        }

        public Tool ReadById(string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.AsQueryable().Where(t => t.IdTool.Equals(id)).FirstOrDefault();
            }
        }

        public Tool ReadById(string id, string id2)
        {
            throw new NotImplementedException();
        }

        public List<Tool> ReadByPartialId(string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.Where(t => t.IdTool.Contains(id)).ToList();

            }
        }

        public bool Update(Tool item, string key)
        {
            throw new NotImplementedException();
        }
    }
}