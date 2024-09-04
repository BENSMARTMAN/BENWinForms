using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ClosedXML.Excel;

namespace BENWinForms
{
    public partial class FormInternet : Form
    {
        

        public List<StockData> StockDatas { get; set; } = new List<StockData>();
        public List<OfficialData> OfficialData { get; set; } = new List<OfficialData>();
        public FormInternet()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //畫面上將url存起來
            string url = textBox1.Text;
            //透過url位置去把檔案抓下來httpClient
            using (HttpClient httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(url).Result;
                //抓下來的檔案先存起來
                File.WriteAllText("stock.csv", data);
                //直接開啟檔案
                //ProcessStartInfo psi = new ProcessStartInfo()
                //{ 
                //FileName = "stock.csv",
                //UseShellExecute = true,
                //};
                //Process.Start(psi);
                List<string> lines = new List<string>();
                lines = data.Split("\r\n").ToList();
                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);

                }
                // 用類別把資料接起來
                List<StockData> stocks = new List<StockData>();

                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i] = lines[i].Replace("\"", "");
                    if (i == 0)
                    {
                        continue;
                    }
                    var items = lines[i].Split(",").ToList();
                    if (items.Count < 2)
                    {
                        continue;
                    }
                    StockData stockData = new StockData();
                    stockData.ID = items[0];
                    stockData.StockName = items[1];
                    // Generate rest
                    stockData.StockTraded = int.TryParse(items[2], out _) ? int.Parse(items[2]) : 0;
                    stockData.HighestAmount = double.TryParse(items[5], out _) ? double.Parse(items[5]) : 0;
                    stockData.AmountChanged = double.TryParse(items[8], out _) ? double.Parse(items[8]) : 0;
                    stocks.Add(stockData);
                    StockDatas.Add(stockData);
                }
                dataGridViewData.DataSource = stocks;
            }





        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // using在這裡代表程式結束後會對資源釋放
                using (var workbook = new XLWorkbook())
                {
                    // 新增一個活頁 (worksheeet)
                    var worksheet = workbook.Worksheets.Add("股票資訊");
                    // 把標頭寫到A1 ~ E1儲存格
                    worksheet.Cell("A1").Value = "證券代號";
                    worksheet.Cell("B1").Value = "證券名稱";
                    worksheet.Cell("C1").Value = "成交股數";
                    worksheet.Cell("D1").Value = "最高金額";
                    worksheet.Cell("E1").Value = "漲價跌差";
                    // 針對股票物件陣列去跑迴圈
                    for (int i = 0; i < StockDatas.Count; i++)
                    {
                        // 目前迴圈當前的股票物件 (第i個資料列)
                        var stock = StockDatas[i];
                        // 把每筆資料塞到目前Excel中的資料列 Cell(水平列位置、垂直欄位位置) 記得Excel起始值是從1開始不是0。
                        worksheet.Cell(i + 2, 1).Value = stock.ID;
                        worksheet.Cell(i + 2, 2).Value = stock.StockName;
                        worksheet.Cell(i + 2, 3).Value = stock.StockTraded;
                        worksheet.Cell(i + 2, 4).Value = stock.HighestAmount;
                        worksheet.Cell(i + 2, 5).Value = stock.AmountChanged;
                        // 根據漲跌條件顯示綠色或紅色
                        if (stock.AmountChanged > 0)
                        {
                            // set to green
                            worksheet.Cell(i + 2, 5).Style.Font.FontColor = XLColor.Green;
                        }
                        else
                        {
                            worksheet.Cell(i + 2, 5).Style.Font.FontColor = XLColor.Red;
                        }
                    }
                    // 把Excel存起來
                    workbook.SaveAs("stockReport.xlsx");
                    // 開檔案
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = "stockReport.xlsx",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                // 跳出可能發生的錯誤
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDL_Click(object sender, EventArgs e)
        {
            //畫面上將url存起來
            string url = textBox2.Text;
            //透過url位置去把檔案抓下來httpClient
            using (HttpClient httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(url).Result;
                //抓下來的檔案先存起來
                File.WriteAllText("Official.csv", data);
                //直接開啟檔案

                List<string> lines = data.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (string line in lines)
                {
                    listBox2.Items.Add(line);

                }
                // 用類別把資料接起來
                List<OfficialData> official = new List<OfficialData>();

                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i] = lines[i].Replace("\"", "");
                    if (i == 0)
                    {
                        continue;
                    }
                    var items = lines[i].Split(",").ToList();
                    if (items.Count < 2)
                    {
                        continue;
                    }
                    OfficialData officialdata = new OfficialData();
                    officialdata.country = items[0];
                    officialdata.district = items[1];
                    officialdata.segment = items[2];
                    // Generate rest
                    officialdata.lid = int.TryParse(items[3], out _) ? int.Parse(items[3]) : 0;
                    officialdata.official_value = int.TryParse(items[4], out _) ? int.Parse(items[4]) : 0;
                    officialdata.official_price = int.TryParse(items[5], out _) ? int.Parse(items[5]) : 0;
                    official.Add(officialdata);
                    OfficialData.Add(officialdata);
                }
                dataGridView1.DataSource = official;
            }
        }

        private void buttonExportExcel2_Click(object sender, EventArgs e)
        {
            try
            {
                // using在這裡代表程式結束後會對資源釋放
                using (var workbook = new XLWorkbook())
                {   
                    // 新增一個活頁 (worksheeet)
                    var worksheet = workbook.Worksheets.Add("113年淡水區公告土地現值及地價");
                    // 方法一:把標頭寫到A1 ~ E1儲存格
                    worksheet.Cell("A1").Value = "縣市別";
                    worksheet.Cell("B1").Value = "行政區";
                    worksheet.Cell("C1").Value = "段小段";
                    worksheet.Cell("D1").Value = "地號";
                    worksheet.Cell("E1").Value = "公告土地現值";
                    worksheet.Cell("F1").Value = "公告地價";

                    //方法二:陣列設標頭名稱
                    //List<string> headerNames = ["縣市別", "行政區", "段小段", "地號", "公告土地現值", "公告地價"];
                    //// set datagridview header names to above
                    //for (int i = 0; i < headerNames.Count; i++)
                    //{
                    //    dataGridView1.Columns[i].HeaderText = headerNames[i];
                    //}

                    // 針對物件陣列去跑迴圈
                    for (int i = 0; i < OfficialData.Count; i++)
                    {
                        // 目前迴圈當前的物件 (第i個資料列)
                        var official = OfficialData[i];
                        // 把每筆資料塞到目前Excel中的資料列 Cell(水平列位置、垂直欄位位置) 記得Excel起始值是從1開始不是0。
                        worksheet.Cell(i + 2, 1).Value = official.country;
                        worksheet.Cell(i + 2, 2).Value = official.district;
                        worksheet.Cell(i + 2, 3).Value = official.segment;
                        worksheet.Cell(i + 2, 4).Value = official.lid;
                        worksheet.Cell(i + 2, 5).Value = official.official_value;
                        worksheet.Cell(i + 2, 6).Value = official.official_price;
                        
                    }
                    // 把Excel存起來
                    workbook.SaveAs("officialReport.xlsx");
                    // 開檔案
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = "officialReport.xlsx",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                // 跳出可能發生的錯誤
                MessageBox.Show(ex.Message);
            }
        }
    }
}
