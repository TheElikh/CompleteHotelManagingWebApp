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

        // GET: Reserve/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveModel = await _context.Reserve
                .FirstOrDefaultAsync(m => m.Id == id);
            //loading data
            ReserveIndexViewModel reserveIndex = new ReserveIndexViewModel();
            reserveIndex.Id = reserveModel.Id;
            reserveIndex.GuestName = _context.Guests.Where(u => u.Id == reserveModel.GuestId).Where(m => m.delete == false).Select(u => u.Name).SingleOrDefault();
            reserveIndex.RoomName = _context.Rooms.Where(u => u.Id == reserveModel.RoomId).Where(m => m.delete == false).Select(u => u.RoomName).SingleOrDefault();
            reserveIndex.ReservationCode = reserveModel.ReservationCode;
            reserveIndex.CheckIn = reserveModel.CheckIn;
            reserveIndex.CheckOut = reserveModel.CheckOut;
            reserveIndex.Adults = reserveModel.Adults;
            reserveIndex.Children = reserveModel.Children;
            reserveIndex.NoOfNights = reserveModel.NoOfNights;

            if (reserveIndex == null)
            {
                return NotFound();
            }

            return View(reserveIndex);
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

                int roomtypeId =  _context.Rooms.FirstOrDefault(m=>m.Id==reserveModel.RoomId).RoomTypeId;


                //Standard or Single price
                double cost;
                if (reserveModel.Adults > 1 || reserveModel.Children > 1)
                {
                    var price = _context.RoomType.FirstOrDefault(m => m.Id == (roomtypeId));
                    cost = Convert.ToDouble(price.StandardPrice);
                }
                else
                {
                     var price = _context.RoomType.FirstOrDefault(m => m.Id == (roomtypeId));
                    cost = Convert.ToDouble(price.SinglePrice);
                }

                

                //Adding the cost into Bill table
                BillViewModel user = _context.Bill.FirstOrDefault(m => m.GuestId == reserveModel.GuestId);

                if (user == null)
                {
                    BillViewModel bill = new BillViewModel()
                    {
                        GuestId = reserveModel.GuestId,
                        ReservationCode = reserveModel.ReservationCode,
                        TotalBill = cost
                    };

                    _context.Bill.Add(bill);
                }
                else
                {
                    user.TotalBill += cost;
                }

                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            return View(reserveModel);
        }

        // GET: Reserve/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveModel = await _context.Reserve.FindAsync(id);
            if (reserveModel == null)
            {
                return NotFound();
            }
            return View(reserveModel);
        }

        // POST: Reserve/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GuestId,RoomId,ReservationCode,CheckIn,CheckOut,NoOfNights,Adults,Children")] ReserveModel reserveModel)
        {
            if (id != reserveModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserveModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveModelExists(reserveModel.Id))
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
            return View(reserveModel);
        }

        // GET: Reserve/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveModel = await _context.Reserve
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserveModel == null)
            {
                return NotFound();
            }

            return View(reserveModel);
        }

        // POST: Reserve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserveModel = await _context.Reserve.FindAsync(id);
            reserveModel.delete = true;
            _context.Update(reserveModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveModelExists(int id)
        {
            return _context.Reserve.Any(e => e.Id == id);
        }
    }
}
