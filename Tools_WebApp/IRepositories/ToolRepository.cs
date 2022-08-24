using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools_WebApp.IRepositories;
using Tools_WebApp.Models;
using Tools_WebApp.Commands;

namespace Tools_WebApp.IRepositories
{
    public class ToolRepository : IRepositoryTools
    {
        public bool Delete(string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var itemDelete = myDb.Tools.Where(t => t.IdTool.Equals(id)).FirstOrDefault();

                myDb.Tools.Remove(itemDelete);
                return myDb.SaveChanges() > 0;
            }
        }

        public bool Exists (string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.Where(t => t.IdTool.Equals(id)).FirstOrDefault() != default(Tool);
            }          
        }

        public bool Insert(CreateToolCommand item)
        {
            //if (item.Quantity < 0)
            //{
            //    return false;
            //}

            Tool tool = new Tool
            {
                IdTool = item.IdTool,
                BoschCode = item.BoschCode,
                Description = item.Description,
                PrimarySupplier = item.PrimarySupplier,
                SecondarySupplier = item.SecondarySupplier,
                Quantity = item.Quantity
            };

            using (MyDBContext myDb = new MyDBContext())
            {
                if (Exists(item.IdTool))
                {
                    Tool toolUpdate = myDb.Tools.Where(t => t.IdTool.Equals(item.IdTool)).FirstOrDefault();
                    toolUpdate.BoschCode = item.BoschCode;
                    toolUpdate.Description = item.Description;
                    toolUpdate.PrimarySupplier = item.PrimarySupplier;
                    toolUpdate.SecondarySupplier = item.SecondarySupplier;
                    toolUpdate.Quantity = item.Quantity;
                    return myDb.SaveChanges() > 0;


                }
                else
                {
                    myDb.Tools.Add(tool);
                    return myDb.SaveChanges() > 0;

                }

            }
        }


        public List<Tool> ReadByPartialId(string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.Where(t => t.IdTool.Contains(id)).ToList();

            }
        }

        public bool UpdateToolQuantity(string toolId, int? newQuantity)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                Tool tool = myDb.Tools.Where(t => t.IdTool.Equals(toolId)).FirstOrDefault();
                tool.Quantity = newQuantity;
                
                return myDb.SaveChanges() > 0;
            }
        }
    }
}