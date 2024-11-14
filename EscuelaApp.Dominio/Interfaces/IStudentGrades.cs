using EscuelaApp.Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Dominio.Interfaces
{
    public interface IStudentGrades
    {
        //Laboratorio Punto 1. Numero de estudiantes aprobados y reprobados.
        public Task<int> obtenerNumEstudiantesAprobados();

        public Task<int> obtenerNumEstudiantesReprobados();

        //Laboratorio Punto 2. Los datos de los estudiantes con las 3 mejores notas. 

        public Task<List<StudentGrade>> obtenerEstudiantesNotasTop3();

        //Laboratorio Punto 3. Los datos de los estudiantes con las 3 notas más bajas. 
        public Task<List<StudentGrade>> obtenerEstudiantesNotasPeores3();

        //Laboratorio Punto 6. Obtener el promedio de notas de un estudiante entre todos sus cursos.
        public Task<decimal?> obtenerPromedioxEstudiante(int personId);

    }
}
