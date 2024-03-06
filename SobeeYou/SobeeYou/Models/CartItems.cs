using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class CartItems {
        public int intCartItemID { get; set; }
        public int intShoppingCartID { get; set; }
        public int intProductID { get; set; }
        public int intQuantity { get; set; }
        public DateTime dtmDateAdded { get; set; }
    }
}