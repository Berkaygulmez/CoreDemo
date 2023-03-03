    using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class Blog2Controller : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();//veritabanındaki verileri zaten burda çekmişsin

            return View(values);  //return view dedin ya onun içine verileri göndermen gerekiyor
        }
        public IActionResult BlogReadAll(int id )
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
    }
}
