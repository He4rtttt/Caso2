using System;
using System.Collections.Generic;

namespace Caso2.Models;

public partial class Tarea
{
    public int TareaId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? ProyectoId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Estado { get; set; }

    public int? Progreso { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Proyecto? Proyecto { get; set; }
}
