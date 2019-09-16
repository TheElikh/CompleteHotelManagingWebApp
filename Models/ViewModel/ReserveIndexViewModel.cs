using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models.ViewModel
{
    public class ReserveIndexViewModel
    {
        
        public int Id { get; set; }
        
        public string GuestName { get; set; }

        public string RoomName { get; set; }

        public int ReservationCode { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }

        public int NoOfNights { get; set; }
        
        public int Adults { get; set; }
        
        public int Children { get; set; }


    }
}
