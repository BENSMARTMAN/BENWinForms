using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BENWinForms.DatsModels
{
    public class ParkingLot
    {
        /*
         * {
    "parkId" : "P-BD-001",
    "areaId" : "3",
    "areaName" : "八德區",
    "parkName" : "大湳公有停車場(桃交)",
    "totalSpace" : 207,
    "Display" : "168",
    "surplusSpace" : "168",
    "payGuide" : "小型車-臨停:30/時，小型車-月租:3600/月",
    "introduction" : "八德區公所管轄之公有停車場",
    "address" : "廣福路42號(廣福段258地號)",
    "wgsX" : 24.959,
    "wgsY" : 121.2985
  }
         */
        [JsonPropertyName("parkId")]
        public string ParkId { get; set; } = "";
        [JsonPropertyName("areaId")]
        public string AreaId { get; set; } = "";
        [JsonPropertyName("areaName")]
        public string AreaName { get; set; } = "";
        [JsonPropertyName("parkName")]
        public string ParkName { get; set; } = "";
        [JsonPropertyName("totalSpace")]
        public int TotalSpace { get; set; }
        [JsonPropertyName("Display")]
        public string Display { get; set; } = "";
        [JsonPropertyName("surplusSpace")]
        public string SurplusSpace { get; set; } = "";
        [JsonPropertyName("payGuide")]
        public string PayGuide { get; set; } = "";
        [JsonPropertyName("introduction")]
        public string Introduction { get; set; } = "";
        [JsonPropertyName("address")]
        public string Address { get; set; } = "";
        [JsonPropertyName("wgsX")]
        public double WgsX { get; set; }
        [JsonPropertyName("wgsY")]
        public double WgsY { get; set; }

    }
    public class ParkingLotAPIResponse
    {
        [JsonPropertyName("parkingLots")]
        public List<ParkingLot> ParkingLots { get; set; } = new List<ParkingLot>();
    }
}
