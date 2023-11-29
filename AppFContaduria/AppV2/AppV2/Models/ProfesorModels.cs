using System;
using System.Collections.Generic;
using System.Text;

namespace AppV2.Models
{
    public class ProfesorModels
    {
        public string nombre { get; set; }
        public string materia { get; set; }
        public IEnumerable<CursosModels> cursos { get; set; }
    }
}
