using GestionTareas.Aplicacion.Dtos;
using GestionTareas.Aplicacion.Interfaces;
using GestionTareas.Dominio.Enums;

namespace GestionTareas.Aplicacion.Servicios
{
    public class ConsultaTareasServicio
    {
        private readonly ITareaRepositorio _repositorio;

        public ConsultaTareasServicio(ITareaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<List<TareaListaDto>> Listar() =>
            _repositorio.ListarAsync();

        public Task<List<TareaListaDto>> Filtrar(EstadoTarea? estado, PrioridadTarea? prioridad) =>
            _repositorio.FiltrarAsync(estado, prioridad);

        public Task<TareaDetalleDto?> ObtenerDetalle(int id) =>
            _repositorio.ObtenerPorIdAsync(id);
    }
}
