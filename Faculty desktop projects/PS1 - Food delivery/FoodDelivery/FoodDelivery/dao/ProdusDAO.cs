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
    class ProdusDAO
    {
        private static MySqlCommand cmd = new MySqlCommand();

        public static Produs getProdus(Produs p)
        {
            Produs produs = null;
            string query = "SELECT * FROM Produs WHERE categorie = '" + p.Categorie + "' and descriere = '" + p.Descriere + "' and gramaj = '" + p.Gramaj + "' and pret = '" + p.Pret + "';";

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
                    produs = new Produs(Convert.ToInt32(rdr["idProdus"]), Convert.ToString(rdr["categorie"]), Convert.ToString(rdr["nume"]), Convert.ToString(rdr["descriere"]), Convert.ToInt32(rdr["gramaj"]), Convert.ToDouble(rdr["pret"]));
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

            return produs;
        }
    }
}
