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
    public class RepositorioPerson : IPerson
    {
        private readonly SchoolDBContext _context;
        public RepositorioPerson(SchoolDBContext context)
        {
            _context = context;
        }

        public Task<List<Person>> obtenerEstudiantesAprobados()
        {
            return _context.People
                .Include(p => p.StudentGrades)
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .Where(p => p.StudentGrades.Any(g => g.Grade >= 3)) //de 3 o mas
                .Distinct() //remover duplicados
                .ToListAsync();
        }
    }
}
