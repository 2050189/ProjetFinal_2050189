using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetFinal_2050189.Models;

namespace ProjetFinal_2050189.Data
{
    public partial class ProjetFinal2050189Context : DbContext
    {
        public ProjetFinal2050189Context()
        {
        }

        public ProjetFinal2050189Context(DbContextOptions<ProjetFinal2050189Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Achat> Achats { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Detail> Details { get; set; } = null!;
        public virtual DbSet<Gamme> Gammes { get; set; } = null!;
        public virtual DbSet<Hydratant> Hydratants { get; set; } = null!;
        public virtual DbSet<Magasin> Magasins { get; set; } = null!;
        public virtual DbSet<Produit> Produits { get; set; } = null!;
        public virtual DbSet<Savon> Savons { get; set; } = null!;
        public virtual DbSet<Vaporisateur> Vaporisateurs { get; set; } = null!;
        public virtual DbSet<VwTypeDesProduit> VwTypeDesProduits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BDProjetFinal2050189");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achat>(entity =>
            {
                entity.HasOne(d => d.Magasin)
                    .WithMany(p => p.Achats)
                    .HasForeignKey(d => d.MagasinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Achat_MagasinID");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(e => e.DetailsId)
                    .HasName("PK_Details_DetailsID");

                entity.HasOne(d => d.Achat)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.AchatId)
                    .HasConstraintName("FK_Details_AchatID");

                entity.HasOne(d => d.Produit)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.ProduitId)
                    .HasConstraintName("FK_Details_ProduitID");
            });

            modelBuilder.Entity<Hydratant>(entity =>
            {
                entity.HasOne(d => d.Produit)
                    .WithMany(p => p.Hydratants)
                    .HasForeignKey(d => d.ProduitId)
                    .HasConstraintName("FK_Hydratant_ProduitID");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasOne(d => d.Gamme)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.GammeId)
                    .HasConstraintName("FK_Produit_GammeID");
            });

            modelBuilder.Entity<Savon>(entity =>
            {
                entity.HasOne(d => d.Produit)
                    .WithMany(p => p.Savons)
                    .HasForeignKey(d => d.ProduitId)
                    .HasConstraintName("FK_Savon_ProduitID");
            });

            modelBuilder.Entity<Vaporisateur>(entity =>
            {
                entity.HasOne(d => d.Produit)
                    .WithMany(p => p.Vaporisateurs)
                    .HasForeignKey(d => d.ProduitId)
                    .HasConstraintName("FK_Vaporisateur_ProduitID");
            });

            modelBuilder.Entity<VwTypeDesProduit>(entity =>
            {
                entity.ToView("vw_TypeDesProduits", "VENTE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
