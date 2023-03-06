using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
