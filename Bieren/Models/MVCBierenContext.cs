using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bieren.Models;

public partial class MVCBierenContext : DbContext
{
    public MVCBierenContext()
    {
    }

    public MVCBierenContext(DbContextOptions<MVCBierenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bier> Bieren { get; set; }

    public virtual DbSet<Brouwer> Brouwers { get; set; }

    public virtual DbSet<Soort> Soorten { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MVCBieren;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Bieren$PrimaryKey");

            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Prijs).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Brouwer).WithMany(p => p.Bieren)
                .HasForeignKey(d => d.BrouwerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bieren$BrouwersBieren");

            entity.HasOne(d => d.Soort).WithMany(p => p.Bieren)
                .HasForeignKey(d => d.SoortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bieren$SoortenBieren");
        });

        modelBuilder.Entity<Brouwer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Brouwers$PrimaryKey");

            entity.Property(e => e.Adres).HasMaxLength(50);
            entity.Property(e => e.BrNaam).HasMaxLength(50);
            entity.Property(e => e.Gemeente).HasMaxLength(50);
        });

        modelBuilder.Entity<Soort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Soorten$PrimaryKey");

            entity.Property(e => e.Naam).HasMaxLength(50).HasColumnName("Soort");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
