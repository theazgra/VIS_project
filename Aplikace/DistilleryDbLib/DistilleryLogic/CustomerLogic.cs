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
        public static bool GoodPersonalNumber(string personalNumber)
        {
            if (string.IsNullOrEmpty(personalNumber))
                return false;
            //check age
            if (!personalNumber.Contains("/"))
                return false;

            personalNumber =  personalNumber.Replace("/", string.Empty);

            if (!long.TryParse(personalNumber, out long pnValue))
                return false;

            if (pnValue % 11 != 0)
                return false;

            return true;
        }

        public static bool LoginAvaible(string login)
        {

            IDatabase db = Configuration.GetDatabase();

            if (db.SelectAll(new Customer()).Count(c => c.Login == login) > 0)
                return false;
            if (db.SelectAll(new UserInfo()).Count(u => u.Login == login) > 0)
                return false;

            return true;
        }

        public static Customer CreateCustomer(Customer newCustomer)
        {
            try
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

                db.Insert(newCustomer);
              

                return newCustomer;
            }
            catch (Exception e)
            {

                throw new DatabaseException(e.Message, e);
            }
        }
    }
}
