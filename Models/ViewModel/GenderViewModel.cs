using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class GenderViewModel
    {
        [Key]
        public int Id { get; set; }

               
        public string Gender { get; set; }

	
    }
}
