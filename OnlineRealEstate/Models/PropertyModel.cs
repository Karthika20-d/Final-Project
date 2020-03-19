using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineRealEstate.Models
{
    public class PropertyModel
    {
        [Required]
        public int PropertyId { get; set; }
        [Required(ErrorMessage = "Please enter property type")]
        [Display(Name = "Property Type")]
        public int PropertyTypeID { get; set; }
        [Required(ErrorMessage = "Please enter your location")]
        [Display(Name = "Location")]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string Location { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Area { get; set; }
    }
}