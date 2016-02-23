using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace TiendaMvc.Filtros
{
    public class Filtroid : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String id = null;
            try
            {
                id = filterContext.ActionParameters["id"].ToString();
            }
            catch (Exception)
            {
                
                
            }
            var pet = filterContext.ActionDescriptor.ActionName;
            if (id == null && pet != "Index")
            {
                filterContext.Result = new EmptyResult();
            }

            base.OnActionExecuting(filterContext);



        }


    }
}
