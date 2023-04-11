namespace flotilla.DTO
{
    public class CamioneDTO
    {
        public int? Id_Camion { get; set; }

        public string? Marca_Modelo { get; set; }

        public int? Anio_Fabricacion { get; set; }

        public decimal? Capacidad_Carga { get; set; }

        public DateTime? Fecha_Compra { get; set; }

        public string? Estado { get; set; }
    }
}
