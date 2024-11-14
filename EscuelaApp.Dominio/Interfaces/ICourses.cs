using EscuelaApp.Dominio.Entidades;
using EscuelaApp.Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EscuelaApp.Dominio.Interfaces
{
    public interface ICourses
    {
        //Insertar
        public Task<int> insertar(Course curso);

        //Modificar
        public Task<int> modificar(Course curso);

        //Eliminar
        public Task<int> eliminar(Course curso);

        //Consultar(ID)

        //Tarea asincrona porque vamos a trabajar con API y se debe esperar la respuesta
        //se utiliza siempre que se debe consumir un recurso externo
        public Task<Course?> obtenerCursoPorID(int courseId);

        //Consultar Todo
        public Task<List<Course>> obtenerTodo();

        //buscar por nombre completo
        public Task<Course?> obtenerCursoPorNombre(string courseName);

        public Task<int> getTotalCreditos();

        //obtener el total de creditos por departamento
        //public Task<int> getTotalCreditosPorDept();

        //Laboratorio Punto 4. Obtener el promedio de créditos de los cursos.
        public Task<double> obtenerPromedioCreditos();

        //Laboratorio Punto 5. Obtener el numero de docentes que tiene cada curso. 
        //public Task<List<PersonasPorCurso>> obtenerDocentesPorCurso();

        //Laboratorio Punto 7. Obtener el numero de estudiantes inscritos en cada curso
        //public Task<List<PersonasPorCurso>> obteneEstudiantesCursos();
    }
}
