using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Cabinet_medical
{
    public class Controller
    {
        String connectionString;
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        DataSet ds;
        MySqlDataAdapter da;
        MySqlDataReader rs;
        public char drept_admin;
        public String mesaj;
        public int id_medic;

        public Controller()
        {
            connectionString = "server=localhost;database=cabinet;uid=root;password=dinamitaA7!xrn/1;";
            conn = new MySqlConnection(connectionString);
            cmd = new MySqlCommand();
            drept_admin = 'X';
            mesaj = null;
            id_medic = 0;
        }

        public void autentificare(String username, String password)
        {
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "Autentificare_persoane";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("user_name", username);
                cmd.Parameters["user_name"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("pass", password);
                cmd.Parameters["pass"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("dreptAdmin", MySqlDbType.VarChar);
                cmd.Parameters["dreptAdmin"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("mesaj", MySqlDbType.VarString);
                cmd.Parameters["mesaj"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("idMedic", MySqlDbType.Int32);
                cmd.Parameters["idMedic"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                this.id_medic = (int)cmd.Parameters["idMedic"].Value;
                this.mesaj = cmd.Parameters["mesaj"].Value.ToString();
                this.drept_admin = Convert.ToChar(cmd.Parameters["dreptAdmin"].Value);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void inserare_pacient(String nume, String prenume, String cnp, String adresa, String telefon)
        {
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "Pacient_nou";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id_medic", id_medic);
                cmd.Parameters["id_medic"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("nume", nume);
                cmd.Parameters["nume"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("prenume", prenume);
                cmd.Parameters["prenume"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("cnp", cnp);
                cmd.Parameters["cnp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("adresa", adresa);
                cmd.Parameters["adresa"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("telefon", telefon);
                cmd.Parameters["telefon"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Pacientul a fost inserat cu succes in baza de date!");
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public DataGrid populeaza_datagrid(string sql, string tabel, DataGrid dataGrid, int nr_col)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                //da.Fill(dt);
                da.Fill(ds, tabel);
                dataGrid.DataContext = ds;
                dataGrid.ColumnWidth = dataGrid.Width / nr_col;
                // dataGrid.ItemsSource = dt.DefaultView;
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;

                return dataGrid;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public void updateDataGrid()
        {
            try
            {
                MySqlCommandBuilder cmb = new MySqlCommandBuilder(da);
                da.UpdateCommand = cmb.GetUpdateCommand();
                da.Update(ds.Tables[0]);

                MessageBox.Show("Modificările au fost efectuate și salvate cu succes!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public ComboBox populeazaComboBox(string sql, string coloana, ComboBox comboBox)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                rs = cmd.ExecuteReader();

                while(rs.Read())
                {
                    string element = rs.GetString(coloana);
                    comboBox.Items.Add(element);
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return comboBox;
        }

        public void insertOnDB(string sql)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Operatia de inserare s-a efectuat cu succes!");
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public int idPacient()
        {
            int id = 0;
            try
            {
                conn.Open();
                cmd = new MySqlCommand("SELECT MAX(id_pacient) FROM Pacient", conn);
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return id;
        }
    }
}
