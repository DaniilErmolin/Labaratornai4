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

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<TypesOfRecreation> TypesOfRecreations { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
}