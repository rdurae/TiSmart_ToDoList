using Microsoft.AspNetCore.Mvc;
using TiSmart_ToDoList.Models;
using DbConnServReference;

namespace TiSmart_ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        Service1Client cliente = new Service1Client();

        public async Task<ActionResult> Index(string id)
        {

            var lista = await cliente.ConsultarAsync();
             
            
            if (!String.IsNullOrEmpty(id))
            {
                var listafiltrada = lista.ToList().Where(i => i.Prioridad == int.Parse(id));
                return View(listafiltrada);
                //lista = lista.Where(i => i.Prioridad == int.Parse(id));
            }
            return View(lista);

        }

        //GET: ToDoListController/Details/5
        // sin procedimiento almacenado
        public async Task<ActionResult> Details(int id)
        {
            var lista = await cliente.ConsultarAsync();
            var item = lista.ToList().Where(x => x.Id == id).SingleOrDefault();

            return View(item);
        }

        //GET: ToDoListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoListDataContract todolistcreate)
        {
            try
            {
                //return RedirectToAction(nameof(Index));
                if (!ModelState.IsValid)
                {
                    return View("Create", todolistcreate);
                }
                else
                {
                    if (todolistcreate.EstadoTarea) todolistcreate.FechaFin = DateTime.Now;

                    await cliente.GuardarAsync(todolistcreate);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }


        }

        // GET: ToDoListController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //var item = todolistitems.Consultar().ToList().Where(x => x.Id == id).SingleOrDefault();
            var lista = await cliente.ConsultarAsync();
            var item = lista.ToList().Where(x => x.Id == id).SingleOrDefault();
            if (item.EstadoTarea == false)
            {
                return View(item);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: ToDoListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoListDataContract todolistitemedit)
        {
            try
            {

                if (!ModelState.IsValid)
                {

                    return View("Edit", todolistitemedit);
                }
                else
                {
                    if (todolistitemedit.EstadoTarea) todolistitemedit.FechaFin = DateTime.Now;
                    await cliente.ModificarAsync(todolistitemedit);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        ////GET: ToDoListController/Delete/5
        ////public ActionResult Delete(int id)
        ////{
        ////    return View();
        ////}

        // POST: ToDoListController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await cliente.EliminarAsync(id);
            return RedirectToAction("Index");
        }
    }
}
