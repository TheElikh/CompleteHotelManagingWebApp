using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class ServiceModel
    {
        [Key]
        public int Id { get; set; }       

        [Required]
        public string Name { get; set; }

	    [Required]
	    public float Price { get; set; }

        
        [Required]
        [Display(Name ="Service Category")]
        public int ServiceCategoryId { get; set; }
        //public ServiceCatagoryViewModel ServiceCatgory { get; set; }

        public bool delete { get; set; } = false;
    }
}
