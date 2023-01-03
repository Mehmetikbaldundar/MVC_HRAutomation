using HRAutomation.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.DataAccess.EntityFramework.Mapping
{
    public class AdminMapping : BaseEntityTypeConfig<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired(true);

            base.Configure(builder);
        }
    }
}
