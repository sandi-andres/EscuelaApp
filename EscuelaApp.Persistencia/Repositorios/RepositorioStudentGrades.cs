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
    public class RepositorioStudentGrades : IStudentGrades
    {
        private readonly SchoolDBContext _context;
        public RepositorioStudentGrades(SchoolDBContext context)
        {
            _context = context;
        }

        //Laboratorio Punto 1. Numero de estudiantes aprobados y reprobados.
        public Task<int> obtenerNumEstudiantesAprobados()
        {
            var count = _context.StudentGrades
            .GroupBy(x => x.StudentId)
            //excluye > 3 pero no a nulls
            .Count(g => g.All(s => s.Grade >= 3)    
            //en caso de haber nulls, que haya aprobado al menos un curso
            && g.Any(s => s.Grade >= 3));

            return Task.FromResult(count);
        }

        public Task<int> obtenerNumEstudiantesReprobados()
        {
            var count = _context.StudentGrades
            .GroupBy(sg => sg.StudentId)
            .Count(g => g.Any(s => s.Grade < 3));

            return Task.FromResult(count);
        }

        //Laboratorio Punto 2. Los datos de los estudiantes con las 3 mejores notas. 
        public Task<List<StudentGrade>> obtenerEstudiantesNotasTop3()
        {
            return _context.StudentGrades
                .Include(s => s.Student)
                .OrderByDescending(x => x.Grade)
                .Take(3)
                .ToListAsync();
        }

        //Laboratorio Punto 3. Los datos de los estudiantes con las 3 notas más bajas. 
        public Task<List<StudentGrade>> obtenerEstudiantesNotasPeores3()
        {
            return _context.StudentGrades
                .Include(p => p.Student)
                .Where(x => x.Grade != null)
                .OrderBy(sg => sg.Grade)
                .Take(3)
                .ToListAsync();
        }

        //Laboratorio Punto 6. Obtener el promedio de notas de un estudiante entre todos sus cursos.
        public Task<decimal?> obtenerPromedioxEstudiante(int personId)
        {
            var res = _context.StudentGrades
                .Where(s => s.StudentId.Equals(personId))
                .Average(g => g.Grade);

            return Task.FromResult(res);
        }
    }
}
