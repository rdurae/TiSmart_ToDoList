using DbConServRef;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using ToDoList_WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList_WebApi.Controllers
{
    [Route("api/tareas")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        //public async Task<IEnumerable<string>> Get()
        //public async Task<ActionResult<ToDoListModel>> Get()
        public async Task<IEnumerable<ToDoListDataContract>> Get()
        {

            List<ToDoListDataContract> listatareas = new List<ToDoListDataContract>();
            Service1Client cliente = new Service1Client();

            var clientelista = await cliente.ConsultarAsync();

            foreach (var item in clientelista)
            {
                ToDoListDataContract tarea = new ToDoListDataContract()
                {

                    Id = item.Id,
                    Titulo = item.Titulo,
                    EstadoTarea = item.EstadoTarea,
                    FechaCreacion = item.FechaCreacion,
                    FechaFin = item.FechaFin,
                    Notas = item.Notas,
                    Prioridad = item.Prioridad,
                };
                listatareas.Add(tarea);
            }
            return listatareas;
        }
    }
}

            //List<ToDoListModel> tareas = new List<ToDoListModel>();

            //foreach (var item in lista)
            //{
            //    tarea.Id = item.Id;
            //    tarea.Titulo = item.Titulo;
            //    tarea.EstadoTarea = item.EstadoTarea;
            //    tarea.FechaCreacion = item.FechaCreacion;
            //    tarea.FechaFin = item.FechaFin;
            //    tarea.Notas = item.Notas;
            //    tarea.Prioridad = item.Prioridad;

            //    tareas.Add(tarea);
            //}

            //return tareas;
            //return new string[] { "value1", "value2" };
       // }

        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        