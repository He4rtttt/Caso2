using System;
using System.Collections.Generic;

namespace Caso2.Models;

public partial class Presupuesto
{
    public int PresupuestoId { get; set; }

    public int? ProyectoId { get; set; }

    public decimal? MontoEstimado { get; set; }

    public decimal? MontoReal { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public virtual Proyecto? Proyecto { get; set; }
}
