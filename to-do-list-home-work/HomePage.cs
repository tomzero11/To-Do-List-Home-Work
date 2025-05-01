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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update updateForm = new Update();
            updateForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Create createPage = new Create();
            createPage.ShowDialog(); // Gunakan ShowDialog agar modal

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadPage readForm = new ReadPage();
            readForm.ShowDialog();
        }
    }
    }
