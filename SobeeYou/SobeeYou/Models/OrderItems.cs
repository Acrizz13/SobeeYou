using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class OrderItems {
        public int intOrderItemID { get; set; }
        public int intOrderID { get; set; }
        public int intQuantity { get; set; }
        public SqlMoney monPricePerUnit { get; set; }
            

    }
}