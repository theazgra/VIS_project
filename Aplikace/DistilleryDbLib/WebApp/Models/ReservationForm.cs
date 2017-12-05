using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ReservationForm
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredDateMissing")]
        [DataType(DataType.DateTime)]
        public DateTime RequstedDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Material { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "MaterialAmountMissing")]
        [Range(0.0, 9999.9)]
        public double MaterialAmount { get; set; }

        public bool AvaibleDateTime { get; set; } = true;
    }
}

