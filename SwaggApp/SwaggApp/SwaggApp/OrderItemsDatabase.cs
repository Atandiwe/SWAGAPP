using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.IO;

namespace SwaggApp
{
    public  class OrderItemsDatabase
    {
        static SQLiteConnection Database;

        public static OrderItemsDatabase Instance
        {
            get
            {
                var instance = new OrderItemsDatabase();
                CreateTableResult result = Database.CreateTable<OrderItems>();
                return instance;
            }
        
        }
        public static class Constants
        {
            public const string DatabaseFilename = "SwaggAppSQLite.db3";

            public const SQLite.SQLiteOpenFlags Flags =
                // open the database in read/write mode
                SQLite.SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                SQLite.SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLite.SQLiteOpenFlags.SharedCache;

            public static string DatabasePath
            {
                get
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    return Path.Combine(basePath, DatabaseFilename);
                }
            }
        }
        public  OrderItemsDatabase()
        {
            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        }

        public List<OrderItems> GetOrders()
        {
            return Database.Table<OrderItems>().ToList();
        }
        
        public List<OrderItems> GetOrdersNotDone()
        {
            return Database.Query<OrderItems>("SELECT * from [OrderItems] WHERE [DONE] = 0");

        }
        public OrderItems GetOrders (int id)
        {
            return Database.Table<OrderItems>().Where(i => i.Id == id).FirstOrDefault();
        }
        public int SaveItem(OrderItems item )
        { 
            if (item.Id != 0 )
            {
                return Database.Update(item);
            }
            else
            {
                return Database.Insert(item);
            }
           
        }
        public int DeleteItem(OrderItems item)
        {
            return Database.Delete(item);
        }
        
    } 
}
