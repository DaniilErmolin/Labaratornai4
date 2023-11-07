using System;
using System.Collections.Generic;
using lab4.Models;

namespace lab4;

public partial class Voucher
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int TypeOfRecreationId { get; set; }

    public int ClientId { get; set; }

    public bool Reservation { get; set; }

    public bool Payment { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual TypesOfRecreation TypeOfRecreation { get; set; } = null!;
}
