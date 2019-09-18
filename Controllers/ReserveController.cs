using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Models.ViewModel;

namespace HotelManagementSystem.Controllers
{
    public class ReserveController : Controller
    {
        private readonly HotelContext _context;

        public ReserveController(HotelContext context)
        {
            _context = context;
        }

        // GET: Reserve
        public async Task<IActionResult> Index()
        {
            List<ReserveModel> reserve = new List<ReserveModel>();
            List<ReserveIndexViewModel> ReserveViewList = new List<ReserveIndexViewModel>();
            reserve =  _context.Reserve.ToList();
            foreach(var i in reserve)
            {
                ReserveIndexViewModel reserveIndex = new ReserveIndexViewModel();
                reserveIndex.Id = i.Id;
                reserveIndex.GuestName = _context.Guests.Where(u => u.Id == i.GuestId).Where(m => m.delete == false).Select(u => u.Name).SingleOrDefault();
                reserveIndex.RoomName = _context.Rooms.Where(u => u.Id == i.RoomId).Where(m => m.delete == false).Select(u => u.RoomName).SingleOrDefault();
                reserveIndex.ReservationCode = i.ReservationCode;
                reserveIndex.CheckIn = i.CheckIn;
                reserveIndex.CheckOut = i.CheckOut;
                reserveIndex.Adults = i.Adults;
                reserveIndex.Children = i.Children;
                reserveIndex.NoOfNights = i.NoOfNights;
                ReserveViewList.Add(reserveIndex);
            }
            return View(ReserveViewList);
        }

        

        // GET: Reserve/Create
        public IActionResult Create()
        {
            ViewBag.guest = _context.Guests.Where(m => m.delete == false).ToList();
            ViewBag.room = _context.Rooms.Where(m => m.delete == false && m.Available==true).ToList();

            return View();
        }

        // POST: Reserve/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GuestId,RoomId,ReservationCode,CheckIn,CheckOut,NoOfNights,Adults,Children")] ReserveModel reserveModel)
        {
            ViewBag.guest = _context.Guests.Where(m => m.delete == false).ToList();
            ViewBag.room = _context.Rooms.Where(m => m.delete == false && m.Available == true).ToList();

            if (ModelState.IsValid)
            {
                _context.Add(reserveModel);

                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            return View(reserveModel);
        }

       
    }
}
