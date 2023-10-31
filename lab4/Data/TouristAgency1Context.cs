using System;
using System.Collections.Generic;
using lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace lab4.Data;

public partial class TouristAgency1Context : DbContext
{
    public TouristAgency1Context()
    {
    }

    public TouristAgency1Context(DbContextOptions<TouristAgency1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalService> AdditionalServices { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<TypesOfRecreation> TypesOfRecreations { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vouchers__3214EC07A43B24A5");

            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.AdditionalService).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.AdditionalServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_AdditionalServices");

            entity.HasOne(d => d.Client).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Clients");

            entity.HasOne(d => d.Employess).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.EmployessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Employees");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Hotels");

            entity.HasOne(d => d.TypeOfRecreation).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.TypeOfRecreationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_TypesOfRecreation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
