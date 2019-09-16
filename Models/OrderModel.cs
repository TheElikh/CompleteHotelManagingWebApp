using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Today.Date;

        [Display(Name ="Employee")]
        public int EmployeeId { get; set; }

        [Display(Name = "Room no")]
        public int GuestId { get; set; }

        public int ReservationCode { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public bool paid { get; set; } = false;

    }
}