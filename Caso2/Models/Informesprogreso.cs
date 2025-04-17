using System;
using System.Collections.Generic;

namespace Caso2.Models;

public partial class Informesprogreso
{
    public int InformeId { get; set; }

    public int? ProyectoId { get; set; }

    public DateOnly? FechaInforme { get; set; }

    public string? Descripcion { get; set; }

    public int? PorcentajeAvance { get; set; }

    public virtual Proyecto? Proyecto { get; set; }
}
