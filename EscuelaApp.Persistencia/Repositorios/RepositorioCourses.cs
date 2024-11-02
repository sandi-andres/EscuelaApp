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

        public Task<int> insertar(Course curso)
        {
            //validar que el ID no esta guardado es una tarea de repositorio, no de controlador
            var c =  obtenerCursoPorID(curso.CourseId);

            if (curso == null)
            {
                _context.Add(curso);
                var res =  _context.SaveChangesAsync();
                return res;
            }
            else
            {
                return Task.FromResult(3); //para camuflar el int como tarea, esta funcion hace una tarea y devuelve el parametro como tarea
            }

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
            return _context.Courses.Include(c => c.Department).ToListAsync();
        }
    }
}