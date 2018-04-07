using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace FoodDelivery.connection
{
    public class ConnectionFactory
    {
        private string connectionString;
        private static string USER;
        private static string PASS;

        private static readonly string Path = "C:/PS_A1.txt";
        private StreamReader sr;

        private static ConnectionFactory singleInstance = new ConnectionFactory();

        private ConnectionFactory()
        {
            try
            {
                sr = new StreamReader(Path);
                string userAux, passAux;
                userAux = sr.ReadLine();
                passAux = sr.ReadLine();

                for (int i = 0; i < userAux.Length; i += 2)
                {
                    USER += Convert.ToChar(userAux[i] + 1);
                }

                for (int i = 0; i < passAux.Length; i += 2)
                {
                    PASS += Convert.ToChar(passAux[i] - 1);
                }

                connectionString = "server=localhost;database=foodDelivery;uid=" + USER + ";password=" + PASS;
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("File not found : " + e.Message);
            }
        }      

        public static ConnectionFactory getInstance()
        {
            if (singleInstance == null) singleInstance = new ConnectionFactory();

            return singleInstance;
        }

        /*public string getConnectionString()
        {
            return connectionString;
        }*/

        private MySqlConnection createConnection()
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connectionString);
            }
            catch(MySqlException e)
            {
                System.Windows.MessageBox.Show("Error : " + e.ToString());
            }

            return conn;
        }

        public static MySqlConnection getConnection()
        {
            return singleInstance.createConnection();
        }

        public static void close(MySqlConnection conn)
        {
            if(conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch(MySqlException e)
                {
                    System.Windows.MessageBox.Show("Error : " + e.ToString());
                }
            }
        }
    }
}
