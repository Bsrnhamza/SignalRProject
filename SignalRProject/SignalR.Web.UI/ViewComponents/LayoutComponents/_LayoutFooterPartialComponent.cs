﻿using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.UI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}
