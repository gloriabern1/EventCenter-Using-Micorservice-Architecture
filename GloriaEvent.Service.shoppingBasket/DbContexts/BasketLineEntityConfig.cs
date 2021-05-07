using GloriaEvent.Service.shoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.DbContexts
{
    public class BasketLineEntityConfig : IEntityTypeConfiguration<BasketLine>
    {
        public void Configure(EntityTypeBuilder<BasketLine> builder)
        {
            builder.HasKey(g => g.BasketLineId);
        }
    }
}
