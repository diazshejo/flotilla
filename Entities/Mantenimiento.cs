using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Mantenimiento
{
    [Key]
    public int IdMantenimiento { get; set; }

    public DateTime? FechaServicio { get; set; }

    public string? TipoServicio { get; set; }

    public decimal? Costo { get; set; }

    public int? Kilometraje { get; set; }

    public int? Id_Camion { get; set; }

    public virtual Camione? Id_CamionNavigation { get; set; }
}
