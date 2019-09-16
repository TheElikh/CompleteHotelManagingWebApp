using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class GuestsModel
    {
        [Key]
        public int Id { get; set; }
        

        [Required]
        [Column(Order=1)]
        [StringLength(30)]
        public string Name { get; set; }

	    [Required]
        [Column(Order=2)]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        //public GenderViewModel Gender { get; set; }


        [Required]
        [Column(Order=3)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

	    [Required]
        [Column(Order=4)]
        [StringLength(30)]
        public string City { get; set; }

    
	    [Required]
        [Column(Order=5)]
        [StringLength(30)]
        public string Country { get; set; }
	
	    [Required]
        [Column(Order=6)]
        public string NICno { get; set; }
	
        [Required]
        [Column(Order=7)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{5})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNo { get; set; }

        [Column(Order=8)]
        public string Address { get; set; }

        public bool delete { get; set; } = false;
    }
}
