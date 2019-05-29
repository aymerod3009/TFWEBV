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
    public class InmobiliarioController : Controller
    {
        IInmobiliarioService InmobiliarioServ = new InmobiliarioService();
        ITipoInmobiliarioService TipoServ = new TipoInmobiliarioService();

        // GET: Inmobiliario
        public ActionResult Index()
        {
            return View(InmobiliarioServ.FindAll());
        }

        // GET: Inmobiliario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inmobiliario/Create
        public ActionResult Create()
        {
            ViewBag.TipoInmobiliario = TipoServ.FindAll();
            return View();
        }

        // POST: Inmobiliario/Create
        [HttpPost]
        public ActionResult Create(Inmobiliario collection)
        {
            ViewBag.TipoInmobiliario = TipoServ.FindAll();
            bool rpta = InmobiliarioServ.insert(collection);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            
            
                return View();
            
        }

        // GET: Inmobiliario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inmobiliario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inmobiliario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inmobiliario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
