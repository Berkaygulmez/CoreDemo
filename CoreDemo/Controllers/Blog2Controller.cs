using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class Blog2Controller : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetList();//veritabanındaki verileri zaten burda çekmişsin

            return View(values);  //return view dedin ya onun içine verileri göndermen gerekiyor
        }
    }
}
