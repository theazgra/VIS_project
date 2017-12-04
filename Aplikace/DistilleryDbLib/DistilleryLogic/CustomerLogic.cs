using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DistilleryLogic
{
    public class CustomerLogic
    {
        public static Customer CreateCustomer(Customer newCustomer)
        {
            newCustomer.RegistrationDate = DateTime.Now;
            newCustomer.DistilledVolume = 0;
            newCustomer.UserLevel = Customer.Customer;

            IDatabase db = Configuration.GetDatabase();

            if (db.SelectAll(new City()).Count(c => c.Name == newCustomer.City.Name && c.ZipCode == newCustomer.City.ZipCode) > 0)
            {
                newCustomer.City_Id = db.SelectAll(new City()).Where(c => c.Name == newCustomer.City.Name && c.ZipCode == newCustomer.City.ZipCode).First().Id;
            }
            else
            {
                db.Insert(new City
                {
                    Name = newCustomer.City.Name,
                    ZipCode = newCustomer.City.ZipCode,
                    District_Id = 1,
                    Region_Id = 1
                });

                newCustomer.City_Id = db.SelectAll(new City()).Max(c => c.Id);
            }

            try
            {
                db.Insert(newCustomer);
            }
            catch (Exception e)
            {

                throw;
            }
            
            return newCustomer;
        }
    }
}
