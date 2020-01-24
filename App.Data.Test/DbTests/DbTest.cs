using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using App.Data.DB;
using App.Data.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace App.Data.Test.DbTests
{
    class DbTest
    {
        [SetUp]
        public void Setup()
        {
            using (SqlConnection connection = new SqlConnection(
            @"server=leo-arthaud-pc\SQLSERVE;database=DbAspNet;trusted_connection=true;"))

            {
                string sql = @"if (exists(Select 1 from sys.tables where name = 'Note'))
                               DROP Table Note
                               if (exists(Select 1 from sys.tables where name = 'Address'))
                               DROP Table Address
                               if (exists(Select 1 from sys.tables where name = 'Restaurant'))
                               DROP Table Restaurant";
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text; 
                        connection.Open();
                        command.ExecuteNonQuery(); 
                        connection.Close();
                    }
                }
                catch (Exception e) { }
            }
        }

        [Test]
        public void getAllForInitTest()
        {
            using (var db = new RestaurantsContext())
            {
                db.Database.EnsureCreated();
                var result = db.Restaurants.ToList();
            }
        }

        //public void createOneRestaurant()
        //{
        //    using (var db = new RestaurantsContext())
        //    {
        //        var restaurant = new Restaurant()
        //        {
        //            id= 1,
        //            name = "RestoBien",
        //            phone = "0000000000",
        //            comment = "C'est bien",
        //            email = "1restoBien@gmail.com",
        //            address = new Address()
        //            {
        //                id='1',
        //                rue = "Gabriel Péri",
        //                CP = "38000",
        //                city = "grenoble",
        //            },
        //            note = new Note()
        //            {
        //                id=1,
        //                valueNote = 0,

        //            }
        //        };
        //        db.Restaurants.Add(restaurant);
        //        db.SaveChanges();
        //    }
        //}

    }
}
