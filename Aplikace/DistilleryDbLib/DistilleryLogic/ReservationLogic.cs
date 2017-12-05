using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistilleryLogic
{
    public class ReservationLogic
    {
        public static bool IsDateTimeAvaible(DateTime requesteDateTime)
        {
            IDatabase db = Configuration.GetDatabase();

            ICollection<Reservation> reservations = db.SelectAll(new Reservation());

            int reservationInRequestedPeriod = reservations.Count(
                r => (r.RequestedDateTime > DateTime.Now) &&
                        ((r.RequestedDateTime > requesteDateTime.AddHours(-2)) && (r.RequestedDateTime <= requesteDateTime)) ||
                        ((r.RequestedDateTime > requesteDateTime) && (r.RequestedDateTime < requesteDateTime.AddHours(2))));

            if (reservationInRequestedPeriod > 0)
                return false;

            return true;
        }

        public static void CreateReservation(int customer_id, DateTime requestedDateTime, string material, double amount)
        {
            IDatabase db = Configuration.GetDatabase();

            int materialId = MaterialLogic.GetId(material);

            Reservation reservation = new Reservation
            {
                Customer_Id = customer_id,
                Material_Id = materialId,
                MaterialAmount = amount,
                ReservationDateTime = DateTime.Now,
                RequestedDateTime = requestedDateTime
            };

            try
            {
                db.Insert(reservation);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e.Message, e);
            }
        }

        public static ICollection<Reservation> FinishedReservations(int customerId)
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(
                new Reservation())
                .Where(r => r.Customer_Id == customerId && r.RequestedDateTime < DateTime.Now).ToList();
        }

        public static ICollection<Reservation> PendingReservations(int customerId)
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(
                new Reservation())
                .Where(r => r.Customer_Id == customerId && r.RequestedDateTime > DateTime.Now).ToList();
        }
    }
}
