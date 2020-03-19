using OnlineRealEstate.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineRealEstate.Models
{
    public class PropertyFeatureModel
    {
        [Required]
        public int ValueId { get; set; }
        [Required]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        [Required]
        public int PropertyFeatureId { get; set; }
        public PropertyFeature PropertyFeatures { get; set; }
        [Required]
        public int Value { get; set; }
    }
}