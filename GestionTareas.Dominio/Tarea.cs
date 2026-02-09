using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTareas.Dominio.Enums;

namespace GestionTareas.Dominio
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public PrioridadTarea Prioridad { get; set; }
        public EstadoTarea Estado { get; set; }
    }
}
