using EscuelaApp.Dominio.Interfaces;
using EscuelaApp.Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Persistencia.Repositorios
{
    public class RepositorioCourses : ICourses
    {
        private readonly SchoolDBContext _context; //propiedad read only para inyeccion de dependencias

        public RepositorioCourses(SchoolDBContext context) //por inyeccion de dependencias
        {
            _context = context;
        }

        public Task<int> eliminar(Course course)
        {            
            _context.Courses.Remove(course);

            return _context.SaveChangesAsync();
        }

        public async Task<int> insertar(Course curso)
        {
            //validar que el ID no esta guardado es una tarea de repositorio, no de controlador
            //var c =  obtenerCursoPorID(curso.CourseId);

            //if (curso == null)
            //{
                _context.Add(curso);
                var res =  _context.SaveChangesAsync();
                return await res;
            //}
            //else
            //{
            //    return await Task.FromResult(3); //para camuflar el int como tarea, esta funcion hace una tarea y devuelve el parametro como tarea
            //}

        }

        public Task<int> modificar(Course curso)
        {
            _context.Update(curso);
            return _context.SaveChangesAsync();
        }

        public Task<Course?> obtenerCursoPorID(int courseId)
        {
            return _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseId == courseId);
        }

        public Task<List<Course>> obtenerTodo()
        {
            return _context.Courses
                .Include(c => c.Department)
                //ordenar por titulo
                .OrderBy(c => c.Credits)
                //ordenamiento secundario
                .ThenBy(c => c.Title) 
                //.OrderByDescending(c => c.Title)
                //.ThenByDescending ordenamiento secundario descendiente
                .Take(1) //TOP de SQL, en este caso solo devuelve el primero
                .ToListAsync();
        }

        //buscar por nombre completo de curso
        public Task<Course?> obtenerCursoPorNombre(string courseName)
        {
            return _context.Courses
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Title == courseName);
        }
        
        //obtener el total de creditos de todos los cursos
        public Task<int> getTotalCreditos()
        {
            return _context.Courses.SumAsync(c => c.Credits);
        }

        //agrupacion
        /*public Task<List<Object>> getTotalCreditosPorDept()
        {
            var res =  _context.Courses
                .GroupBy(c => c.Department)
                .Select(group => new
                {
                    Departamento = group.Key,
                    TotalCreditos = group.Sum(c => c.Credits)
                }).ToListAsync();

            return res;
         }*/
    }
}