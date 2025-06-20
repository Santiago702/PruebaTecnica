using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Temporadum
{
    public int IdTemporada { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public virtual ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();
}
