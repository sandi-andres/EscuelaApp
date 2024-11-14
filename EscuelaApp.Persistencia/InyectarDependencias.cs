using EscuelaApp.Dominio.Interfaces;
using EscuelaApp.Persistencia.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaApp.Persistencia
{
    public class InyectarDependencias 
    //clase para inyectar dependencias para no ingresarlas directamente en Program.cs
    {
        public static void ConfiguracionServicios(IServiceCollection servicios)
        {
            //Inyeccion de dependencia:

            //AddSingleton => cuando se crea la primera instancia de una clase,
            //esa instancia se mantiene en memoria. Cuando otros elementos pidan
            //inyectar esa clase, se les va a dar la misma instancia. Se utiliza
            //principalmente cuando no se requieran datos especificos de la solicitud.
            //Single un objeto debe ser compartido por varios usuarios, se puede utilizar este Add.

            //AddScoped => crea una instancia diferente de la clase por cada solicitud
            //son independientes y no se comparten entre si. idea para trabajar con servicios
            //de base de datos como en este proyecto porque si se utiliza la misma instancia
            //y hay multiples peticiones a base de datos, el servidor puede empezar a rechazarlas

            //AddTransient => Se crea una instancia cada vez que hay una peticion se crea una
            //solicitud nueva. Solo se recomienda para servicios livianos.

            //una interfaz solo se vincula a un repositorio
            servicios.AddScoped<ICourses, RepositorioCourses>(); //metodo para inyectar, se usa en Program.cs
            servicios.AddScoped<IDepartments, RepositorioDepartments>();
            servicios.AddScoped<IPerson, RepositorioPerson>();  
            servicios.AddScoped<IStudentGrades, RepositorioStudentGrades>();    
        }
    }
}
