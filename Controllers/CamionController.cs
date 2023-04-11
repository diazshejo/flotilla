using flotilla.Entities;
using flotilla.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net;


namespace flotilla.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamionController : ControllerBase
    {
        private readonly DBContext DBContext;

        public CamionController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetCamiones")]
        public async Task<ActionResult<List<CamioneDTO>>> Get()
        {
            var List = await DBContext.Camiones.Select(
                s => new CamioneDTO
                {
                    Id_Camion = s.Id_Camion,
                    Marca_Modelo = s.Marca_Modelo,
                    Anio_Fabricacion = s.Anio_Fabricacion,
                    Capacidad_Carga = s.Capacidad_Carga,
                    Fecha_Compra = s.Fecha_Compra,
                    Estado = s.Estado
                }).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<CamioneDTO>> GetUserById(int Id)
        {
            CamioneDTO camiones = await DBContext.Camiones.Select(
                    s => new CamioneDTO
                    {
                        Id_Camion = s.Id_Camion,
                        Marca_Modelo = s.Marca_Modelo,
                        Anio_Fabricacion = s.Anio_Fabricacion,
                        Capacidad_Carga = s.Capacidad_Carga,
                        Fecha_Compra = s.Fecha_Compra,
                        Estado = s.Estado
                    })
                .FirstOrDefaultAsync(predicate: s => s.Id_Camion == Id);

            if (camiones == null)
            {
                return NotFound();
            }
            else
            {
                return camiones;
            }
        }

        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(CamioneDTO camione)
        {
            var entity = new Camione()
            {
                Id_Camion = (int)camione.Id_Camion,
                Marca_Modelo = camione.Marca_Modelo,
                Anio_Fabricacion = camione.Anio_Fabricacion,
                Capacidad_Carga = camione.Capacidad_Carga,
                Fecha_Compra = camione.Fecha_Compra,
                Estado = camione.Estado
            };

            DBContext.Camiones.Add(entity);
            await DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

    }
}
