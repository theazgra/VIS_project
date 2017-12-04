using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ReservationForm
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RequstedDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Material { get; set; }

        [Required]
        [Range(0.0, 9999.9)]
        public double MaterialAmount { get; set; }
    }
}

