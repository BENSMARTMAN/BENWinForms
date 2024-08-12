using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using Dapper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BENWinForms
{
    public partial class Form1 : Form
    {
        public string ConnString { get; set; }
        private List<string> accountInfoList = new List<string>();
        //private List<Items> items = new List<Items>();
        private DataTable itemsTable = new DataTable();
        string Sqllink = @"Server=192.168.1.9;Database=_SmartManTest;User Id=SYSADM;Password=SYSADM";
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnHeaderMouseDoubleClick += dataGridView1_ColumnHeaderMouseDoubleClick;
            SearchBox.TextChanged += SearchBox_TextChanged;

            // 創建 TabControl
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // 創建第一個 TabPage
            TabPage tabPage1 = new TabPage("Tab 1");
            // 添加其他控件到 tabPage1

            // 創建第二個 TabPage
            TabPage tabPage2 = new TabPage("Tab 2");
            // 添加其他控件到 tabPage2

            // 將 TabPages 添加到 TabControl
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            // 將 TabControl 添加到窗體
            this.Controls.Add(tabControl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string account = textBox1.Text;
            string password = textBox2.Text;
            string description = textBox3.Text;
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("帳號、密碼和說明欄位均不得為空白！");
                return;
            }
            string strength = CheckPasswordStrength(password);
            string info = $"帳號: {account}, 密碼:{password}, 說明: {description}, 密碼強度: {strength} ";
            listBox1.Items.Add(info);
            label4.Text = "密碼強度: " + strength;


            // 清空 TextBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
        private string CheckPasswordStrength(string password)
        {
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;
            bool isLongEnough = password.Length >= 8;

            // 特殊符號的檢查
            string specialChars = "!@#$%^&*";
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                else if (char.IsLower(c)) hasLowerCase = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (specialChars.Contains(c)) hasSpecialChar = true;
            }

            int criteriaCount = 0;

            if (hasUpperCase) criteriaCount++;
            if (hasLowerCase) criteriaCount++;
            if (hasDigit) criteriaCount++;
            if (hasSpecialChar) criteriaCount++;
            if (isLongEnough) criteriaCount++;

            switch (criteriaCount)
            {
                case 5:
                    return "強";
                case 4:
                case 3:
                    return "中";
                default:
                    return "弱";
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("請選擇一個帳號");
                return;
            }

            listBox1.Items.RemoveAt(selectedIndex);

            MessageBox.Show("移除成功!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"
                        Server=192.168.1.9;
                        Database=_SmartManTest;
                        User Id=SYSADM;
                        Password=SYSADM";
                this.ConnString = conn.ConnectionString;
                ItemsService.ConnString = conn.ConnectionString;
                conn.Open();
                MessageBox.Show("連線成功!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤: " + ex.Message + "哪裡錯?" + ex.StackTrace);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // check if a row is selected
            bool isSelected = dataGridView1.SelectedRows.Count > 0;
            // get the Items data from row
            // 把物品資料抓出來
            Items items = new Items();
            if (isSelected)
            {
                items.Name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                items.Description = dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString();
                items.MarketValue = dataGridView1.SelectedRows[0].Cells["MarketValue"].Value.ToString();
                items.Quantity = dataGridView1.SelectedRows[0].Cells["Quantity"].Value.ToString();
                items.Type = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
                items.Id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("請選擇一個物品");
                return;
            }
            FormUpdate formUpdate = new FormUpdate(items);
            formUpdate.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // check if a row is selected
            bool isSelected = dataGridView1.SelectedRows.Count > 0;
            // 檢查有沒有選一行資料列
            if (isSelected == false)
            {
                MessageBox.Show("請選擇一個物品");
                return;
            }
            string Id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
            string Name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            // 跳訊息確定是否要刪除
            var result = MessageBox.Show("確定要刪除" + Name + "嗎?", "刪除物品", MessageBoxButtons.YesNo);
            // 如果選NO就結束
            if (result == DialogResult.No)
            {
                return;
            }
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Execute("Delete From Items Where Id = @ID", new { Id });
            MessageBox.Show("刪除成功");
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            FormNew formNew = new FormNew(items);
            formNew.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormSearch FormSearch = new FormSearch(this);
            FormSearch.Show();
        }
        public void UpdateDataGridView(DataTable dataTable)
        {

            dataGridView1.DataSource = dataTable;
            dataGridView1.AllowUserToAddRows = false;


        }
        public void Query()
        {
            itemsTable.Clear();
            itemsTable.DefaultView.RowFilter = string.Empty;
            itemsTable.DefaultView.Sort = string.Empty;
            SearchBox.Text = string.Empty;
            using (SqlConnection conn = new SqlConnection(Sqllink))
            {
                conn.Open();
                using (var reader = conn.ExecuteReader("Select * From Items"))
                {
                    itemsTable.Load(reader);
                    dataGridView1.DataSource = itemsTable;
                    dataGridView1.AllowUserToAddRows = false;

                    // 设置列排序模式
                    //dataGridView1.Columns["ID"].SortMode = DataGridViewColumnSortMode.Automatic;
                    //dataGridView1.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }

        }



        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                // 切换排序方向
                ListSortDirection direction = ListSortDirection.Ascending;

                if (dataGridView1.SortOrder == System.Windows.Forms.SortOrder.Ascending || dataGridView1.SortOrder == System.Windows.Forms.SortOrder.None)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }

                // 對指定列進行排序
                dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], direction);
            }

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = SearchBox.Text;

            if (string.IsNullOrEmpty(filterText))
            {
                // 如果搜尋框是空的，顯示所有資料
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // 根據輸入內容進行條件搜尋
                string filterExpression = $"Name LIKE '%{filterText}%' OR Type LIKE '%{filterText}%' OR Description LIKE '%{filterText}%'";
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
        }
    }
}
