using System.Data;

namespace GestionTareas.Infraestructura.Persistencia.Conexion
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
