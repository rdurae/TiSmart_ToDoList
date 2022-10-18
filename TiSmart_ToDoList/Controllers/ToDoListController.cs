using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiSmart_ToDoList.Data;
using TiSmart_ToDoList.Models;

namespace TiSmart_ToDoList.Controllers
{
    public class ToDoListController : Controller
    {

        
        //ToDoListAdmin admin = new ToDoListAdmin();
        ToDoListAdmin todolistitems = new ToDoListAdmin();
        //static List<ToDoListModel> todolistitems = new List<ToDoListModel>();

        // GET: ToDoListController
        //public ActionResult Index()
        //{
        //    //IEnumerable<ToDoListModel> todolistitems = admin.Consultar();
        //    //  IEnumerable<ToDoListModel> lista = admin.Consultar();
        //    //static List<ToDoListModel> todolistitems = new List<ToDoListModel>();
        //    //IEnumerable<ToDoListModel> todolistitems = admin.Consultar();

        //    var lista = todolistitems.Consultar().ToList();


        //        return View(lista);

        //}
        
        public ActionResult Index(string id)
        {
            //IEnumerable<ToDoListModel> todolistitems = admin.Consultar();
            //  IEnumerable<ToDoListModel> lista = admin.Consultar();
            //static List<ToDoListModel> todolistitems = new List<ToDoListModel>();
            //IEnumerable<ToDoListModel> todolistitems = admin.Consultar();

            var lista = todolistitems.Consultar();

            if(!String.IsNullOrEmpty(id))
            {
                lista = lista.Where(i => i.Prioridad == int.Parse(id));
            }

            
            return View(lista);

        }

        // GET: ToDoListController/Details/5
        // sin procedimiento almacenado
        public ActionResult Details(int id)
        {
            var item = todolistitems.Consultar().ToList().Where(x => x.Id == id).SingleOrDefault();
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
        ////public ActionResult Create(IFormCollection collection)
        public ActionResult Create(ToDoListModel todolistcreate)
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
                    todolistitems.Guardar(todolistcreate);
                    return RedirectToAction("Index");
                }

                // lastid++; //intento de incremento
                //todolistcreate.Id = todolistitems.Count + 1;
                //todolistcreate.Id = todolistitems.LastOrDefault().Id + 1;
                //if (todolistitems.LastOrDefault() != null)
                //{
                //    todolistcreate.Id = todolistitems.LastOrDefault().Id + 1;
                //}
                //else
                //{
                //    todolistcreate.Id = 1;
                //}
                //todolistitems.Add(todolistcreate);
                //ultimoid = todolistcreate.Id;

                //return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }


        }

        // GET: ToDoListController/Edit/5
        public ActionResult Edit(int id)
        {
            // var item = todolistitems.Where(x => x.Id == id).SingleOrDefault();
            // return View(item);
            //Instancia de objeto segun id

            //todolistitems listaitem = db.Movies.Find(id);
            //if (todolistitem == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(todolistitem);

            //var item = todolistitems.Where(x => x.Id == id).SingleOrDefault();
            var item = todolistitems.Consultar().ToList().Where(x => x.Id == id).SingleOrDefault();
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
        public ActionResult Edit(ToDoListModel todolistitemedit)
        {
            try
            {
                //return RedirectToAction(nameof(Index));
                if (!ModelState.IsValid)
                {

                    return View("Edit", todolistitemedit);
                }
                else
                {
                    if (todolistitemedit.EstadoTarea) todolistitemedit.FechaFin = DateTime.Now;
                    todolistitems.Modificar(todolistitemedit);
                    return RedirectToAction("Index");
                }
                // lastid++; //intento de incremento
                //todolistcreate.Id = lastid;
                //todolistitemedit.EstadoTarea = true;
                //todolistitems.Add(todolistitemedit);
                //ultimoid = todolistcreate.Id;

                //var todolistitem = todolistitems.Where(s => s.Id == todolistitemedit.Id).FirstOrDefault();
                ////todolistitems.Remove(todolistitem);

                //todolistitem.Titulo = todolistitemedit.Titulo;
                //todolistitem.EstadoTarea = todolistitemedit.EstadoTarea;
                //todolistitem.Notas = todolistitemedit.Notas;
                //todolistitem.Prioridad = todolistitemedit.Prioridad;

                //if (todolistitem.EstadoTarea) todolistitem.FechaFin = DateTime.Now;

                //todolistitems.Add(todolistitemedit);



            }
            catch
            {
                return View();
            }
        }

        //GET: ToDoListController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ToDoListController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            //var item = todolistitems.RemoveAt(x => x.Id == id).SingleOrDefault();

            //var itemToRemove = todolistitems.Single(r => r.Id == id);
            //todolistitems.Remove(itemToRemove);

            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{

            todolistitems.Eliminar(id);
            return RedirectToAction("Index");
            //}
        }



    }
}
