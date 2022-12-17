using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BookShop.Areas.Admin.Models;

namespace BookShop.Models
{
    public class Context
    {
        public string ConnectionString { get; set; }

        public Context(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }


        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from product";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            pd_ID = reader["pd_ID"].ToString(),
                            cat_ID = reader["cat_ID"].ToString(),
                            title = reader["title"].ToString(),
                            price = reader["price"].GetHashCode(),
                            thumbnail = reader["thumbnail"].ToString(),
                            discount = reader["discount"].GetHashCode(),
                            des = reader["des"].ToString(),
                            created_at = reader["created_at"].ToString(),
                            updated_at = reader["updated_at"].ToString(),
                            quantity = reader["quantity"].GetHashCode(),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
    }
}
