using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiSmart_ToDoList.Models;

namespace TiSmart_ToDoList1.Controllers
{
    public class ToDoListController : Controller
    {

        static List<ToDoListModel> todolistitems = new List<ToDoListModel>();
        // GET: ToDoListController
        public ActionResult Index()
        {            
            return View(todolistitems.ToList());
        }

        // GET: ToDoListController/Details/5
        public ActionResult Details(int id)
        {
            var item = todolistitems.Where(x => x.Id == id).SingleOrDefault();
            return View(item);
        }

        // GET: ToDoListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(ToDoListModel todolistcreate)
        {
            try
            {
                //return RedirectToAction(nameof(Index));
                if (!ModelState.IsValid)
                {

                    return View("Create", todolistcreate);
                }
                // lastid++; //intento de incremento
                //todolistcreate.Id = todolistitems.Count + 1;
                //todolistcreate.Id = todolistitems.LastOrDefault().Id + 1;
                if (todolistitems.LastOrDefault() != null)
                {
                    todolistcreate.Id = todolistitems.LastOrDefault().Id + 1;
                }
                else 
                {
                    todolistcreate.Id = 1; 
                }
                todolistitems.Add(todolistcreate);
                //ultimoid = todolistcreate.Id;

                return RedirectToAction("Index");

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

            var item = todolistitems.Where(x => x.Id == id).SingleOrDefault();

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
                // lastid++; //intento de incremento
                //todolistcreate.Id = lastid;
                //todolistitemedit.EstadoTarea = true;
                //todolistitems.Add(todolistitemedit);
                //ultimoid = todolistcreate.Id;

                var todolistitem = todolistitems.Where(s => s.Id == todolistitemedit.Id).FirstOrDefault();
                //todolistitems.Remove(todolistitem);
                
                todolistitem.Titulo = todolistitemedit.Titulo;
                todolistitem.EstadoTarea = todolistitemedit.EstadoTarea;

                if (todolistitem.EstadoTarea) todolistitem.FechaFin = DateTime.Now;

                //todolistitems.Add(todolistitemedit);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Delete/5
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

            var itemToRemove = todolistitems.Single(r => r.Id == id);
            todolistitems.Remove(itemToRemove);

            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            return RedirectToAction("Index");
            //}
        }


    }
}
