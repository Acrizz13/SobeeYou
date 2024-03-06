using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class Orders {
        public int intOrderID { get; set; }
        public string intUserID { get; set; }
        public DateTime dtmDateAdded { get; set; }
        public decimal decTotalAmount { get; set; }


    }


}