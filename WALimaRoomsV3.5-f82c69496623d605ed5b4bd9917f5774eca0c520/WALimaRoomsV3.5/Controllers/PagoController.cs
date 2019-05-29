using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;
using Entity;

namespace WALimaRoomsV3._5.Controllers
{
    public class PagoController : Controller
    {
        IPagoService Pagoserv = new PagoService();
        IContratoService ContratoServ = new ContratoService();
        // GET: Pago
        public ActionResult Index()
        {
            return View(Pagoserv.FindAll());
        }

        // GET: Pago/Details/5
        public ActionResult Details(int id)
        {            
            return View(Pagoserv.FindById(id));
        }

        // GET: Pago/Create
        public ActionResult Create()
        {
            ViewBag.ContratoServ = ContratoServ.FindAll();
            return View();
        }

        // POST: Pago/Create
        [HttpPost]
        public ActionResult Create(Pago collection)
        {
            ViewBag.ContratoServ = ContratoServ.FindAll();

            bool rpta = Pagoserv.insert(collection);
                

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            
                return View();
        }

        // GET: Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoServ = ContratoServ.FindAll();
            
            Pago Pagoo = Pagoserv.FindById(id);

            return View(Pagoo);
        }

        // POST: Pago/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pago collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.ContratoServ = ContratoServ.FindAll();
            bool rpta = Pagoserv.Update(collection);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Pago pagoo = Pagoserv.FindById(id);
            ViewBag.ContratoServ = Pagoserv.FindAll();

            return View(pagoo);
        }

        // POST: Pago/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pago collection)
        {
            bool rpta = Pagoserv.Delete(collection.PagoId);
            ViewBag.ContratoServ = Pagoserv.FindAll();
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
