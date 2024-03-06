using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class ShoppingCart {

        public int intShoppingCartID { get; set; }
        public int intUserID { get; set; }
        public decimal decTotalPrice { get; set; }
        public DateTime dtmDateCreated { get; set; }
        public DateTime dtmLastUpdated { get; set; }
    }
}