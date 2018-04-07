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
    class ComandaDAO
    {
        private static MySqlCommand cmd = new MySqlCommand();

        public static void insertComanda(Comanda c)
        {
            string query = "insert into Comanda(idClient, dataComanda, pretTotal, modalitatePlata) values (" + c.IdClient + ", '" + c.DataComanda + "', '" + c.PretTotal.ToString().Replace(',', '.') + "', '" + c.ModalitatePlata + "');";
            //System.Windows.MessageBox.Show(query);
            MySqlConnection conn = ConnectionFactory.getConnection();
            cmd.Connection = conn;
            cmd.CommandText = query;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                ConnectionFactory.close(conn);
            }
        }

        public static Comanda getComanda(Comanda c)
        {
            Comanda comanda = null;
            string query = "SELECT * FROM Comanda WHERE idClient = '" + c.IdClient + "' and dataComanda = '" + c.DataComanda + "' and pretTotal = '" + c.PretTotal.ToString().Replace(',', '.') + "' and modalitatePlata = '" + c.ModalitatePlata + "';";

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
                    comanda = new Comanda(Convert.ToInt32(rdr["idComanda"]), Convert.ToInt32(rdr["idClient"]), Convert.ToString(rdr["dataComanda"]), Convert.ToDouble(rdr["pretTotal"]), Convert.ToString(rdr["modalitatePlata"]));
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

            return comanda;
        }
    }
}
