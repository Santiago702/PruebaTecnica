using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public int IdAlojamiento { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumeroCamas { get; set; }

    public bool BanoPrivado { get; set; }

    public virtual ICollection<DetalleReserva> DetalleReservas { get; set; } = new List<DetalleReserva>();

    public virtual Alojamiento IdAlojamientoNavigation { get; set; } = null!;
}
