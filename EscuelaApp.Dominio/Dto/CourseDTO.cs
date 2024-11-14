using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Dominio.Dto
{
    public class CourseDTO
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public string NombreDepartamento { get; set; }
    }
}
