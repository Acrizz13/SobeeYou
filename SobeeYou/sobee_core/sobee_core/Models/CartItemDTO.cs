﻿namespace sobee_core.Models {
    public class CartItemDTO {

        public int intProductID { get; set; }
        public int intQuantity { get; set; }
        public DateTime dtmDateAdded { get; set; }
        public string strProductName { get; set; }
        public decimal decPrice { get; set; }
    }
}
