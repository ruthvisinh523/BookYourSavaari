using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntity;

public partial class BookYourSavaariDbContext : DbContext
{
    public BookYourSavaariDbContext()
    {
    }

    public BookYourSavaariDbContext(DbContextOptions<BookYourSavaariDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginTbl> LoginTbls { get; set; }

    public virtual DbSet<RoleTbl> RoleTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1B2K66Q1;Database=BookYourSavaariDB;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginTbl>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("LoginTbl");

            entity.Property(e => e.LoginId).ValueGeneratedNever();
            entity.Property(e => e.PasswordHase).HasMaxLength(50);
            entity.Property(e => e.PsswordSult).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleTbl>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("RoleTbl");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserTbl");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.PasswordSult).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");

            entity.HasOne(d => d.Role).WithMany(p => p.UserTbls)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserTbl_RoleTbl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
