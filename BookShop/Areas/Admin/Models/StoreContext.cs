using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace BookShop.Areas.Admin.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }

        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }

        public int CheckLoginAdmin(string usname, string pass)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int i = 0;
                conn.Open();
                var str = "select * from USER where username=@username and password=@password and role='0' ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("username", usname);
                cmd.Parameters.AddWithValue("password", pass);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                    }
                }
                return i;
            }
        }

        public int CheckLoginUser(string username, string passw)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int i = 0;
                conn.Open();
                var str = "select * from USER where username=@username and password=@password and role='1' ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", passw);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                    }
                }
                return i;
            }
        }


        public List<User> GetUsers()
        {
            List<User> list = new List<User>();

            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from user";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            user_ID = reader["user_ID"].ToString(),
                            fullname = reader["fullname"].ToString(),
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(),
                            email = reader["email"].ToString(),
                            address = reader["address"].ToString(),
                            phone = reader["phone"].ToString(),
                            role = reader["role"].ToString(),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public int RegisterUser(User acc)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into user (username, password, email, role) values(@username, @password, @email, '1')";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("username", acc.username);
                cmd.Parameters.AddWithValue("password", acc.password);
                cmd.Parameters.AddWithValue("email", acc.email);
               
                return (cmd.ExecuteNonQuery());
            }
        }



        public int UpdateUser(User us)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update user set fullname = @fn, username = @un, password = @pw, email = @e, address = @add, phone = @p, role = @r where user_ID=@uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", us.user_ID);
                cmd.Parameters.AddWithValue("fn", us.fullname);
                cmd.Parameters.AddWithValue("un", us.username);
                cmd.Parameters.AddWithValue("e", us.email);
                cmd.Parameters.AddWithValue("pw", us.password);
                cmd.Parameters.AddWithValue("add", us.address);
                cmd.Parameters.AddWithValue("p", us.phone);
                cmd.Parameters.AddWithValue("r", us.role);
                return (cmd.ExecuteNonQuery());
            }
        }

        public User ViewUser(string Id)
        {
            User us = new User();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from User where User_ID=@uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    us.user_ID = reader["user_ID"].ToString();
                    us.fullname = reader["fullname"].ToString();
                    us.username = reader["username"].ToString();
                    us.password = reader["password"].ToString();
                    us.email = reader["email"].ToString();
                    us.address = reader["address"].ToString();
                    us.phone = reader["phone"].ToString();
                    us.role = reader["role"].ToString();
                }
            }
            return (us);
        }
        public int DeleteUser(string id)
        {
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "delete from USER where user_ID=@uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", id);

                return (cmd.ExecuteNonQuery());

            }
        }

        public int CheckRegisterError(string us, string mail)
        {
            int i = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from USER where username=@username or email = @email";
                MySqlCommand cmd = new MySqlCommand(str, conn);

                cmd.Parameters.AddWithValue("username", us);
                cmd.Parameters.AddWithValue("email", mail);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                    }
                }
            }
            return i;
        }

        public StoreContext()
        {
        }

    }
}
