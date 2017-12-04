using System;

namespace DistilleryDbLib.Classes
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Material_Id { get; set; }
        public double MaterialAmount { get; set; }
        public Customer Customer { get; set; }
        public Material Material { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public DateTime ReservationDateTime { get; set; }
        //public bool ActiveReservation { get; set; }
    }
}
