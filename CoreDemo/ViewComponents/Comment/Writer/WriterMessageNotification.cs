using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
