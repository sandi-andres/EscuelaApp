using EscuelaApp.Dominio.Interfaces;
using EscuelaApp.Persistencia.Data;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EscuelaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourses _repCourse;

        public CourseController(ICourses repCourse)
        {
            _repCourse = repCourse;
        }

        // GET: api/<CourseController>
        [HttpGet] //indica el tipo de metodo de acceso al endpoint
        [Route("ObtenerTodo")] //parametro permite especificar el nombre del elemento que queremos extraer
        // por lo que para acceder seria GET: api/obtenerTodo
        public async Task<ActionResult> ObtenerTodo()
        {
            //TODO: verificar por que da error de json cuando se retorne la lista
            var res = await _repCourse.obtenerTodo();
            
            return Ok(new {resultado = "1"});
        }

        // GET api/obtenerPorId/5
        [HttpGet]
        [Route("ObtenerPorId")]
        public async Task<ActionResult> ObtenerPorId(int id)
        {            
            return StatusCode(200, new { resultado = await _repCourse.obtenerCursoPorID(id)});
        }

        // POST api/guardarCurso
        [HttpPost]
        [Route("GuardarCurso")]
        public async Task<ActionResult> GuardarCurso(int id, [FromBody] Course course)
        {
            return Ok(new { resultado = await _repCourse.insertar(course) });
        }

        // PUT api/actualizarCurso/5
        [HttpPut]
        [Route("ActualizarCurso")]
        public async Task<ActionResult> ActualizarCurso(int id, [FromBody] Course course)
        {
            return Ok(new { resultado = await _repCourse.modificar(course) });
        }

        // DELETE api/borrarCurso/5
        [HttpDelete]
        [Route("BorrarCurso")]
        public async Task<ActionResult> BorrarCurso([FromBody] Course course)
        {
            return Ok(new { resultado = await _repCourse.eliminar(course) });
        }
    }
}