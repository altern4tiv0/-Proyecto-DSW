using Microsoft.AspNetCore.Mvc;

namespace PrjEcommersProyect.ViewComponents
{
    public class CartCounterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int cartCounter = HttpContext.Session.GetInt32("ContadorCarrito") ?? 0;
            return View(cartCounter); // Pasamos el contador directamente a la vista del componente
        }
    }
}
