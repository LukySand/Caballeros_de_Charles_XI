using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TP_3_CDC11.Controlers
{
    internal class Conection
    {
        static SQLiteConnection connection = new SQLiteConnection("Data Source=AGENDA_DB.db");  //i put the dirrectory of the database here beacuse were going to be using only one

        public static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public static void CloseConnection() 
        { 
            connection.Close();
        }
        public static SQLiteConnection Connection
        {
            set { connection = value; }
            get { return connection; } 
        }
    }
}
