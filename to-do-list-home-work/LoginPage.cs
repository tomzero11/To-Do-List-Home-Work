using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace to_do_list_home_work
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            // Gantilah string koneksi di bawah sesuai dengan database Anda
            string connectionString = "Server=localhost;Database=list_home_work;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);
        }

        private bool ValidateLogin(string username, string password)
        {
            bool isValid = false;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return isValid;
        }







        private void button1_Click(object sender, EventArgs e)
        {
            //// Untuk sementara, abaikan input dan langsung buka HomePage
            //HomePage home = new HomePage();
            //home.Show();
            //this.Hide(); // Menyembunyikan login page

          
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim(); 


            // Validasi input kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateLogin(username, password))
            {
                MessageBox.Show("Login Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HomePage home = new HomePage();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show(); // Menampilkan form register
            this.Hide(); // Menyembunyikan form login
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
