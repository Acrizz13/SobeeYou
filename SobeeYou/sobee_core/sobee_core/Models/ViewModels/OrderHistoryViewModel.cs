﻿namespace sobee_core.Models.ViewModels
{
    public class OrderHistoryViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}
