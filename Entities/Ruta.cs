using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Ruta
{
    [Key]
    public int IdRuta { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

    public decimal? Distancia { get; set; }

    public TimeSpan? TiempoEstimadoLlegada { get; set; }

    public string? RestriccionesHorario { get; set; }

    public virtual ICollection<Viaje> Viajes { get; } = new List<Viaje>();
}
