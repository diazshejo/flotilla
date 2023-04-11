using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flotilla.Entities;

public partial class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? Cliente { get; set; }

    public string? TipoCarga { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Peso { get; set; }
}
