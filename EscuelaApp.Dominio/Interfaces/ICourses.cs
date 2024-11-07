using EscuelaApp.Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Task<Course?> obtenerCursoPorNombre(String courseName);

        public Task<int> getTotalCreditos();

        //obtener el total de creditos por departamento
        ////public Task<int> getTotalCreditosPorDept();

    }
}
