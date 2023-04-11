using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Seguro
{
    [Key]
    public int IdSeguro { get; set; }

    public string? Poliza { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? MontoAsegurado { get; set; }

    public string? TipoCobertura { get; set; }

    public int? Id_Camion { get; set; }

    public virtual Camione? Id_CamionNavigation { get; set; }
}
