using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDiazActividades
{
    public class Actividad
    {
        public int idActividad {  get; set; }
        public string nombreActividad { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string observacion { get; set; }
    }
}
