using GestionTareas.Aplicacion.Servicios;
using GestionTareas.Dominio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ConsultaTareasServicio _servicio;

        public TareasController(ConsultaTareasServicio servicio)
        {
            _servicio = servicio;
        }

        // GET: api/tareas
        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromQuery] string? estado,
            [FromQuery] string? prioridad)
        {
            // Si no vienen filtros → lista todo
            if (string.IsNullOrWhiteSpace(estado) && string.IsNullOrWhiteSpace(prioridad))
            {
                var tareas = await _servicio.Listar();
                return Ok(tareas);
            }

            // Parseo de enums (con validación)
            if (!TryParseEstado(estado, out var estadoEnum))
                return BadRequest("Estado inválido. Valores permitidos: Pendiente, EnProceso, Completada");

            if (!TryParsePrioridad(prioridad, out var prioridadEnum))
                return BadRequest("Prioridad inválida. Valores permitidos: Baja, Media, Alta");

            var resultado = await _servicio.Filtrar(estadoEnum, prioridadEnum);
            return Ok(resultado);
        }

        // GET: api/tareas/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerDetalle(int id)
        {
            if (id <= 0)
                return BadRequest("El id debe ser mayor a cero.");

            var tarea = await _servicio.ObtenerDetalle(id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        // =========================
        // Helpers privados
        // =========================
        private bool TryParseEstado(string? value, out EstadoTarea? estado)
        {
            estado = null;
            if (string.IsNullOrWhiteSpace(value))
                return true;

            if (Enum.TryParse<EstadoTarea>(value, true, out var parsed))
            {
                estado = parsed;
                return true;
            }

            return false;
        }

        private bool TryParsePrioridad(string? value, out PrioridadTarea? prioridad)
        {
            prioridad = null;
            if (string.IsNullOrWhiteSpace(value))
                return true;

            if (Enum.TryParse<PrioridadTarea>(value, true, out var parsed))
            {
                prioridad = parsed;
                return true;
            }

            return false;
        }
    }
}
