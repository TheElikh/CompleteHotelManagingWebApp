using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class ReserveModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Guests")]
	    public int GuestId { get; set; }
	
	    [Required]
        [Display(Name = "Rooms")]
        public int RoomId { get; set; }  
	
        [Required]
	    public int ReservationCode { get; set; }

        [Required]
        [Display(Name = "Checkin Date")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }
	
        [Required]
        [Display(Name = "Checkout Date")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }
	
	    [Required]
        [Display(Name = "Nights")]
        public int NoOfNights { get; set; }

	    [Required]
	    public int Adults {get; set;}
	
	    [Required]
	    public int Children {get; set;}

        public bool delete { get; set; } = false;

        public bool ConfirmChekout { get; set; } = false;
    }
}
