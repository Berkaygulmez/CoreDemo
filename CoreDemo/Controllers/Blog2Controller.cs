using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class Blog2Controller : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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
        public IActionResult BlogListByWriter()
        {
          var values =  bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList() ;
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog2");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }             
            }

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p, int id) 
        {
            p.BlogID = id;  
            p.WriterID = 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
