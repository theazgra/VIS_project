using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DistilleryLogic
{
    public class CityLogic
    {
        ICollection<City> GetAllCities()
        {
            IDatabase db = Configuration.GetDatabase();
            return db.SelectAll(new City());
        }
    }
}
