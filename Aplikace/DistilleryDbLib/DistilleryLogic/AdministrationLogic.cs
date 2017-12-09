using System;
using System.Collections.Generic;
using System.Text;
using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System.Linq;
using System.Collections.ObjectModel;

namespace DistilleryLogic
{
    public class AdministrationLogic
    {
        public static Period GetActivePeriod()
        {
            IDatabase db = Configuration.GetDatabase();

            try
            {
                return db.SelectAll(new Period()).Single(p => !p.Finished);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Season GetActiveSeason()
        {
            IDatabase db = Configuration.GetDatabase();

            try
            {
                return db.SelectAll(new Season()).Single(s => !s.Finished);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Period EndPeriod(Period period)
        {
            period.Finished = true;
            period.EndDate = DateTime.Now;

            IDatabase db = Configuration.GetDatabase();

            db.Update(period);

            return period;
        }

        public static Period StartPeriod(Period period)
        {
            IDatabase db = Configuration.GetDatabase();
            period.Finished = false;

            db.Insert(period);
            return period;
        }

        public static Season StartSeason(Season lastSeason)
        {
            IDatabase db = Configuration.GetDatabase();

            if (lastSeason != null)
            {
                lastSeason.Finished = true;
                lastSeason.EndDate = DateTime.Now;

                db.Update(lastSeason);
            }


            int currentYear = DateTime.Today.Year;

            Season newSeason = new Season
            {
                Name = currentYear.ToString() + "/" + (currentYear + 1).ToString(),
                StartDate = DateTime.Now,
                Finished = false,
                DistillationCount = 0,

            };

            db.Insert(newSeason);

            return newSeason;
        }

        public static ICollection<MonthReport> GetPeriodReport(Period period)
        {
            IDatabase db = Configuration.GetDatabase();

            IEnumerable<Distillation> distillations = db.SelectAll(new Distillation()).Where(d => d.Period_Id == period.Id);

            ICollection<MonthReport> report = new Collection<MonthReport>();

            foreach (Distillation d in distillations)
            {
                report.Add(new MonthReport
                {
                    Date = d.Date,
                    AbsVolume = d.AbsoluteAlcoholVolume,
                    Adress = d.Customer.Street + " " + d.Customer.Street + ", " + d.Customer.City.Name,
                    MaterialName = d.Material.Name,
                    Payed = d.Payed,
                    Price = d.Price,
                    Surename = d.Customer.Surename
                });
            }

            return report;
        }


    }
}
