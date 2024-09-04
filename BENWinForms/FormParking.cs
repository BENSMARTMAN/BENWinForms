using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using BENWinForms.DatsModels;

namespace BENWinForms
{
    public partial class FormParking : Form
    {
        public FormParking()
        {
            InitializeComponent();
            blueButtonContainer1.InnerButton.Click += InnerButton_Click;
            blueButtonContainer1.InnerButton.Text = "下載資料";
        }

        private void InnerButton_Click(object? sender, EventArgs e)
        {
            const string url = "https://data.tycg.gov.tw/opendata/datalist/datasetMeta/download?id=f4cc0b12-86ac-40f9-8745-885bddc18f79&rid=0daad6e6-0632-44f5-bd25-5e1de1e9146f";
            using (HttpClient http = new HttpClient())
            {
                var result = http.GetStringAsync(url).Result;

                ParkingLotAPIResponse parkingLotAPIResponse = JsonSerializer.Deserialize<ParkingLotAPIResponse>(result) ?? new ParkingLotAPIResponse();
                dataGridView1.DataSource = parkingLotAPIResponse.ParkingLots;

                List<string> headerNames = ["停車場編號", "區域ID", "區域名稱", "停車場名稱", "總停車格數量", "狀態", "剩餘空間", "價格資訊", "說明", "位址", "經度", "緯度"];
                // set datagridview header names to above
                for (int i = 0; i < headerNames.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderText = headerNames[i];
                }
                using (ClosedXML.Excel.XLWorkbook workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    // handle export
                    var worksheet = workbook.Worksheets.Add("原始停車資料");
                    for (int i = 0; i < headerNames.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = headerNames[i];
                    }
                    // 直接把陣列放到整個工作表
                    worksheet.Cell(2, 1).InsertData(parkingLotAPIResponse.ParkingLots);
                    var worksheet2 = workbook.Worksheets.Add("停車場統計資料");
                    // 統計前十名的停車格數量最多的停車場
                    var top10 = parkingLotAPIResponse.ParkingLots.OrderByDescending(p => p.TotalSpace).Take(10).ToList();
                    worksheet2.Cell(1, 1).Value = "停車場名稱";
                    worksheet2.Cell(1, 2).Value = "地址";
                    worksheet2.Cell(1, 3).Value = "停車格數量";
                    for (int i = 0; i < top10.Count; i++)
                    {
                        worksheet2.Cell(i + 2, 1).Value = top10[i].ParkName;
                        worksheet2.Cell(i + 2, 2).Value = top10[i].Address;
                        worksheet2.Cell(i + 2, 3).Value = top10[i].TotalSpace;
                    }
                    // 使用區域groupby資料放到不同活頁
                    var groupByArea = parkingLotAPIResponse.ParkingLots.GroupBy(p => p.AreaName);
                    foreach (var group in groupByArea)
                    {
                        // 根據區域名稱新增活頁 (group.Key為每個分群是依照什麼去分的，也就是區域名稱)
                        var worksheetByArea = workbook.Worksheets.Add(group.Key);
                        // 用Where去篩選出區域名稱相同的停車場 (每分群裡面都是停車物件資訊，group.ToList()把這些物件資料轉成陣列)
                        var parkLotsByArea = group.ToList();
                        for (int i = 0; i < headerNames.Count; i++)
                        {
                            worksheetByArea.Cell(1, i + 1).Value = headerNames[i];
                        }
                        worksheetByArea.Cell(2, 1).InsertData(parkLotsByArea);
                    }
                    workbook.SaveAs("Parklot.xlsx");
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = "Parklot.xlsx",
                        UseShellExecute = true,
                    };
                    System.Diagnostics.Process.Start(psi);
                }
                MessageBox.Show("下載成功");
            }
        }

        private void blueButtonContainer1_Load(object sender, EventArgs e)
        {

        }
    }
}
