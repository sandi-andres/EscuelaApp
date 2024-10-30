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

        public Task<int> eliminar(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<int> insertar(Course curso)
        {
            _context.Add(curso);
             return _context.SaveChangesAsync();
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