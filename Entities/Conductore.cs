using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Conductore
{
    [Key]
    public int IdConductor { get; set; }

    public string? Nombre { get; set; }

    public string? Identificacion { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? LicenciaConducir { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public virtual ICollection<Combustible> Combustibles { get; } = new List<Combustible>();

    public virtual ICollection<Viaje> Viajes { get; } = new List<Viaje>();
}
