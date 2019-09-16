using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class RoomModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(Order=1)]
        [StringLength(30)]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }
	
	    [Required]
        [Column(Order = 2)]
        public int BuildingNo { get; set; }


        [Required]
        [Column(Order = 3)]
        [Display(Name = "Status")]
        public bool Available { get; set; } = true;
       
        

        [Required]
        [Column(Order = 4)]
        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }
        //public RoomTypeViewModel RoomTypeView { get; set; }

        public bool delete { get; set; } = false;

    }
}
