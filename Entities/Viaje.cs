using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Viaje
{
    [Key]
    public int IdViaje { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdConductor { get; set; }

    public int? Id_Camion { get; set; }

    public int? IdRuta { get; set; }

    public string? PedidosEntregados { get; set; }

    public TimeSpan? TiempoSalida { get; set; }

    public TimeSpan? TiempoLlegada { get; set; }

    public virtual Camione? Id_CamionNavigation { get; set; }

    public virtual Conductore? IdConductorNavigation { get; set; }

    public virtual Ruta? IdRutaNavigation { get; set; }
}
