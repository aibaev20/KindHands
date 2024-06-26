using System;
using System.Collections.Generic;
using KindHands.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KindHands.DAL.Data;

public partial class KindHandsContext : DbContext
{
    public KindHandsContext()
    {
    }

    public KindHandsContext(DbContextOptions<KindHandsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ad> Ads { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    public virtual DbSet<VolunteerAd> VolunteerAds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=KindHands;Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ad>(entity =>
        {
            entity.HasIndex(e => e.OrganisationId, "IX_Ads_OrganisationId");

            entity.HasOne(d => d.Organisation).WithMany(p => p.Ads).HasForeignKey(d => d.OrganisationId);
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Organisations_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Organisations).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Volunteers_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Volunteers).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<VolunteerAd>(entity =>
        {
            entity.HasIndex(e => e.AdId, "IX_VolunteerAds_AdId");

            entity.HasIndex(e => e.VolunteerId, "IX_VolunteerAds_VolunteerId");

            entity.HasOne(d => d.Ad).WithMany(p => p.VolunteerAds).HasForeignKey(d => d.AdId);

            entity.HasOne(d => d.Volunteer).WithMany(p => p.VolunteerAds).HasForeignKey(d => d.VolunteerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
