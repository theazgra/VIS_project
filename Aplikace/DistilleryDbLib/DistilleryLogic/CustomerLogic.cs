using DataLayerNetCore;
using DataLayerNetCore.Entities;
using System;
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

            personalNumber = personalNumber.Replace("/", string.Empty);

            if (!long.TryParse(personalNumber, out long pnValue))
                return false;

            if (pnValue % 11 != 0)
                return false;


            IDatabase db = Configuration.GetDatabase();

            if (db.SelectAll(new Customer()).Count(c => c.PersonalNumber == personalNumber) > 0)
                return false;

            return true;
        }




        public static Customer GetCustomer(int id)
        {
            IDatabase db = Configuration.GetDatabase();
            return db.Select(new Customer(), id);
        }

        public static Customer CreateCustomer(Customer newCustomer)
        {
            try
            {
                newCustomer.RegistrationDate = DateTime.Now;
                newCustomer.Password = Hashing.Hash(newCustomer.Password);
                newCustomer.DistilledVolume = 0;
                newCustomer.UserLevel = UserInfo.Customer;

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
