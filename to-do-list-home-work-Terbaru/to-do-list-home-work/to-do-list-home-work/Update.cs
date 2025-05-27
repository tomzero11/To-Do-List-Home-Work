using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace to_do_list_home_work
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }


        // Update dari database
        private HomePage _homePage; // simpan referensi HomePage
        private int taskId;
        public Update(HomePage homePage, int id, string title, string description, DateTime deadline, string priority, string progress)
        {
            InitializeComponent();
            _homePage = homePage;

            taskId = id;
            textBox3.Text = title;
            textBox1.Text = description;
            dateTimePicker1.Value = deadline;
            comboBox2.SelectedItem = priority;
            textBox2.Text = progress;
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        




        //Progress TextBox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        // Priority TextBox
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // Setting Date 
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        // Description TextBox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Title TexBox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        // Button Trigger Update
        private void button2_Click(object sender, EventArgs e)
        {
            string title = textBox3.Text;
            string description = textBox1.Text;
            string deadline = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string priority = comboBox2.SelectedItem?.ToString() ?? "Medium";
            string progress = textBox2.Text;

            string connectionString = "Server=localhost;Database=list_home_work;Uid=root;Pwd=;";
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                string query = "UPDATE list SET Title = @Title, Description = @Description, Deadline = @Deadline, Priority = @Priority, Progress = @Progress WHERE Id = @Id";

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Deadline", deadline);
                cmd.Parameters.AddWithValue("@Priority", priority);
                cmd.Parameters.AddWithValue("@Progress", progress);
                cmd.Parameters.AddWithValue("@Id", taskId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tugas berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // tutup form update
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui tugas: " + ex.Message);
                }
            }
        }

        // Button Tigger Cancel

        private void button1_Click(object sender, EventArgs e)
        {
            // _homePage.Show();
            this.Close();
        }

    

        private void Update_Load(object sender, EventArgs e)
        {

        }

        // Priority ComboBox
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
