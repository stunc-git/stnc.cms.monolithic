﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Surname).HasMaxLength(100);

            builder.HasMany(I => I.Gorevler).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(I => I.Posts).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(I => I.DekamProjeTakip).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(I => I.DekamProjeDeneyHayvaniIrk).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(I => I.DekamProjeDeneyHayvaniTur).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(I => I.DekamProjeLaboratuvarlar).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(I => I.DekamProjeTeknikDestekTalepTur).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(I => I.DekamProjeDeneyHayvaniIrkFiyat).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}