using EscuelaApp.Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Dominio.Interfaces
{
    public interface IDepartments
    {
        //Insertar
        public Task<int> insertar(Department department);

        //Modificar
        public Task<int> modificar(Department department);

        //Eliminar
        public Task<int> eliminar(Department department);

        //Consultar(ID)
        public Task<Department?> obtenerPorID(int DepartmentId);

        //Consultar Todo
        public Task<List<Department>> obtenerTodo();
    }
}
