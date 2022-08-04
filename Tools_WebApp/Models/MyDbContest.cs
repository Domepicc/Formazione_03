using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;

namespace Tools_WebApp.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Tool> Tools { get; set; }

        public MyDBContext() : base("name=ToolsConnectionString")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          Database.SetInitializer<MyDBContext>(null);

            modelBuilder.HasDefaultSchema("Config");


            //modelBuilder.Entity<Tool>().HasKey(x => new { x.IdTool });

            modelBuilder.Configurations.AddFromAssembly(typeof(MyDBContext).Assembly);

            base.OnModelCreating(modelBuilder);


        }
    }
}
