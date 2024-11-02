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
    public class RepositorioDepartments : IDepartments
    {
        private readonly SchoolDBContext _context; //propiedad read only para inyeccion de dependencias

        public RepositorioDepartments(SchoolDBContext context) //por inyeccion de dependencias
        {
            _context = context;
        }

        public Task<int> eliminar(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChangesAsync();

        }

        public Task<int> insertar(Department department)
        {
            _context.Add(department);
            return _context.SaveChangesAsync();
        }

        public Task<int> modificar(Department department)
        {
            _context.Update(department);
            return _context.SaveChangesAsync();
        }

        public Task<Department?> obtenerPorID(int departmentId)
        {
            return _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentId == departmentId);
        }

        public Task<List<Department>> obtenerTodo()
        {
            return _context.Departments.ToListAsync();
        }
    }
}
