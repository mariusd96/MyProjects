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
    class DetaliiComandaDAO
    {
        private static MySqlCommand cmd = new MySqlCommand();

        public static void insertDetaliuComanda(DetaliiComanda dc)
        {
            string query = "insert into DetaliiComanda values (" + dc.IdComanda + ", '" + dc.NumeProdus + "', '" + dc.Pret.ToString().Replace(',', '.') + "', " + dc.Cantitate + ");";
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
    }
}
