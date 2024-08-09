using Dapper;
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

namespace BENWinForms
{
    public partial class FormUpdate : Form
    {
        Items items;
        public FormUpdate(Items items)
        {
            InitializeComponent();
            this.items = items;
            // 初始化員工資料
            this.textBox1.Text = items.Name;
            this.textBox2.Text = items.Description;
            this.textBox3.Text = items.MarketValue;
            this.textBox4.Text = items.Quantity;
            this.textBox5.Text = items.Type;
            this.textBox6.Text = items.Id;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 存檔
            SqlConnection conn = new SqlConnection(ItemsService.ConnString);
            conn.Open();
            string updatedName = this.textBox1.Text; // Name
            string updatedDescription = textBox2.Text; // Description
            string updatedMarketValue = textBox3.Text; // MarketValue
            string updatedQuantity = textBox4.Text; // Quantity
            string updatedType = textBox5.Text; // Type
            string ID = textBox6.Text; // ID
            if (!decimal.TryParse(updatedMarketValue, out decimal marketValue) || marketValue <= 0 ||
            !int.TryParse(updatedQuantity, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("價值或數量請輸入正數");
                return;
            }
            conn.Execute("Update Items Set Name = @updatedName, Description = @updatedDescription, MarketValue = @updatedMarketValue, Quantity = @updatedQuantity , Type = @updatedType , LastUpdated = FORMAT(GETDATE(), 'yyyy-MM-dd HH:mm')  Where Id = @ID",
                new { updatedName, updatedDescription, updatedMarketValue, updatedQuantity, updatedType, ID }
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
