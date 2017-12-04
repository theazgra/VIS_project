using DataLayerNetCore.Entities;
using DataLayerNetCore.SqlAdapters;
using System;
using System.Collections.Generic;

namespace DataLayerNetCore
{
    class SqlDatabase : IDatabase
    {
        public string ConnectionString { get; set; }

        public SqlDatabase(string connectionString)
        {
            this.ConnectionString = connectionString;
            SqlServerDatabase.SetConnectionString(connectionString);
        }
        public int Delete<T>(T entity)
        {
            Type type = entity.GetType();
            if (type == typeof(City))
                return CityTable.Delete((entity as City).Id);

            if (type == typeof(Customer))
                return CustomerTable.Delete((entity as Customer).Id);

            if (type == typeof(Distillation))
                return DistillationTable.Delete((entity as Distillation).Id);

            if (type == typeof(District))
                return DistrictTable.Delete((entity as District).Id);

            if (type == typeof(Material))
                return MaterialTable.Delete((entity as Material).Id);

            if (type == typeof(Period))
                return PeriodTable.Delete((entity as Period).Id);

            if (type == typeof(Region))
                return RegionTable.Delete((entity as Region).Id);

            if (type == typeof(Reservation))
                return ReservationTable.Delete((entity as Reservation).Id);

            if (type == typeof(Season))
                return SeasonTable.Delete((entity as Season).Id);

            if (type == typeof(UserInfo))
                return UserInfoTable.Delete((entity as UserInfo).Id);

            return 0;
        }

        public int Insert<T>(T entity)
        {
            Type type = entity.GetType();
            if (type == typeof(City))
                return CityTable.Insert(entity as City);

            if (type == typeof(Customer))
                return CustomerTable.Insert(entity as Customer);

            if (type == typeof(Distillation))
                return DistillationTable.Insert(entity as Distillation);

            if (type == typeof(District))
                return DistrictTable.Insert(entity as District);

            if (type == typeof(Material))
                return MaterialTable.Insert(entity as Material);

            if (type == typeof(Period))
                return PeriodTable.Insert(entity as Period);

            if (type == typeof(Region))
                return RegionTable.Insert(entity as Region);

            if (type == typeof(Reservation))
                return ReservationTable.Insert(entity as Reservation);

            if (type == typeof(Season))
                return SeasonTable.Insert(entity as Season);

            if (type == typeof(UserInfo))
                return UserInfoTable.Insert(entity as UserInfo);

            return 0;
        }

        public T Select<T>(T type, int primaryKey) where T : new()
        {
            Type entType = type.GetType();

            if (entType == typeof(City))
                return (T)Convert.ChangeType(CityTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Customer))
                return (T)Convert.ChangeType(CustomerTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Distillation))
                return (T)Convert.ChangeType(DistillationTable.Select(primaryKey), typeof(T));

            if (entType == typeof(District))
                return (T)Convert.ChangeType(DistrictTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Material))
                return (T)Convert.ChangeType(MaterialTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Period))
                return (T)Convert.ChangeType(PeriodTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Region))
                return (T)Convert.ChangeType(RegionTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Reservation))
                return (T)Convert.ChangeType(ReservationTable.Select(primaryKey), typeof(T));

            if (entType == typeof(Season))
                return (T)Convert.ChangeType(SeasonTable.Select(primaryKey), typeof(T));

            if (entType == typeof(UserInfo))
                return (T)Convert.ChangeType(UserInfoTable.Select(primaryKey), typeof(T));

            return default(T);
        }

        public ICollection<T> SelectAll<T>(T type) where T : new()
        {
            Type entType = type.GetType();

            if (entType == typeof(City))
                return (ICollection<T>)CityTable.Select();

            if (entType == typeof(Customer))
                return (ICollection<T>)CustomerTable.Select();

            if (entType == typeof(Distillation))
                return (ICollection<T>)DistillationTable.Select();

            if (entType == typeof(District))
                return (ICollection<T>)DistrictTable.Select();

            if (entType == typeof(Material))
                return (ICollection<T>)MaterialTable.Select();

            if (entType == typeof(Period))
                return (ICollection<T>)PeriodTable.Select();

            if (entType == typeof(Region))
                return (ICollection<T>)RegionTable.Select();

            if (entType == typeof(Reservation))
                return (ICollection<T>)ReservationTable.Select();

            if (entType == typeof(Season))
                return (ICollection<T>)SeasonTable.Select();

            if (entType == typeof(UserInfo))
                return (ICollection<T>)UserInfoTable.Select();

            return null;
        }

        public int Update<T>(T entity)
        {
            Type type = entity.GetType();

            if (type == typeof(City))
                return CityTable.Update(entity as City);

            if (type == typeof(Customer))
                return CustomerTable.Update(entity as Customer);

            if (type == typeof(Distillation))
                return DistillationTable.Update(entity as Distillation);

            if (type == typeof(District))
                return DistrictTable.Update(entity as District);

            if (type == typeof(Material))
                return MaterialTable.Update(entity as Material);

            if (type == typeof(Period))
                return PeriodTable.Update(entity as Period);

            if (type == typeof(Region))
                return RegionTable.Update(entity as Region);

            if (type == typeof(Reservation))
                return ReservationTable.Update(entity as Reservation);

            if (type == typeof(Season))
                return SeasonTable.Update(entity as Season);

            if (type == typeof(UserInfo))
                return UserInfoTable.Update(entity as UserInfo);

            return 0;
        }
    }
}
