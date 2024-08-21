using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BENWinForms
{
    public partial class FormFiles : Form
    {
        List<Items> items = new List<Items>();
        public FormFiles()
        {
            InitializeComponent();
            buttonOpenFiles.Click += buttonOpenFiles_Click;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormFiles_Load(object sender, EventArgs e)
        {

        }

        private void buttonOpenFiles_Click(object sender, EventArgs e)
        {
            //顯示剛剛抓得檔案名稱
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                labelFileName.Text = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                listBoxFileData.Items.Clear();
                foreach (string item in lines)
                {
                    listBoxFileData.Items.Add(item);
                }
               
                for (var i = 0; i < lines.Length; i++)
                {
                    var splitData = lines[i].Split(",");
                    Items item = new Items();
                    item.Name = splitData[0];
                    item.Type = splitData[1];
                    item.MarketValue = splitData[2];
                    item.Quantity = splitData[3];
                    item.Description = splitData[4];
                    items.Add(item);

                }
                dataGridView.DataSource = items;
            }

        }

        private void buttonCreateFiles_Click(object sender, EventArgs e)
        {
            //將匯入資料再轉出去一次，但可以指定路徑
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            var result = saveFileDialog.ShowDialog();
            List<string> lines = new List<string>();
            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                lines.Append("名稱,種類,價值,數量,描述");
                foreach (var item in items)
                {
                    string singleLineData = item.Name + "," + item.Type + "," +
                        item.MarketValue + "," + item.Quantity.ToString() + "," + item.Description;
                    lines.Add(singleLineData);

                }
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("儲存到" + filePath + "了");
            }
        }
    }
}
