using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Classes
{
    public class City
    {
        public int Id { get; set; }
        public int District_Id { get; set; }
        public int Region_Id { get; set; }
        public string name { get; set; }
        public string zipCode { get; set; }
        public string nameZip { get { return name + " " + zipCode; } }
        public District District { get; set; }
        public Region Region { get; set; }
       
    }
}
