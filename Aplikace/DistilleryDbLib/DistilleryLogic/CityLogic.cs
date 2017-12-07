using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System.Collections.Generic;

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
