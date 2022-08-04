using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;


namespace Tools_WebApp.Models
{
    class ToolEntityTypeConfiguration : EntityTypeConfiguration<Tool>
    {
        public ToolEntityTypeConfiguration()
        {

            ToTable("Tools");

            HasKey(x => new { x.IdTool});

            Property(x => x.BoschCode).HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(100);
            Property(x => x.PrimarySupplier).HasMaxLength(50);
            Property(x => x.SecondarySupplier).HasMaxLength(50);
            Property(x => x.Quantity).IsOptional();

        }
    }
}