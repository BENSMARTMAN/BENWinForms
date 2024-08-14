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
using Dapper;

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
                    string query = @"
                SELECT * FROM Items 
                WHERE (@name = '' OR Name LIKE '%' + @name + '%') 
                AND (@type = '' OR Type LIKE '%' + @type + '%') 
                AND (@description = '' OR Description LIKE '%' + @description + '%')";

                    var parameters = new
                    {
                        name,
                        description,
                        type
                    };

                    // 使用 Dapper 执行查询并获取结果
                    var itemsList = conn.Query<Items>(query, parameters).ToList();

                    // 更新 Form1 的 DataGridView
                    Form1.UpdateDataGridView(itemsList);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
