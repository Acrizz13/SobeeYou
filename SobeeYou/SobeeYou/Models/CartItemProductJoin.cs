using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class CartItemProductJoin {
        public int intProductID { get; set; }
        public int intQuantity { get; set; }
        public DateTime dtmDateAdded { get; set; }
        public string strProductName { get; set; }
        public string decPrice { get; set; }
    }
}