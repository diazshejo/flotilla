using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Combustible
{
    [Key]
    public int IdCombustible { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdConductor { get; set; }

    public int? Id_Camion { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Costo { get; set; }

    public virtual Camione? Id_CamionNavigation { get; set; }

    public virtual Conductore? IdConductorNavigation { get; set; }
}
