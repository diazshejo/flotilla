using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Camione
{
    [Key]
    public int Id_Camion { get; set; }

    public string? Marca_Modelo { get; set; }

    public int? Anio_Fabricacion { get; set; }

    public decimal? Capacidad_Carga { get; set; }

    public DateTime? Fecha_Compra { get; set; }

    public string? Estado { get; set; }

   public virtual ICollection<Combustible> Combustibles { get; } = new List<Combustible>();

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();

    public virtual ICollection<Seguro> Seguros { get; } = new List<Seguro>();

    public virtual ICollection<Viaje> Viajes { get; } = new List<Viaje>();
}
