using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models.ViewModel
{
    public class BillViewModel
    {
        public int Id { get; set; }

        public int GuestId { get; set; }

        public int ReservationCode { get; set; }

        public double TotalBill { get; set; }

        public bool Paid { get; set; } = false;
    }
}
