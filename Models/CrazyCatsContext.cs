using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrazyCatsWeb.Models;

public partial class CrazyCatsContext : DbContext
{
    public CrazyCatsContext()
    {
    }

    public CrazyCatsContext(DbContextOptions<CrazyCatsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptionApplication> AdoptionApplications { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptionApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adoption__3214EC0760C33492");

            entity.Property(e => e.ApplicantEmail).HasMaxLength(100);
            entity.Property(e => e.ApplicantName).HasMaxLength(100);

            entity.HasOne(d => d.Animal).WithMany(p => p.AdoptionApplications)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__AdoptionA__Anima__52593CB8");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3214EC076EC02E00");

            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Species).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07982ACF6C");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E44E83ED9D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105348173F258").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("User ");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
