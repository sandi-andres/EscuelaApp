using EscuelaApp.Dominio.Interfaces;
using EscuelaApp.Persistencia.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaApp.API.Controllers
{
    public class APIStudentGradesController : Controller
    {
        private readonly IStudentGrades _repStudentGrades;

        public APIStudentGradesController(IStudentGrades repStudentGrades)
        {
            _repStudentGrades = repStudentGrades;
        }

        // GET: APIStudentGradesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: APIStudentGradesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: APIStudentGradesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APIStudentGradesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: APIStudentGradesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: APIStudentGradesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: APIStudentGradesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: APIStudentGradesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        //Laboratorio Punto 1. Numero de estudiantes aprobados y reprobados.
        [HttpGet]
        [Route("ObtenerNumEstudiantesAprobados")]
        public async Task<ActionResult> ObtenerNumEstudiantesAprobados()
        {
            var res = await _repStudentGrades.obtenerNumEstudiantesAprobados();
            return Ok(new { resultado = res });
        }

        [HttpGet]
        [Route("ObtenerNumEstudiantesReprobados")]
        public async Task<ActionResult> ObtenerNumEstudiantesReprobados()
        {
            var res = await _repStudentGrades.obtenerNumEstudiantesReprobados();
            return Ok(new { resultado = res });
        }

        //Laboratorio Punto 2. Los datos de los estudiantes con las 3 mejores notas. 

        [HttpGet]
        [Route("obtenerEstudiantesNotasTop3")]
        public async Task<ActionResult> ObtenerEstudiantesNotasTop3()
        {
            var res = await _repStudentGrades.obtenerEstudiantesNotasTop3();
            return Ok(new { resultado = res });
        }


        //Laboratorio Punto 3. Los datos de los estudiantes con las 3 notas más bajas. 
        [HttpGet]
        [Route("ObtenerEstudiantesNotasPeores3")]
        public async Task<ActionResult> ObtenerEstudiantesNotasPeores3()
        {
            var res = await _repStudentGrades.obtenerEstudiantesNotasPeores3();
            return Ok(new { resultado = res });
        }

        //Laboratorio Punto 6. Obtener el promedio de notas de un estudiante entre todos sus cursos.
        [HttpGet]
        [Route("ObtenerPromedioxEstudiante")]
        public async Task<ActionResult> ObtenerPromedioxEstudiante(int personId)
        {
            var res = await _repStudentGrades.obtenerPromedioxEstudiante(personId);
            return Ok(new { resultado = res });
        }

        
    }
}
