using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.connection;
using MySql.Data.MySqlClient;

namespace FoodDelivery.dao
{
    class ClientDAO
    {
        private static MySqlCommand cmd = new MySqlCommand();

        public static Client getById(Cont cont)
        {
            Client client = null;
            string query = "SELECT * FROM Client WHERE username = '" + cont.Username + "'";

            MySqlConnection conn = ConnectionFactory.getConnection();

            conn.Open();

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = query;

                //System.Windows.MessageBox.Show(cmd.CommandText.ToString());
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    client = new Client(Convert.ToInt32(rdr["idClient"]), Convert.ToString(rdr["username"]), Convert.ToString(rdr["nume"]), Convert.ToString(rdr["prenume"]), Convert.ToString(rdr["cnp"]), Convert.ToString(rdr["adresaLivrare"]), Convert.ToString(rdr["nrTelefon"]), Convert.ToString(rdr["email"]), Convert.ToChar(rdr["eClientLoial"]));
                    rdr.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
            finally
            {
                ConnectionFactory.close(conn);
            }

            return client;
        }
    }
}
