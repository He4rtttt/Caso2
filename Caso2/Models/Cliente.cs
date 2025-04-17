using System;
using System.Collections.Generic;

namespace Caso2.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? NombreContacto { get; set; }

    public string? CorreoContacto { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();
}
