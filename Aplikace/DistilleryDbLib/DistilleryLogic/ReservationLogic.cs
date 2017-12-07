using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .Where(r => r.Customer_Id == customerId && r.RequestedDateTime < DateTime.Now)
                .OrderBy(r => r.RequestedDateTime).ToList();
        }

        public static Reservation GetReservation(int id)
        {
            IDatabase db = Configuration.GetDatabase();

            return db.Select(new Reservation(), id);
        }

        public static ICollection<Reservation> PendingReservations(int customerId)
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(
                new Reservation())
                .Where(r => r.Customer_Id == customerId && r.RequestedDateTime > DateTime.Now)
                .OrderBy(r => r.RequestedDateTime).ToList();
        }

        public static IDictionary<DateTime, ICollection<Reservation>> GetReservationByDayInPeriod(DateTime dateFrom, DateTime dateTo)
        {
            IDatabase db = Configuration.GetDatabase();

            IEnumerable<Reservation> reservations = db.SelectAll(new Reservation())
                .Where(r => r.RequestedDateTime >= dateFrom && r.RequestedDateTime <= dateTo)
                .OrderBy(r => r.RequestedDateTime);

            

            IDictionary<DateTime, ICollection<Reservation>> result = new Dictionary<DateTime, ICollection<Reservation>>();

            foreach (Reservation r in reservations)
            {
                if (result.ContainsKey(r.RequestedDateTime.Date))
                {
                    result[r.RequestedDateTime.Date].Add(r);
                }
                else
                {
                    result.Add(r.RequestedDateTime.Date, new List<Reservation>());
                    result[r.RequestedDateTime.Date].Add(r);
                }
            }


            return result;
        }
    }
}
