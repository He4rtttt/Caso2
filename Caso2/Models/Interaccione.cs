using System;
using System.Collections.Generic;

namespace Caso2.Models;

public partial class Interaccione
{
    public int InteraccionId { get; set; }

    public int? ClienteId { get; set; }

    public int? ProyectoId { get; set; }

    public string? Tipo { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Proyecto? Proyecto { get; set; }
}
