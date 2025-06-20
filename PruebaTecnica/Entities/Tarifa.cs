using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Tarifa
{
    public int IdTarifa { get; set; }

    public int IdAlojamiento { get; set; }

    public int IdTemporada { get; set; }

    public decimal PrecioBase { get; set; }

    public decimal PrecioPersona { get; set; }

    public virtual Alojamiento IdAlojamientoNavigation { get; set; } = null!;

    public virtual Temporadum IdTemporadaNavigation { get; set; } = null!;
}
