using System;
using System.Collections.Generic;

namespace DataLayerNetCore
{
    public interface IDatabase
    {
        int Insert<T>(T entity);
        int Update<T>(T entity);
        int Delete<T>(T entity);

        ICollection<T> SelectAll<T>(T type) where T : new();
        T Select<T>(T type, int primaryKey) where T : new();
    }
}
