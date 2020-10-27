using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class StShoppingCartItemMap : IEntityTypeConfiguration<StShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<StShoppingCartItem> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.ToplamFiyat).HasColumnType("decimal(6,2)");
            builder.Property(I => I.OtenaziUcreti).HasColumnType("decimal(6,2)");
            builder.Property(I => I.HayvanFiyati).HasColumnType("decimal(6,2)");
            builder.Property(I => I.GunlukBakimUcreti).HasColumnType("decimal(6,2)");
            builder.Property(I => I.DestekTalepTurleri).HasMaxLength(255);
        }
    }
}