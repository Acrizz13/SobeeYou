namespace sobee_core.Models {
    public class OrderDetailsViewModel {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
        public string TrackingNumber { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }

    public class OrderItemViewModel {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
