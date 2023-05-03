using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MudBlazorPage.Shared.Entities.Models;

namespace MudBlazorPage.Server.Data;

public partial class RecordContext : DbContext
{
    public RecordContext()
    {
    }

    public RecordContext(DbContextOptions<RecordContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HAMS\\SQLEXPRESS;Initial Catalog=record;Encrypt=False;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserTable_1");

            entity.ToTable("UserTable");

            entity.Property(e => e.UserId)
                .HasMaxLength(24)
                .HasColumnName("UserID");
            entity.Property(e => e.AzureObjectId)
                .HasMaxLength(1024)
                .HasColumnName("AzureObjectID");
            entity.Property(e => e.BusinessUnit).HasMaxLength(1024);
            entity.Property(e => e.Category).HasMaxLength(16);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.CountryCode).HasMaxLength(255);
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(2048);
            entity.Property(e => e.GroupOf).HasMaxLength(2048);
            entity.Property(e => e.LastName).HasMaxLength(2048);
            entity.Property(e => e.ManagerUserId)
                .HasMaxLength(24)
                .HasColumnName("ManagerUserID");
            entity.Property(e => e.PersonId)
                .HasMaxLength(100)
                .HasColumnName("PersonID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(24);
            entity.Property(e => e.Region).HasMaxLength(24);
            entity.Property(e => e.SiteCode).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(1024);
            entity.Property(e => e.Upn)
                .HasMaxLength(2048)
                .HasColumnName("UPN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
