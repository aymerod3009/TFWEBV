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
    public class ContratoController : Controller
    {
        IContratoService ContratoSer = new ContratoService();
        IClienteService ClienteSer = new ClienteService();
        IInmobiliarioService InmobiliarioSer = new InmobiliarioService();
        
        // GET: Contrato
        public ActionResult Index()
        {
            ViewBag.ClienteSer = ClienteSer.FindAll();
            ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();
            return View(ContratoSer.FindAll());
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ClienteSer = ContratoSer.FindAll();
            ViewBag.InmobiliarioSer = ContratoSer.FindAll();

            return View(ContratoSer.FindById(id));
        }

        // GET: Contrato/Create
        public ActionResult Create()
        {
            ViewBag.ClienteSer = ClienteSer.FindAll();
            ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();
            return View();
        }

        // POST: Contrato/Create
        [HttpPost]
        public ActionResult Create(Contrato collection)
        {
            
                ViewBag.ClienteSer = ClienteSer.FindAll();
                ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();

            bool rpta = ContratoSer.insert(collection);

            if (rpta)
            {
                return RedirectToAction("Index");

            }            
            
                return View();
            
        }

        // GET: Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteSer = ClienteSer.FindAll();
            ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();

            Contrato Contract = ContratoSer.FindById(id);

            return View(Contract);
        }

        // POST: Contrato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contrato collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.ClienteSer = ClienteSer.FindAll();
            ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();

            bool rpta = ContratoSer.Update(collection);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteSer = ClienteSer.FindAll();
            ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();
            
            Contrato Contract = ContratoSer.FindById(id);

            return View(Contract);
        }

        // POST: Contrato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Contrato collection)
        {
            bool rpta = ContratoSer.Delete(collection.ContratoId);

            ViewBag.ClienteSer = ClienteSer.FindAll();
            ViewBag.InmobiliarioSer = InmobiliarioSer.FindAll();

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
