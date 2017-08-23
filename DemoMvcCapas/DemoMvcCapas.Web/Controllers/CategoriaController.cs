using DemoMvcCapas.BusinessEntities;
using DemoMvcCapas.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvcCapas.Web.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBL categoriaBL = new CategoriaBL();

        // GET: Categoria
        public ActionResult Index()
        {
            return View(categoriaBL.GetAll());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View(categoriaBL.Get(id));
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CategoriaBE entity = new CategoriaBE();
                entity.Nombre = collection["Nombre"];
                entity.Descripcion = collection["Descripcion"];
                // TODO: Add insert logic here
                categoriaBL.Insert(entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaBE categoriaBE = categoriaBL.Get(id);
            return View(categoriaBE);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CategoriaBE entity = new CategoriaBE();
                entity.IdCategoria = id;
                entity.Nombre = collection["Nombre"];
                entity.Descripcion = collection["Descripcion"];
                // TODO: Add insert logic here
                categoriaBL.Update(entity);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaBE categoriaBE = categoriaBL.Get(id);
            return View(categoriaBE);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                categoriaBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
