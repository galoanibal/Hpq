using Microsoft.AspNetCore.Mvc;
using PRUEBA.QPH.WEB.Controllers;

namespace PRUEBA_QPH_WEB.Controllers {
    public class HomeController : ApplicationControllerBase {
        public IActionResult Index()
        {
            
            if (IdUsuario==0) {
               return Redirect("/Login");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
