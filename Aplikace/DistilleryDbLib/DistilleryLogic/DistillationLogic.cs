using System;
using System.Collections.Generic;
using System.Text;
using DataLayerNetCore;
using DataLayerNetCore.Entities;


namespace DistilleryLogic
{
    public class DistillationLogic
    {

        public static ICollection<Distillation> GetAllDistilations()
        {
            IDatabase db = Configuration.GetDatabase();

            return db.SelectAll(new Distillation());
        }

        public static Distillation GetDistillation(int distillationId)
        {
            IDatabase db = Configuration.GetDatabase();

            return db.Select(new Distillation(), distillationId);
        }

        public static int CreateDistillation(Distillation distillation)
        {
            IDatabase db = Configuration.GetDatabase();

            Season season = distillation.Season;
            season.DistillationCount += 1;
            db.Update(season);

            return db.Insert(distillation);
        }

        public static int UpdateDistillation(Distillation distillation)
        {
            IDatabase db = Configuration.GetDatabase();

            return db.Update(distillation);
        }

        public static int DeleteDistillation(Distillation distillation)
        {
            IDatabase db = Configuration.GetDatabase();

            return db.Delete(distillation);
        }

        public static bool CanBeDeleted(Distillation distillation)
        {
            DateTime tenYearsAgo = DateTime.Now.AddYears(-10);

            if (distillation.Date <= tenYearsAgo)
                return true;

            return false;
        }
    }
}
