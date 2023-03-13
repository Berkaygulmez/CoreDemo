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

//using ValidationResult = FluentValidation.Results.ValidationResult; //bune lan

namespace CoreDemo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writervaleus = wm.TGetById(1);
            return View(writervaleus);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
           
            WriterValidator wl = new WriterValidator(); 
            ValidationResult result = wl.Validate(p);
            if (result.IsValid) 
            {          
                wm.TUpdate(p); 
                return RedirectToAction("Index", "Dashboard");
            }
            else 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }            
            }

            return View();

        }
    }
}
