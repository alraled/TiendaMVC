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
    public class EtiquetaController : Controller
    {
        private tiendaluisEntities db =
            new tiendaluisEntities();

        protected override void OnActionExecuting                         // ESTO ES PRIVADO Y SE APLICA A TODAS LAS VISTAS //
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

        // GET: Etiquetas

        [Hora]                               //ESTO ES PUBLICO Y SOLO PARA UNA VISTA //
        public ActionResult Index()
        {
            var info = db.Almacen;

            ViewBag.almacenes = info.ToList();

            ViewData["Titulo"] = "Etiquetas";



            var data = db.Etiqueta;
            return View(data.ToList());
        }
    }
}