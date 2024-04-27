using SobeeYou.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobeeYou.Models
{
    public class AdminDashboardViewModel
    {
        public List<ProductSalesData> ProductSales { get; set; }
        public List<WebsiteTrafficData> WebsiteTraffic { get; set; }
        public int TotalCustomers { get; set; }
        public int NewCustomers { get; set; }
        public int ActiveCustomers { get; set; }
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public decimal RecentRevenue { get; set; }
        public int TotalProducts { get; set; }
        public int LowInventoryProducts { get; set; }
        public decimal AvgProductRating { get; set; }
        public int TotalUsers { get; set; }
        public int AdminUsers { get; set; }
        public int RecentSupportRequests { get; set; }

     
            public List<ProductSalesData> TotalSales { get; set; }
            public List<ProductSalesData> LastWeekSales { get; set; }
            public List<ProductSalesData> LastMonthSales { get; set; }
        

    }
}
