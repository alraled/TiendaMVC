using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Filtros;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class AlmacenController : Controller
    {
        private tiendaluisEntities db=
            new tiendaluisEntities();

        protected override void OnActionExecuting
            (ActionExecutingContext filterContext)
        {
            String id = null;
            try
            {
                id = filterContext.ActionParameters["id"].ToString();
            }
            catch (Exception)
            {

            }
            //var pet = filterContext.ActionDescriptor.ActionName;
            //if (id ==null && pet!="Index")
            //{
            //    filterContext.Result=new EmptyResult();
            //}

            //base.OnActionExecuting(filterContext);
        }

        // GET: Almacen
        public ActionResult Index()
        {
            var info = db.Etiqueta;

            ViewBag.etiquetas = info.ToList();    
            ViewData["Titulo"] = "Listado de almacenes";

            var data = db.Almacen;
            return View(data);
        }

        [Filtroid]
        public ActionResult Modificar(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State=EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);

        }

        [Filtroid]
        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);

            if (data.ProductoAlmacen.Any())
                db.ProductoAlmacen.RemoveRange(data.ProductoAlmacen);

            db.Almacen.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}