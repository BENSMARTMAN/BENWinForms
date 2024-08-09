using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BENWinForms
{
    public partial class FormSearch : Form
    {
        private Form1 Form1;

        public FormSearch(Form1 form)
        {
            this.Form1 = form;
            InitializeComponent();
        }

        public FormSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string description = textBox2.Text;
            string type = textBox3.Text;

            using (SqlConnection conn = new SqlConnection(ItemsService.ConnString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Items WHERE (@name = '' OR Name LIKE '%' + @name + '%') AND (@type = '' OR Type LIKE '%' + @type + '%') AND (@description = '' OR Description LIKE '%' + @description + '%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@type", type);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    Form1.UpdateDataGridView(dt);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
