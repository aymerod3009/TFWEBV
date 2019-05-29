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
    public class ClienteController : Controller
    {
        IClienteService Cliente = new ClienteService();
        ITipoDocumentoService TipoDocumento = new TipoDocumentoService();
        
       
        // GET: Cliente
        public ActionResult Index()
        {
            
            return View(Cliente.FindAll());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.TipoDocumento = TipoDocumento.FindAll();

            return View(Cliente.FindById(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumento = TipoDocumento.FindAll();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente c)
        {
      
                // TODO: Add insert logic here
                ViewBag.TipoDocumento = TipoDocumento.FindAll();

                bool rpta = Cliente.insert(c);
                

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            
                return View();
            
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumento = TipoDocumento.FindAll();

            Cliente cientee = Cliente.FindById(id);

            return View(cientee);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente collection)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.TipoDocumento = TipoDocumento.FindAll();
            bool rpta = Cliente.Update(collection);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cliente cliente = Cliente.FindById(id);
            ViewBag.TipoDocumento = TipoDocumento.FindAll();

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente collection)
        {
            bool rpta = Cliente.Delete(collection.ClienteId);
            ViewBag.TipoDocumento = TipoDocumento.FindAll();
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        
        }
    }
}
