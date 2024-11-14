using EscuelaApp.Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Dominio.Interfaces
{
    public interface IPerson
    {
        //obtener estudiantes aprobados
        public Task<List<Person>> obtenerEstudiantesAprobados();

    }
}
