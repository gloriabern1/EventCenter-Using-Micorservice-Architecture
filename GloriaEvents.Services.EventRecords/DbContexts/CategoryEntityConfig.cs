using GloriaEvents.Services.EventRecords.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.DbContexts
{
    internal class CategoryEntityConfig : IEntityTypeConfiguration<Categorys>
    {
        public void Configure(EntityTypeBuilder<Categorys> builder)
        {
            builder.HasKey(g => g.CategoryId);
        }
    }
}
