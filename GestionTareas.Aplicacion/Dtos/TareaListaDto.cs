using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Aplicacion.Dtos
{
    public class TareaListaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;

        public int PrioridadId { get; set; }
        public string PrioridadDescripcion { get; set; } = string.Empty;

        public int EstadoId { get; set; }
        public string EstadoDescripcion { get; set; } = string.Empty;
    }

}
