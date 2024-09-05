using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using BENWinForms.DatsModels;
using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BENWinForms
{
    public partial class Form1 : Form
    {
        public string ConnString { get; set; }
        private List<string> accountInfoList = new List<string>();
        private List<Items> itemsList = new List<Items>();
        //public event Action OnDataUpdated;
        //private DataTable itemsTable = new DataTable();
        private SqlConnection GetDatabaseConnection()
        {
            //var connectionString = "Server=127.0.0.1;Database=HRIS;User Id=SYSADM;Password=SYSADM";
            var connectionString = "Server=192.168.1.9;Database=_SmartManTest;User Id=SYSADM;Password=SYSADM";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        string Sqllink = @"Server=192.168.1.9;Database=_SmartManTest;User Id=SYSADM;Password=SYSADM";

        public Form1()
        {
            InitializeComponent();
            //dataGridView1.ColumnHeaderMouseDoubleClick += dataGridView1_ColumnHeaderMouseDoubleClick;
            SearchBox.TextChanged += SearchBox_TextChanged;
            buttonOpenFile.Click += buttonOpenFile_Click;

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
        private void buttonSave_Click(object sender, EventArgs e)
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
        private void buttonDelete_Click(object sender, EventArgs e)
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
        private void buttonConnection_Click(object sender, EventArgs e)
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
        private void buttonDataShow_Click(object sender, EventArgs e)
        {
            Query();
            SearchBox.Text = "";
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
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
            // 订阅事件
            formUpdate.OnDataUpdated += () =>
            {
                Query(); // 重新加载数据
            };
            formUpdate.ShowDialog();
        }
        private void buttonRemove_Click(object sender, EventArgs e)
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
            Query();
            conn.Close();
        }
        private void buttonNew_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            FormNew formNew = new FormNew(items);
            formNew.OnDataUpdated += () =>
            {
                Query(); // 重新加载数据
            };
            formNew.ShowDialog();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearch FormSearch = new FormSearch(this);
            FormSearch.Show();
        }
        public void UpdateDataGridView(List<Items> itemsList)
        {

            dataGridView1.DataSource = new BindingList<Items>(itemsList);
            dataGridView1.AllowUserToAddRows = false;


        }
        public void Query()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=192.168.1.9;Database=_SmartManTest;User Id=SYSADM;Password=SYSADM";
            //conn.ConnectionString = @"Server=127.0.0.1;Database=HRIS;User Id=SYSADM;Password=SYSADM";
            this.ConnString = conn.ConnectionString;
            ItemsService.ConnString = conn.ConnectionString;
            conn.Open();

            // 使用 Dapper 查询并映射到 Items 列表
            string query = "SELECT * FROM Items";
            itemsList = conn.Query<Items>(query).ToList();


            // 将列表绑定到 DataGridView
            dataGridView1.DataSource = new BindingList<Items>(itemsList);
            dataGridView1.AllowUserToAddRows = false;
            AddCheckBoxColumn();

        }
        private void LoadData()
        {
            // 使用 Dapper 從資料庫中加載數據
            using (var connection = GetDatabaseConnection())
            {
                var query = "SELECT * FROM Items";  // 根據實際情況修改表名稱
                var items = connection.Query<Items>(query).ToList();


                // 清除之前的資料
                dataGridView1.DataSource = null;

                // 綁定新的資料
                dataGridView1.DataSource = items;
                AddCheckBoxColumn();
            }
        }
        bool[] isAscendingFlags = [false, false, false, false, false, false, false, false];
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string lastSortedColumn = string.Empty;
            //bool ascending = true;
            //五個欄位是否升冪排序flag
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            //if (lastSortedColumn == columnName)
            //{
            //ascending = !ascending;
            //}
            //else
            //{
            //ascending = true;
            //lastSortedColumn = columnName;
            //}
            isAscendingFlags[e.ColumnIndex] = !isAscendingFlags[e.ColumnIndex];
            bool isAscending = isAscendingFlags[e.ColumnIndex];

            switch (columnName)
            {

                case "Name":
                    itemsList = isAscending ?
                                itemsList.OrderBy(item => item.Name).ToList() :
                                itemsList.OrderByDescending(item => item.Name).ToList();
                    break;
                case "Description":
                    itemsList = isAscending ?
                                itemsList.OrderBy(item => item.Description).ToList() :
                                itemsList.OrderByDescending(item => item.Description).ToList();
                    break;
                case "MarketValue":
                    itemsList = isAscending ?
                                itemsList.OrderBy(item => int.Parse(item.MarketValue)).ToList() :
                                itemsList.OrderByDescending(item => int.Parse(item.MarketValue)).ToList();
                    break;
                case "Quantity":
                    itemsList = isAscending ?
                               itemsList.OrderBy(item => int.Parse(item.Quantity)).ToList() :
                               itemsList.OrderByDescending(item => int.Parse(item.Quantity)).ToList();
                    break;
                case "Type":
                    itemsList = isAscending ?
                                itemsList.OrderBy(item => item.Type).ToList() :
                                itemsList.OrderByDescending(item => item.Type).ToList();
                    break;
                case "LastUpdated":
                    itemsList = isAscending ?
                                itemsList.OrderBy(item => item.LastUpdated).ToList() :
                                itemsList.OrderByDescending(item => item.LastUpdated).ToList();
                    break;
                default:
                    break;
            }

            // 更新 DataGridView 的数据源
            dataGridView1.DataSource = new BindingList<Items>(itemsList);


        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = SearchBox.Text;

            if (string.IsNullOrEmpty(filterText))
            {
                // 如果搜尋框是空的，顯示所有資料
                dataGridView1.DataSource = new BindingList<Items>(itemsList);
            }
            else
            {
                // 根據輸入內容進行條件搜尋
                var filteredList = itemsList.Where(item =>
                    item.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase) ||
                    item.Type.Contains(filterText, StringComparison.OrdinalIgnoreCase) ||
                    item.Description.Contains(filterText, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                // 更新 DataGridView 的数据源
                dataGridView1.DataSource = new BindingList<Items>(filteredList);
            }
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            var result = saveFileDialog.ShowDialog();
            List<string> lines = new List<string>();
            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                lines.Append("項次,名稱,描述,價值,數量,種類");
                foreach (var item in itemsList)
                {
                    string singleLineData = item.Id + "," + item.Name + "," + item.Description + "," +
                        item.MarketValue + "," + item.Quantity.ToString() + "," + item.Type;
                    lines.Add(singleLineData);

                }
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("儲存到" + filePath + "了");
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV 檔案 (*.csv)|*.csv";
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // 讀取 CSV 檔案的所有行
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                using (var connection = GetDatabaseConnection())
                {

                    // 解析每行數據，並將其加入 itemsList
                    foreach (string line in lines)
                    {
                        var splitData = line.Split(",");

                        // 設定每個項目的屬性
                        Items item = new Items
                        {
                            Name = splitData[1],
                            Description = splitData[2],
                            MarketValue = splitData[3],
                            Quantity = splitData[4],
                            Type = splitData[5],
                            //LastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  // 更新時間
                        };

                        // 使用 Dapper 來執行 INSERT 操作，ID 會自動生成
                        var query = @"INSERT INTO Items (Name, Description, MarketValue, Quantity, Type, LastUpdated) 
                                    VALUES( @Name, @Description, @MarketValue, @Quantity, @Type, GETDATE());";
                        connection.Execute(query, item);

                        // 也可將新增的項目加入到 itemsList 中
                        itemsList.Add(item);
                    }

                    // 因為 DataGridView 綁定的是 itemsList，所以只需要更新綁定
                    dataGridView1.DataSource = null;  // 重新綁定前，解除綁定
                    dataGridView1.DataSource = itemsList;  // 重新綁定到更新後的 itemsList
                }
            }


        }
        private void AddCheckBoxColumn()
        {
            // 確認 DataGridView 中是否已經存在 CheckBox 欄位
            if (!dataGridView1.Columns.Contains("chkColumn"))
            {
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.HeaderText = "選取";
                chkColumn.Name = "chkColumn";
                dataGridView1.Columns.Add(chkColumn);
            }
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            // 確認使用者是否確定要刪除
            var confirmResult = MessageBox.Show("確定要刪除選取的資料嗎？",
                                                "批次刪除確認",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                List<string> selectedIds = new List<string>();

                // 蒐集選中的行的 ID
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells["chkColumn"] as DataGridViewCheckBoxCell;

                    if (chkCell != null && Convert.ToBoolean(chkCell.Value))
                    {
                        var itemId = row.Cells["Id"].Value.ToString();
                        selectedIds.Add(itemId);
                    }
                }

                if (selectedIds.Count > 0)
                {
                    // 從資料庫中刪除選取的項目
                    using (var connection = GetDatabaseConnection())
                    {
                        // 使用 SQL 中的 IN 子句來一次刪除多個項目
                        var deleteQuery = "DELETE FROM Items WHERE Id IN @Ids";
                        connection.Execute(deleteQuery, new { Ids = selectedIds });

                        // 更新 DataGridView 的資料來源
                        LoadData();
                    }

                    MessageBox.Show("選取的資料已成功刪除");
                }
                else
                {
                    MessageBox.Show("請選取至少一筆資料進行刪除");
                }
            }
        }

        private void buttonDLtoExcel_Click(object sender, EventArgs e)
        {
            List<string> headerNames = ["項次","名稱","描述","價值","數量","種類","最後更新日"];
            for (int i = 0; i < headerNames.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = headerNames[i];
            }

            using (ClosedXML.Excel.XLWorkbook workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("原始物品資料");
                SetHeaderStyle(worksheet, headerNames); // 呼叫函數設置表頭樣式
                // 設置MarketValue欄位為數字格式，右對齊並設置為貨幣格式
                for (int row = 2; row <= itemsList.Count + 1; row++)
                {
                    // 嘗試將MarketValue轉換為整數
                    int marketValue;
                    if (int.TryParse(worksheet.Cell(row, 4).GetString(), out marketValue))
                    {
                        worksheet.Cell(row, 4).Value = marketValue;  // 將轉換成功的整數設為儲存格的值
                        worksheet.Cell(row, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
                        worksheet.Cell(row, 4).Style.NumberFormat.Format = "$#,##0";
                    }
                }
                //worksheet.Columns().AdjustToContents(); // 根據內容自動調整所有欄位寬度

                worksheet.Cell(2, 1).InsertData(itemsList);
                var worksheet2 = workbook.Worksheets.Add("價值前三高物品");
                SetHeaderStyle(worksheet2, new List<string> { "項次", "名稱", "數量", "價值" }); // 設置不同標題
                var top3 = itemsList.OrderByDescending(p => int.Parse(p.MarketValue)).Take(3).ToList();
                //worksheet2.Cell(1, 1).Value = "項次";
                //worksheet2.Cell(1, 2).Value = "名稱";
                //worksheet2.Cell(1, 3).Value = "數量";
                //worksheet2.Cell(1, 4).Value = "價值";
                for (int i = 0; i < top3.Count; i++)
                {
                    worksheet2.Cell(i + 2, 1).Value = top3[i].Id;
                    worksheet2.Cell(i + 2, 2).Value = top3[i].Name;
                    worksheet2.Cell(i + 2, 3).Value = top3[i].Quantity;
                    worksheet2.Cell(i + 2, 4).Value = top3[i].MarketValue;
                    // 嘗試將MarketValue轉換為整數
                    int marketValue;
                    if (int.TryParse(top3[i].MarketValue, out marketValue))
                    {
                        worksheet2.Cell(i + 2, 4).Value = marketValue;  // 將轉換成功的整數設為儲存格的值
                        worksheet2.Cell(i + 2, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
                        worksheet2.Cell(i + 2, 4).Style.NumberFormat.Format = "$#,##0";
                    }
                }
                // 計算總價值（價值 * 數量）
                int totalValue = top3.Sum(item => int.Parse(item.MarketValue) * int.Parse(item.Quantity));

                // 在最後一行顯示總價值並設定字體為紅色
                worksheet2.Cell(5, 1).Value = "總價值";
                worksheet2.Cell(5, 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;
                worksheet2.Cell(5, 4).Value = totalValue;
                worksheet2.Cell(5, 4).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;
                worksheet2.Cell(5, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
                worksheet2.Cell(5, 4).Style.NumberFormat.Format = "$#,##0";

                var groupByArea = itemsList.GroupBy(p => p.Type);
                foreach (var group in groupByArea)
                {
                    var worksheetByArea = workbook.Worksheets.Add(group.Key);
                    SetHeaderStyle(worksheetByArea, headerNames); // 呼叫函數設置表頭樣式
                    var itemsByType = group.ToList();
                    for (int i = 0; i < headerNames.Count; i++)
                    {
                        worksheetByArea.Cell(1, i + 1).Value = headerNames[i];
                    }
                    worksheetByArea.Cell(2, 1).InsertData(itemsByType);
                    // 設置MarketValue欄位為整數格式，右對齊並設置為貨幣格式
                    for (int row = 2; row <= itemsByType.Count + 1; row++)
                    {
                        int marketValue;
                        if (int.TryParse(worksheetByArea.Cell(row, 4).GetString(), out marketValue))
                        {
                            worksheetByArea.Cell(row, 4).Value = marketValue;  // 將轉換成功的整數設為儲存格的值
                            worksheetByArea.Cell(row, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
                            worksheetByArea.Cell(row, 4).Style.NumberFormat.Format = "$#,##0";
                        }
                    }
                    // 計算每個分頁的總價值
                    int totalValueByType = itemsByType.Sum(item => int.Parse(item.MarketValue) * int.Parse(item.Quantity));

                    // 在分頁的最後一行顯示總價值並設定為紅色
                    int lastRow = itemsByType.Count + 2;  // 確定顯示總價值的行
                    worksheetByArea.Cell(lastRow, 1).Value = "總價值";
                    worksheetByArea.Cell(lastRow, 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;
                    worksheetByArea.Cell(lastRow, 4).Value = totalValueByType;
                    worksheetByArea.Cell(lastRow, 4).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;
                    worksheetByArea.Cell(lastRow, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
                    worksheetByArea.Cell(lastRow, 4).Style.NumberFormat.Format = "$#,##0";
                }
                workbook.SaveAs("Summary.xlsx");
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = "Summary.xlsx",
                    UseShellExecute = true,
                };
                System.Diagnostics.Process.Start(psi);
            }
            MessageBox.Show("下載成功");
        }
        public void SetHeaderStyle(IXLWorksheet worksheet, List<string> headerNames)
        {
            for (int i = 0; i < headerNames.Count; i++)
            {
                var header = worksheet.Cell(1, i + 1);
                header.Value = headerNames[i];
                header.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center; // 文字置中
                header.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Aqua; // 底色設為青色
                // 加上框線
                header.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                header.Style.Border.OutsideBorderColor = ClosedXML.Excel.XLColor.Black;
            }
            
        }

    }
}

