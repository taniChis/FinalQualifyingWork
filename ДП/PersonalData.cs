using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДП
{
    public class PersonalData
    {
        ForSQL forSQL = new ForSQL();
        public static int Id { get; private set; }
        public static string Login { get; private set; }
        public static string Password { get; private set; }
        public static string Post { get; private set; }

        public bool SetPersonalData(string login, string password)
        {
            string sqlExpression = "SELECT IDEmployee, Post, Login, Password_  FROM Employee \r\n" +
                "JOIN PostTb ON Employee.IDPost = PostTb.IDPost \r\n" +
                "WHERE Employee.Login = @Login AND Employee.Password_ = @Password LIMIT 1";
            forSQL.openConnection();
            SQLiteCommand command = new SQLiteCommand(sqlExpression, forSQL.getConnection());
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Password", password);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Id = Convert.ToInt32(reader["IDEmployee"]);
                Post = reader["Post"].ToString();
                Login = reader["Login"].ToString();
                Password = reader["Password_"].ToString();
                return true;
            }
            return false;
        }
    }
}
