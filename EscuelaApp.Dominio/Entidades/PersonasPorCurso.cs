using EscuelaApp.Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Dominio.Entidades
{
    public class PersonasPorCurso
    {
        public Course Curso { get; set; }

        public int TotalPersonas { get; set; }
    }
}
