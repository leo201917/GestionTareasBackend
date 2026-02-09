using GestionTareas.Aplicacion.Dtos;
using GestionTareas.Dominio.Enums;

namespace GestionTareas.Aplicacion.Interfaces
{
    public interface ITareaRepositorio
    {
        Task<List<TareaListaDto>> ListarAsync();
        Task<List<TareaListaDto>> FiltrarAsync(EstadoTarea? estado, PrioridadTarea? prioridad);
        Task<TareaDetalleDto?> ObtenerPorIdAsync(int id);
    }
}
