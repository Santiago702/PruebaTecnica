using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Alojamiento
{
    public int IdAlojamiento { get; set; }

    public int IdSede { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int CapacidadPersonas { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual Sede IdSedeNavigation { get; set; } = null!;

    public virtual ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();
}
