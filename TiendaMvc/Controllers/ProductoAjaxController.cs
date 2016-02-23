using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class ProductoAjaxController : Controller
    {

        tiendaluisEntities db = new tiendaluisEntities();
        
        // GET: ProductoAjax
        public ActionResult Index()
        {
            return View(db.Producto);
        }



        [OutputCache(Duration = 0,VaryByParam = "*")]

        public ActionResult Buscar(String nombre)                       // ESTO ES PARA CREAR UNA PETICION AJAX Y QUE FUNCIONE LA BÚSQUEDA //
        {
            var data = db.Producto.Where(o => o.nombre.Contains(nombre));

            return PartialView("_listadoProducto", data);
        }


        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            db.Producto.Add(model);
            db.SaveChanges();
            return Json(model);
        }

    }
}