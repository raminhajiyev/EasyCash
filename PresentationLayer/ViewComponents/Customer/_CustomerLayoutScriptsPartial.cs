using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
