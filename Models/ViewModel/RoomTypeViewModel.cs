using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class RoomTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]	
        [StringLength(30)]
        public string Name { get; set; }   
      	
        [Required]
        public float StandardPrice { get; set; }

        [Required]
        public float SinglePrice { get; set; }

	    [Required]
	    public int Adults {get; set;}
	
	    [Required]
	    public int Children {get; set;}
	
    }
}
