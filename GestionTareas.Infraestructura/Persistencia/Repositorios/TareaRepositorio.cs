using System.Data;
using Dapper;
using GestionTareas.Aplicacion.Dtos;
using GestionTareas.Aplicacion.Interfaces;
using GestionTareas.Dominio.Enums;
using GestionTareas.Infraestructura.Persistencia.Conexion;

namespace GestionTareas.Infraestructura.Persistencia.Repositorios
{
    public class TareaRepositorio : ITareaRepositorio
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TareaRepositorio(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<TareaListaDto>> ListarAsync()
        {
            using var conn = _connectionFactory.Create();
            var result = await conn.QueryAsync<TareaListaDto>(
                "sp_tareas_listar",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<TareaListaDto>> FiltrarAsync(EstadoTarea? estado, PrioridadTarea? prioridad)
        {
            using var conn = _connectionFactory.Create();

            if (conn is Microsoft.Data.SqlClient.SqlConnection sql)
            {
                // NO LEAS ConnectionString si está rompiendo; valida la variable interna:
                Console.WriteLine("sql == null? " + (sql == null));
            }


            var p = new DynamicParameters();
            p.Add("@EstadoId", estado.HasValue ? (int)estado.Value : (int?)null);
            p.Add("@PrioridadId", prioridad.HasValue ? (int)prioridad.Value : (int?)null);

            var result = await conn.QueryAsync<TareaListaDto>(
                "sp_tareas_filtrar",
                p,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<TareaDetalleDto?> ObtenerPorIdAsync(int id)
        {
            using var conn = _connectionFactory.Create();

            var p = new DynamicParameters();
            p.Add("@Id", id);

            return await conn.QueryFirstOrDefaultAsync<TareaDetalleDto>(
                "sp_tarea_detalle",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}
