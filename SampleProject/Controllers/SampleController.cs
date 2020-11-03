using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            SampleModel book = new SampleModel()
            {
               
            };
            return View(book);
        }
    

        public string Details()
        {
            return "This is the details of a book.";
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SampleModel sampleModel)
        {
            if (ModelState.IsValid)
            {
                // Logic to add the book to DB
                return RedirectToAction("Index");
            }
            return View(sampleModel);
        }
    }
}
