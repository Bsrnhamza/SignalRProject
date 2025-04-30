using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.UI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default"); // varsayılan olarak "Default.cshtml" yüklenir
        }
    }

}
