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
    public class TipoDocumentoController : Controller
    {
        ITipoDocumentoService TipoServ = new TipoDocumentoService();
        
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(TipoServ.FindAll());
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int id)
        {
            return View(TipoServ.FindById(id));
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        [HttpPost]
        public ActionResult Create(TipoDocumento collection)
        {
            bool rpta = TipoServ.insert(collection);

            if (rpta)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }


            TipoDocumento TipoD = TipoServ.FindById(id);

            return View(TipoD);
        }

        // POST: TipoDocumento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoDocumento collection)
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

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TipoDocumento TipoD = TipoServ.FindById(id);

            return View(TipoD);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TipoDocumento collection)
        {
            bool rpta = TipoServ.Delete(collection.TipoDocumentoId);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
