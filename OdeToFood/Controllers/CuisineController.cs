using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        [Authorize]
        public ActionResult Search(string name = "french")
        {
            var messge = Server.HtmlEncode(name);
            return Content(messge);
        }


    }
}
