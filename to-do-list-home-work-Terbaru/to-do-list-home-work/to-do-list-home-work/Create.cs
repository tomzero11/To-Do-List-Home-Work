using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using db_controller;

namespace to_do_list_home_work
{
    public partial class Create : Form
    {
        // Predefined options for priority
        private readonly string[] comboOptions = { "Low", "Medium", "High" };

        // Flag to prevent re-triggering logic while loading ComboBox items
        private bool isLoadingCombo = false;

        public Create()
        {
            InitializeComponent();
            LoadComboBoxOptions(); // Call to load the priority options into ComboBoxes
        }

        // Function to load priority options into ComboBoxes
        private void LoadComboBoxOptions()
        {
            isLoadingCombo = true;

            // Hapus semua item sebelumnya
            comboBox2.Items.Clear();

            // Tambahkan opsi prioritas ke comboBox2 (hanya sekali)
            comboBox2.Items.AddRange(comboOptions);

            // Setel default selection ke -1 (tidak ada yang dipilih)
            comboBox2.SelectedIndex = -1;

            isLoadingCombo = false;
        }

        // Button click event to create task data to the database
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // Get the input values from the form controls
        //    string title = textBox1.Text; // Task title from textBox1
        //    string description = textBox2.Text; // Task description from textBox2
        //    string date = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Deadline from dateTimePicker
        //    string priority = GetSelectedPriority(); // Get the selected priority from comboBox1 or comboBox2
        //    string progress = textBox3.Text;
        //    // Save the task data to the database
        //    SimpanKeDatabase(title, description, date, priority, progress);

        //    // Setelah simpan, kembali ke HomePage
        //    HomePage home = new HomePage();
        //    home.Show();
        //    this.Close();
        //}

        // Button add Create Add
        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string description = textBox2.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string priority = GetSelectedPriority();
            string progress = textBox3.Text;

            try
            {
                DBController.InsertTask(title, description, date, priority, progress);
                MessageBox.Show("Task added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HomePage home = new HomePage();
                home.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add task: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Function to get the selected priority from either comboBox1 or comboBox2
        private string GetSelectedPriority()
        {
            // Check which combo box has a selected index (i.e., a valid selection)
            if (comboBox2.SelectedIndex != -1)
            {
                return comboBox2.SelectedItem.ToString();
            }
            else if (comboBox2.SelectedIndex != -1)
            {
                return comboBox2.SelectedItem.ToString();
            }

            // Default to "Medium" if no selection is made
            return "Medium";
        }

         // Function to save the task data to the database
        //private void SimpanKeDatabase(string title, string description, string date, string priority, string progress)
        //{
        //    string connectionString = "Server=localhost;Database=list_home_work;Uid=root;Pwd=;";
        //    using (MySqlConnection conn = new MySqlConnection(connectionString))
        //    {
        //        // Query to insert the task data into the database
        //        string query = "INSERT INTO list (Title, Description, Deadline, Priority, Progress) " +
        //                       "VALUES (@Title, @Description, @Deadline, @Priority, @Progress)";

        //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //        {
        //            // Adding parameters to the SQL query
        //            cmd.Parameters.AddWithValue("@Title", title);
        //            cmd.Parameters.AddWithValue("@Description", description);
        //            cmd.Parameters.AddWithValue("@Deadline", date);
        //            cmd.Parameters.AddWithValue("@Priority", priority);
        //            cmd.Parameters.AddWithValue("@Progress", progress);

        //            try
        //            {
        //                conn.Open();
        //                cmd.ExecuteNonQuery(); // Execute the query to insert the data
        //                MessageBox.Show("Task added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Failed to add task: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

        // Event handler for comboBox2 selection (if needed)
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add logic if needed when the second comboBox selection changes
        }
        

        // Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            _homePage.Show(); 
            this.Close();    

        }


        // parameter untuk kembali ke homepage
        private HomePage _homePage;

        public Create(HomePage homePage)
        {
            InitializeComponent();
            _homePage = homePage;
            LoadComboBoxOptions();
        }


        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        
        
        // Progess TextBox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
