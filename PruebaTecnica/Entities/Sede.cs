using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Sede
{
    public int IdSede { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public int Capacidad { get; set; }

    public virtual ICollection<Alojamiento> Alojamientos { get; set; } = new List<Alojamiento>();
}
