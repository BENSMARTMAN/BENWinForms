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
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.VisualElements;

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
                // 用區域名稱groupby
                var groupedByAreaName = parkingLotAPIResponse.ParkingLots.GroupBy(g => g.AreaName);
                // 用Select去選取區域名稱和總停車格數量
                // new { ... } => 匿名型別 
                var totalSpacesByAreaName = groupedByAreaName.Select(g => new
                {
                    areaName = g.Key, // 區域名稱
                    totalSpaces = g.Sum(p => p.TotalSpace) // 停車位數量
                }).ToList();
                // 產生圖表 (折線圖)
                cartesianChart1.Series =
                [
                    new LineSeries<int>
                    {
                        Values = totalSpacesByAreaName.Select(t => t.totalSpaces) // 用Select選取總停車格數量
                    },
                ];
                // 設定圖表上方的標題
                cartesianChart1.Title = new LabelVisual
                {
                    Text = "每個區域的停車場總數量",
                    TextSize = 25,
                    Padding = new LiveChartsCore.Drawing.Padding(15),
                    Paint = new SolidColorPaint(SKColors.DarkSlateGray)
                };
                //設定圖表X軸的資訊
                cartesianChart1.XAxes =
                [
                    new Axis
                    {
                        // Use the labels property to define named labels.
                        Labels = totalSpacesByAreaName.Select(t => t.areaName).ToList(),
                        Name = "區域名稱",
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        LabelsPaint = new SolidColorPaint(SKColors.Blue),
                        TextSize = 16,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 }
                    }
                ];
                //設定圖表Y軸的資訊
                cartesianChart1.YAxes =
                [
                    new Axis
                    {
                        Name = "停車位數量",
                        NamePaint = new SolidColorPaint(SKColors.Red),
                        LabelsPaint = new SolidColorPaint(SKColors.Green),
                        TextSize = 20,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                        {
                            StrokeThickness = 2,
                            PathEffect = new DashEffect(new float[] { 3, 3 })
                        }
                    }
                ];
                // groupby停車場名稱->Sum停車格數量->OrderByDescending停車格數量->Take(10)取前10名->ToList轉成陣列 (chained methods/functions)
                var top10ParkingLots = parkingLotAPIResponse.ParkingLots
                    .GroupBy(g => g.ParkName)
                    .Select(g => new
                    {
                        parkName = g.Key,
                        totalSpaces = g.Sum(p => p.TotalSpace),
                    })
                    .OrderByDescending(p => p.totalSpaces)
                    .Take(10)
                    .ToList();
                // 顯示直條圖
                cartesianChart2.Series =
                [
                    new ColumnSeries<int>
                    {
                        Values = top10ParkingLots.Select(t => t.totalSpaces).ToList(), // 選取停車格數量
                    }
                ];
                // 設定圖表上方的標題
                cartesianChart2.Title = new LabelVisual
                {
                    Text = "前十名停車位最多的停車場",
                    TextSize = 25,
                    Padding = new LiveChartsCore.Drawing.Padding(15),
                    Paint = new SolidColorPaint(SKColors.DarkSlateGray)
                };
                // 設定X軸的資訊
                cartesianChart2.XAxes =
                [
                    new Axis
                    {
                        //設定X軸的標籤，使用Select選取停車場名稱，最後用ToList()轉成陣列
                        Labels = top10ParkingLots.Select(t => t.parkName).ToList(),
                        Name = "停車場名稱",
                        TextSize = 12,
                        LabelsRotation = 45
                    }
                ];
                // 設定Y軸的資訊
                cartesianChart2.YAxes =
                [
                    new Axis
                    {
                        Name = "停車位數量",
                        NamePaint = new SolidColorPaint(SKColors.Red),
                        LabelsPaint = new SolidColorPaint(SKColors.Green),
                        TextSize = 20,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                        {
                            StrokeThickness = 2,
                            PathEffect = new DashEffect([3, 3])
                        }
                    }
                ];
                //pieChart1.Series =
                //[
                //    new PieSeries<int>
                //    {
                //        Values = new []{ 2 },
                //        Name = "Income",
                //    },
                //    new PieSeries<int>
                //    {
                //        Values = new []{ 3 },
                //        Name = "Expense",
                //    }
                //];
                pieChart1.Series = totalSpacesByAreaName
                    .OrderByDescending(t => t.totalSpaces)
                    .Select(t => new PieSeries<int>
                    {
                        Values = new List<int> { t.totalSpaces },
                        Name = t.areaName,
                        DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                        DataLabelsSize = 22,
                        // for more information about available positions see:
                        // https://livecharts.dev/api/2.0.0-rc2/LiveChartsCore.Measure.PolarLabelsPosition
                        DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                        DataLabelsFormatter = p => t.areaName + ": " + t.totalSpaces
                    })
                    .ToList();
                // 設定圖表上方的標題
                pieChart1.Title = new LabelVisual
                {
                    Text = "桃園市停車位數量圓餅圖",
                    TextSize = 25,
                    Padding = new LiveChartsCore.Drawing.Padding(15),
                    Paint = new SolidColorPaint(SKColors.DarkSlateGray)
                };


                MessageBox.Show("下載成功");
            }
            

        }

        private void blueButtonContainer1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }
    }
}
