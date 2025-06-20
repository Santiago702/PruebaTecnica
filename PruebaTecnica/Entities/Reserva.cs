using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public string IdUsuario { get; set; } = null!;

    public DateTime FechaReserva { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int NumeroPersonas { get; set; }

    public decimal? TotalPagar { get; set; }

    public virtual ICollection<DetalleReserva> DetalleReservas { get; set; } = new List<DetalleReserva>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
