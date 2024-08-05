using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BENWinForms
{
    public partial class FormNew : Form
    {
        Items items;
        public FormNew(Items items)
        {
            InitializeComponent();
            this.items = items;
            // 初始化員工資料
            this.textBox1.Text = items.Name;
            this.textBox2.Text = items.Description;
            this.textBox3.Text = items.MarketValue;
            this.textBox4.Text = items.Quantity;
            this.textBox5.Text = items.Type;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 存檔
            SqlConnection conn = new SqlConnection(ItemsService.ConnString);
            conn.Open();
            string newName = this.textBox1.Text; // Name
            string newDescription = textBox2.Text; // Description
            string newMarketValue = textBox3.Text; // MarketValue
            string newQuantity = textBox4.Text; // Quantity
            string newType = textBox5.Text; // Type
            conn.Execute("INSERT INTO Items (Name, Description, MarketValue, Quantity, Type, LastUpdated) VALUES( @newName, @newDescription, @newMarketValue, @newQuantity, @newType, GETDATE());",
                new { newName, newDescription, newMarketValue, newQuantity, newType }
                );
            conn.Close();
            MessageBox.Show("存檔成功");
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
