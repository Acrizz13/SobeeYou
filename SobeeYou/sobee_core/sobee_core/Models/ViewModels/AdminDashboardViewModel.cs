﻿using sobee_core.Classes;

namespace sobee_core.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        // model for admin dashboard info
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
    }
}
