using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscuelaApp.Persistencia.Data;
using EscuelaApp.Persistencia.Repositorios;
using EscuelaApp.Dominio.Interfaces;

namespace EscuelaApp.Presentacion.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourses _repCourse; //inyeccion de dependencias reporsitorio
        private readonly IDepartments _repDepartment; 

        //EL CONTROLADOR NO DEBE TENER INYECCION DE DEPENDENCIAS DEL DB CONTEXT
        public CoursesController(ICourses repCourse,
            IDepartments repDepartment)
        {
            _repCourse = repCourse;
            _repDepartment = repDepartment;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            ////usamos el reporsitorio que ya fue inyectado en el controlador
            
            ///TODO: Cambiar a utilizar API
            return View(await _repCourse.obtenerTodo());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ///TODO: Cambiar a utilizar API
            var course = await _repCourse.obtenerCursoPorID(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _repDepartment.obtenerTodo(), "DepartmentId", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Title,Credits,DepartmentId")] Course course)
        {
            int res = 0;

            if (ModelState.IsValid)
            {
                //TODO: CAMBIAR A API
                res = await _repCourse.insertar(course);                           
                
                if (res == 1)
                {
                    TempData["Mensaje"] = "Curso Guardado Correctamente";
                    TempData["TipoMensaje"] = "alert-primary";
                }
                else if(res == 3)
                {
                    TempData["Mensaje"] = $"Error: El ID {course.CourseId} ya está registrado.";
                    TempData["TipoMensaje"] = "alert-danger";
                }
                else
                {
                    TempData["Mensaje"] = "Error: Curso no se ha guardado";
                    TempData["TipoMensaje"] = "alert-danger";
                }
                //RedirectToAction no sirve con viewbag o viewdata, se debe usar tempdata
                return RedirectToAction(nameof(Index)); //RedirectToAction llama la accion desde el controlador, return View es directamente a la vista
            }
            ViewData["DepartmentId"] = new SelectList(await _repDepartment.obtenerTodo(), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _repCourse.obtenerCursoPorID(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await _repDepartment.obtenerTodo(), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Title,Credits,DepartmentId")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //TODO: CAMBIAR A API
                int res = await _repCourse.modificar(course);

                if (res == 1)
                {
                    ViewBag.Mensaje = "Curso Guardado Correctamente";
                    ViewBag.TipoMensaje = "alert-primary";
                }
                else
                {
                    ViewBag.Mensaje = "Error: No se pudo modificar el curso";
                    ViewBag.TipoMensaje = "alert-danger";
                }
                //con view() se puede usar viewbag y viewdata, pero se debe especificar la vista
                //si no, se ira a la vista con el nombre de la accion 
                //el segundo parametro es el modelo que recibira la vista
                return View("Index", await _repCourse.obtenerTodo());
            }
            ViewData["DepartmentId"] = new SelectList(await _repDepartment.obtenerTodo(), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _repCourse.obtenerCursoPorID(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _repCourse.obtenerCursoPorID(id);
            
            if (course != null)
            {
                //TODO: CAMBIAR A API
                int res = await _repCourse.eliminar(course);
                if (res == 1)
                {
                    ViewBag.Mensaje = "Curso Eliminado Correctamente";
                    ViewBag.TipoMensaje = "alert-primary";
                }

                else
                {
                    ViewBag.Mensaje = "Error: No se pudo eliminar el curso";
                    ViewBag.TipoMensaje = "alert-danger";
                }
            }


            return View("Index", await _repCourse.obtenerTodo());
        }
    }
}
