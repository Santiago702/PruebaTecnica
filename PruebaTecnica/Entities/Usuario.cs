using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entities;

public partial class Usuario
{
    public string IdUsuario { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }

    public long Celular { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
