using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PRUEBA.QPH.WEB.Models;
using System.Diagnostics;

namespace PRUEBA.QPH.WEB.Controllers {
    public class ErrorController : Controller {
        [Route("Error/500")]
        public IActionResult InternalError()
        {
            var errorModel = new ErrorViewModel();
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                errorModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                errorModel.ExceptionMessage = exceptionFeature.Error.Message;
                errorModel.DescriptionDetail = exceptionFeature.Path;
            }

            return View(errorModel);
        }

        [Route("Error/404")]
        public IActionResult ErrorNoFound()
        {
            var errorModel = new ErrorViewModel();
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                errorModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                errorModel.ExceptionMessage = exceptionFeature.Error.Message;
                errorModel.DescriptionDetail = exceptionFeature.Path;
            }

            return View(errorModel);
        }
    }
}
