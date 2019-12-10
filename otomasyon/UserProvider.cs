using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace otomasyon
{
    public class UserProvider
    {
        public User getUser(string kullaniciadi, string sifrem)
        {
            User user = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM login WHERE kullaniciadi='" + kullaniciadi + "' and sifrem='" + sifrem + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User();
                        user.Id = reader.GetInt32(0); //id
                        user.kullaniciadim = reader.GetString(1);   //name
                        user.sifrem = reader.GetString(2);  //password
                    }
                }
                connection.Close();
            }
            return user;
        }

        private bool ContainsUser(User user)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM Users WHERE Name='" + user.kullaniciadim + "'");
                //var command = new SqlCommand("SELECT *FROM Users WHERE Name='" + user.Name + "' and Password='" + user.Password + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;
        }

        public bool InsertUser(User user)
        {
            bool result = false;
            if (!ContainsUser(user))
            {
                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand("INSERT INTO Users(Name,Password) VALUES('" + user.kullaniciadim + "','" + user.sifrem + "')");
                    command.Connection = connection;
                    connection.Open();
                    if (command.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
            return result;
        }
    }
}
