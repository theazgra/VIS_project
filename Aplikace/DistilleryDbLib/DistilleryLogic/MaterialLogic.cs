using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DistilleryLogic
{
    public class MaterialLogic
    {
        public static ICollection<String> MaterialNames()
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(new Material()).Select(m => m.Name).ToList();
        }


        public static int GetId(string name)
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(new Material()).First(m => m.Name == name).Id;
        }

        public static ICollection<Material> GetAllMaterial()
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(new Material());
        }
    }
}
