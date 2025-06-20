using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class DetalleReserva
{
    public int IdDetalle { get; set; }

    public int IdReserva { get; set; }

    public int IdHabitacion { get; set; }

    public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
