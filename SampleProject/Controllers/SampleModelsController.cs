using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleProject.Data;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class SampleModelsController : Controller
    {
        private readonly SampleProjectContext _context;

        public SampleModelsController(SampleProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleModel.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel
                .FirstOrDefaultAsync(m => m.name == id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return View(sampleModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SampleModel sampleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel.FindAsync(id);
            if (sampleModel == null)
            {
                return NotFound();
            }
            return View(sampleModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SampleModel sampleModel)
        {
            if (id != sampleModel.name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleModelExists(sampleModel.name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sampleModel);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel
                .FirstOrDefaultAsync(m => m.name == id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return View(sampleModel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sampleModel = await _context.SampleModel.FindAsync(id);
            _context.SampleModel.Remove(sampleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleModelExists(string id)
        {
            return _context.SampleModel.Any(e => e.name == id);
        }

         public async Task<IActionResult> CreateByAjax(SampleModel sampleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
    }
}
