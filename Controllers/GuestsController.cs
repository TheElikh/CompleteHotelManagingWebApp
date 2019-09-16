using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class GuestsController : Controller
    {
        private readonly HotelContext _context;

        public GuestsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guests.Where(m => m.delete == false).ToListAsync());
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestsModel = await _context.Guests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestsModel == null)
            {
                return NotFound();
            }

            return View(guestsModel);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            ViewBag.gender = _context.Gender.ToList();
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,GenderId,Email,City,Country,NICno,PhoneNo,Address")] GuestsModel guestsModel)
        {
            ViewBag.gender = _context.Gender.ToList();
            if (ModelState.IsValid)
            {
                _context.Add(guestsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(guestsModel);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestsModel = await _context.Guests.FindAsync(id);
            if (guestsModel == null)
            {
                return NotFound();
            }
            return View(guestsModel);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemeberCode,Name,Email,City,Country,NICno,PhoneNo,Address")] GuestsModel guestsModel)
        {
            if (id != guestsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestsModelExists(guestsModel.Id))
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
            return View(guestsModel);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestsModel = await _context.Guests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestsModel == null)
            {
                return NotFound();
            }

            return View(guestsModel);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestsModel = await _context.Guests.FindAsync(id);
            guestsModel.delete = true;
            _context.Update(guestsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestsModelExists(int id)
        {
            return _context.Guests.Any(e => e.Id == id);
        }
    }
}
