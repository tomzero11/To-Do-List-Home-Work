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

namespace to_do_list_home_work
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Button Handle Update
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string title = row.Cells["Title"].Value.ToString();
                string description = row.Cells["Description"].Value.ToString();
                DateTime deadline = Convert.ToDateTime(row.Cells["Deadline"].Value);
                string priority = row.Cells["Priority"].Value.ToString();
                string progress = row.Cells["Progress"].Value.ToString();

                Update updateForm = new Update(this, id, title, description, deadline, priority, progress);
                updateForm.ShowDialog();
                LoadToDoList();
            }
            else
            {
                MessageBox.Show("Pilih satu baris untuk di-update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Button Handle Delete data Grit View
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                DialogResult result = MessageBox.Show("Yakin ingin menghapus tugas ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (var conn = GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM list WHERE Id = @Id";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Tugas berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadToDoList(); // refresh tampilan
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal menghapus tugas: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu tugas yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        // Button Create
        private void button1_Click_1(object sender, EventArgs e)
        {
            Create createPage = new Create(this);
            createPage.Show();
            this.Hide();
        }


        // List Data View Home Work
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int id = Convert.ToInt32(row.Cells["Id"].Value); // pastikan kolom Id disertakan
                string title = row.Cells["Title"].Value.ToString();
                string description = row.Cells["Description"].Value.ToString();
                DateTime deadline = Convert.ToDateTime(row.Cells["Deadline"].Value);
                string priority = row.Cells["Priority"].Value.ToString();
                string progress = row.Cells["Progress"].Value.ToString();

                Update updateForm = new Update(this, id, title, description, deadline, priority, progress);
                updateForm.ShowDialog();
                LoadToDoList(); // setelah update, refresh data
            }
        }

        // Connection ke database
        public MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=list_home_work;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);
        }

        // Table List
        private void LoadToDoList()
        {
            //using (var conn = GetConnection())
            //{
            //    try
            //    {
            //        conn.Open();
            //        string query = "SELECT Id,Title, Description, Deadline, Priority, Progress FROM list ORDER BY Deadline ASC";
            //        var cmd = new MySqlCommand(query, conn);

            //        var adapter = new MySqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);

            //        dataGridView1.AutoGenerateColumns = true;
            //        dataGridView1.DataSource = dt;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Gagal mengambil data to-do list: " + ex.Message);
            //    }
            //}

            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Title, Description, Deadline, Priority, Progress FROM list ORDER BY Deadline ASC";
                    var cmd = new MySqlCommand(query, conn);

                    var adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Tambahkan kolom nomor urut
                    dt.Columns.Add("No", typeof(int));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["No"] = i + 1;
                    }

                    // Pindahkan kolom "No" ke kolom pertama
                    dt.Columns["No"].SetOrdinal(0);

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Id"].Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengambil data to-do list: " + ex.Message);
                }
            }
        }


        // memuat data ketika homepage dibuka
        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadToDoList();
        }


        // Button Hanlde Logout
        private void button4_Click(object sender, EventArgs e)
        {
            LoginPage loginForm = new LoginPage();
            loginForm.Show();

            // Sembunyikan halaman HomePage
            this.Hide();
        }
    }



}
    
