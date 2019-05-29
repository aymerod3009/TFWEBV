using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;
namespace WALimaRoomsV3._5.Controllers
{
    public class TipoInmobiliarioController : Controller
    {
        private ITipoInmobiliarioService TipoServ = new TipoInmobiliarioService();
        private IInmobiliarioService inmobiliarioServ = new InmobiliarioService();
        // GET: TipoInmobiliario
        public ActionResult Index()
        {
            return View(TipoServ.FindAll());
        }

        // GET: TipoInmobiliario/Details/5
        public ActionResult Details(int id)
        {
            return View(TipoServ.FindById(id));
        }

        // GET: TipoInmobiliario/Create
        public ActionResult Create()
        {
            ViewBag.TipoInmobiliario = TipoServ.FindAll();
            return View();
        }

        // POST: TipoInmobiliario/Create
        [HttpPost]
        public ActionResult Create(TipoInmobiliario collection)
        {
            ViewBag.Inmobiliario = inmobiliarioServ.FindAll();
            bool rpta = TipoServ.insert(collection);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
                
                return View();
            
        }

        // GET: TipoInmobiliario/Edit/5
        public ActionResult Edit(int? id)  
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            

            TipoInmobiliario TipoI = TipoServ.FindById(id);

            return View(TipoI);
        }

        // POST: TipoInmobiliario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoInmobiliario collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            bool rpta = TipoServ.Update(collection);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: TipoInmobiliario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TipoInmobiliario TipoI = TipoServ.FindById(id);
            

            return View(TipoI);
        }

        // POST: TipoInmobiliario/Delete/5
        [HttpPost]
        public ActionResult Delete(TipoInmobiliario tp)
        {
            bool rpta = TipoServ.Delete(tp.TipoInmobiliarioId);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
