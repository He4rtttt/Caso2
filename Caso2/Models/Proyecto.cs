using System;
using System.Collections.Generic;

namespace Caso2.Models;

public partial class Proyecto
{
    public int ProyectoId { get; set; }

    public string? Nombre { get; set; }

    public string? DescripcionObjetivos { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Estado { get; set; }

    public int? ResponsableId { get; set; }

    public virtual ICollection<Informesprogreso> Informesprogresos { get; set; } = new List<Informesprogreso>();

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();

    public virtual Empleado? Responsable { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
