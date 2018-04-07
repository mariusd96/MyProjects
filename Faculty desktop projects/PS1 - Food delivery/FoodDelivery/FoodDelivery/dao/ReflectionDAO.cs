using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.connection;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace FoodDelivery.dao
{
    class ReflectionDAO
    {
        private static MySqlCommand cmd = new MySqlCommand();

        public static Type getType(string tip)
        {
            Type myType = null;

            switch (tip)
            {
                case "CategoriiProdus":
                    myType = typeof(CategoriiProdus);
                    break;

                case "Cont":
                    myType = typeof(Cont);
                    break;

                case "Client":
                    myType = typeof(Client);
                    break;

                case "Comanda":
                    myType = typeof(Comanda);
                    break;

                case "DetaliiComanda":
                    myType = typeof(DetaliiComanda);
                    break;

                case "Produs":
                    myType = typeof(Produs);
                    break;
            }

            return myType;
        }

        public static string getInformation(Object obj, FieldInfo info, string tip)
        {
            string information = "";

            switch (tip)
            {
                case "CategoriiProdus":
                    information = info.GetValue(obj as CategoriiProdus).ToString();
                    break;

                case "Cont":
                    information = info.GetValue(obj as Cont).ToString();
                    break;

                case "Client":
                    information = info.GetValue(obj as Client).ToString();
                    break;

                case "Comanda":
                    information = info.GetValue(obj as Comanda).ToString();
                    break;

                case "DetaliiComanda":
                    information = info.GetValue(obj as DetaliiComanda).ToString();
                    break;

                case "Produs":
                    information = info.GetValue(obj as Produs).ToString();
                    break;
            }

            return information;
        }

        #region select from DB
        private static string selectQuery(Object obj, string tip)
        {
            string query = "SELECT ";

            Type myType = getType(tip);
            FieldInfo[] fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            int nr = fields.Length;

            foreach (FieldInfo info in fields)
            {
                if (nr > 1) query += info.Name.ToString() + ", ";
                else query += info.Name.ToString();
                nr--;
            }

            query += " FROM " + tip + " WHERE ";            

            nr = fields.Length;
            if (tip == "Cont") nr--;

            foreach (FieldInfo info in fields)
            {
                if (nr > 0)
                {
                    if (nr > 1) query += info.Name + " = '" + info.GetValue(obj).ToString() + "' and ";
                    else query += info.Name + " = '" + info.GetValue(obj).ToString() + "';";

                    nr--;
                }
            }
            
            return query;
        }

        public static Object select(Object obj, string tip)
        {
            Object o = null;

            MySqlConnection conn = ConnectionFactory.getConnection();

            cmd.Connection = conn;
            cmd.CommandText = selectQuery(obj, tip);
            
            try
            {
                //System.Windows.MessageBox.Show(cmd.CommandText.ToString());
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    //System.Windows.MessageBox.Show(rdr["username"].ToString() + ", " + rdr["pass"].ToString() + ", " + rdr["rol"].ToString());
                    if(tip == "Cont") o = new Cont(Convert.ToString(rdr["username"]), Convert.ToString(rdr["pass"]), Convert.ToChar(rdr["rol"]));
                    else if (tip == "CategoriiProdus") o = new CategoriiProdus(Convert.ToString(rdr["categorie"]));
                    rdr.Close();
                }
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
            finally
            {
                ConnectionFactory.close(conn);
            }

            return o;
        }
        #endregion select from DB

        #region insert in DB
        private static string insertQuery(Object obj, string tip)
        {
            Type myType = getType(tip);
            string query = "insert into ";

            #region switch(tip)
            switch (tip)
            {
                case "CategoriiProdus":
                    query += "CategoriiProdus";
                    break;

                case "Cont":
                    query += "Cont";
                    break;

                case "Client":
                    query += "Client(username, nume, prenume, cnp, adresaLivrare, nrTelefon, email, eClientLoial)";
                    break;

                case "Comanda":
                    query += "Comanda(idClient, dataComanda, pretTotal, modalitatePlata)";
                    break;

                case "DetaliiComanda":
                    query += "DetaliiComanda";
                    break;

                case "PretCantitateProdus":
                    query += "PretCantitateProdus";
                    break;

                case "Produs":
                    query += "Produs(categorie, nume, descriere, gramaj, pret)";
                    break;
            }
            #endregion switch(tip)

            query += " values('";

            FieldInfo[] fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            int len = fields.Length, iterator = 1;
            foreach (FieldInfo info in fields)
            {
                //System.Windows.MessageBox.Show(info.Name + ", " + info.GetValue(obj as Cont).ToString());
                string information = getInformation(obj, info, tip);

                if (information != "0" && info.Name.ToString().Substring(0, 2) != "id")
                {
                    if (iterator < len) query += information + "','";
                    else query += information;
                }

                iterator++;
            }

            query += "');";
            //System.Windows.MessageBox.Show(query);

            return query;
        }

        public static void insert(Object obj, string tip)
        {
            MySqlConnection conn = ConnectionFactory.getConnection();
            cmd.Connection = conn;
            cmd.CommandText = insertQuery(obj, tip);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                ConnectionFactory.close(conn);
            }
            
        }
        #endregion insert in DB

        #region update in DB
        private static string updateQuery(Object objModificat, Object objOriginal, string tip)
        {
            Type myType = getType(tip);
            string query = "update " + tip + " set ";

            FieldInfo[] fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            int len = fields.Length, iterator = 1;

            foreach(FieldInfo info in fields)
            {
                query += info.Name.ToString() + " = '" + info.GetValue(objModificat) + "'";
                if (iterator < len) query += ", ";
                iterator++;
            }

            query += "where ";

            len = fields.Length;
            iterator = 1;

            foreach (FieldInfo info in fields)
            {
                query += info.Name.ToString() + " = '" + info.GetValue(objOriginal) + "'";
                if (iterator < len) query += " and ";
                iterator++;
            }

            query += ";";

            return query;
        }

        public static void update(Object objModificat, Object objOriginal, string tip)
        {
            MySqlConnection conn = ConnectionFactory.getConnection();
            cmd.Connection = conn;
            cmd.CommandText = updateQuery(objModificat, objOriginal, tip);

            //System.Windows.MessageBox.Show(cmd.CommandText);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                ConnectionFactory.close(conn);
            }
        }
        #endregion update in DB

        #region delete from DB 
        private static string deleteQuery(Object obj, string tip)
        {
            Type myType = getType(tip);
            string query = "delete from " + tip + " where ";

            FieldInfo[] fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            int len = fields.Length, iterator = 1;

            foreach(FieldInfo info in fields)
            {
                query += info.Name.ToString() + " = '" + info.GetValue(obj).ToString() + "'";
                if (iterator < len) query += " and ";
                iterator++;
            }

            query += ";";

            return query;
        }

        public static void delete(Object obj, string tip)
        {
            MySqlConnection conn = ConnectionFactory.getConnection();
            cmd.Connection = conn;
            cmd.CommandText = deleteQuery(obj, tip);

            //System.Windows.MessageBox.Show(cmd.CommandText);

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
        #endregion delete from DB

        public static List<Object> createListOfObjects(string query, string tip)
        {
            List<Object> list = new List<Object>();

            MySqlConnection conn = ConnectionFactory.getConnection();
            cmd.Connection = conn;
            cmd.CommandText = query;

            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Object o = null;

                    if (tip == "Cont") o = new Cont(Convert.ToString(rdr["username"]), Convert.ToString(rdr["pass"]), Convert.ToChar(rdr["rol"]));
                    else if (tip == "CategoriiProdus") o = new CategoriiProdus(Convert.ToString(rdr["categorie"]));
                    else if (tip == "Client") o = new Client(Convert.ToInt32(rdr["idClient"]), Convert.ToString(rdr["username"]), Convert.ToString(rdr["nume"]), Convert.ToString(rdr["prenume"]), Convert.ToString(rdr["cnp"]), Convert.ToString(rdr["adresaLivrare"]), Convert.ToString(rdr["nrTelefon"]), Convert.ToString(rdr["email"]), Convert.ToChar(rdr["eClientLoial"]));
                    else if (tip == "Comanda") o = new Comanda(Convert.ToInt32(rdr["idComanda"]), Convert.ToInt32(rdr["idClient"]), Convert.ToString(rdr["dataComanda"]), Convert.ToDouble(rdr["pretTotal"]), Convert.ToString(rdr["modalitatePlata"]));
                    else if (tip == "DetaliiComanda") o = new DetaliiComanda(Convert.ToInt32(rdr["idComanda"]), Convert.ToString(rdr["numeProdus"]), Convert.ToDouble(rdr["pret"]), Convert.ToInt32(rdr["cantitate"]));
                    else if (tip == "Produs") o = new Produs(Convert.ToInt32(rdr["idProdus"]), Convert.ToString(rdr["categorie"]), Convert.ToString(rdr["nume"]), Convert.ToString(rdr["descriere"]), Convert.ToInt32(rdr["gramaj"]), Convert.ToDouble(rdr["pret"]));

                    list.Add(o);
                }

                rdr.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                ConnectionFactory.close(conn);
            }

            return list;
        }
    }
}
