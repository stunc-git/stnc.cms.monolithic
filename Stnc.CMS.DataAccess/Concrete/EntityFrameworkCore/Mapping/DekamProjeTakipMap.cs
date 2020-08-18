﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DekamProjeTakipMap : IEntityTypeConfiguration<DekamProjeTakip>
    {
        public void Configure(EntityTypeBuilder<DekamProjeTakip> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.ProjeYurutucusu).HasMaxLength(500).IsRequired();
            builder.Property(I => I.ProjeYurutukurumu).HasMaxLength(500).IsRequired();
            builder.Property(I => I.ProjeYurutuTelefon).HasMaxLength(500).IsRequired();
            builder.Property(I => I.SorumluArastirmaci).HasMaxLength(500).IsRequired();
            builder.Property(I => I.SorumluArastirmaciTelefon).HasMaxLength(500).IsRequired();
            builder.Property(I => I.EtikKurulOnayNumarasi).HasMaxLength(500).IsRequired();
            builder.Property(I => I.DeneyHayvaniTurID).HasColumnType("smallint");
            builder.Property(I => I.DeneyHayvaniIrkID).HasColumnType("smallint");
            builder.Property(I => I.DeneyHayvaniCinsiyet).HasColumnType("smallint");
            builder.Property(I => I.DeneyHayvaniSayisi).HasColumnType("smallint");
            builder.Property(I => I.DeneyHayvaniYasi).HasColumnType("smallint");
            builder.Property(I => I.DeneyHayvaniAgirligi).HasColumnType("smallint");
            builder.Property(I => I.TeknikDestekSuresiID).HasColumnType("smallint");
            builder.Property(I => I.TeknikDestekTuruID).HasColumnType("smallint");
            builder.Property(I => I.TeknikHayvanSayisiID).HasColumnType("smallint");
            builder.Property(I => I.LaboratuvarID).HasColumnType("smallint");

            builder.HasOne(I => I.Aciliyet).WithMany(I => I.Gorevler).HasForeignKey(I => I.AciliyetId);
            //https://www.learnentityframeworkcore.com/configuration/one-to-one-relationship-configuration
            //burada kaldım
           // builder .HasOne(a => a.Biography)   .WithOne(b => b.Author).HasForeignKey<AuthorBiography>(b => b.AuthorRef);
        }
    }
}