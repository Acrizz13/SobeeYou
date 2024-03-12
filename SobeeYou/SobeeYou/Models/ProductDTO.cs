using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class ProductDTO {
        public int intProductID { get; set; }
        public string strName { get; set; }
        public decimal decPrice { get; set; }
        public string strStockAmount { get; set; }
    }
}