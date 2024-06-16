using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;

namespace ДП
{
    public class ForSQL
    {

        SQLiteConnection sqliteConnection = new SQLiteConnection(@"Data Source = G:\DPSQL.db;Version=3;");

        /// <summary>
        /// Открытие соединения с базой данных SQLite
        /// </summary>
        public void openConnection()
        {
            if (sqliteConnection.State == System.Data.ConnectionState.Closed)
                sqliteConnection.Open();
        }

        /// <summary>
        /// Закрытие соединения с базой данных SQLite
        /// </summary>
        public void closeConnection()
        {
            if (sqliteConnection.State == System.Data.ConnectionState.Open)
                sqliteConnection.Close();
        }

        /// <summary>
        /// Получение соединения с базой данных SQLite
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection getConnection()
        {
            return sqliteConnection;
        }
    }
}
