using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobeeYou.Models {
    public class Orders {
        public int intOrderID { get; set; }
        public int intUserID { get; set; }
        public DateTime dtmOrderDate { get; set; }
        public decimal decTotalAmount { get; set; }
        public int intShippingStatusID { get; set; }
        public string strShippingAddress { get; set; }
        public string strTrackingNumber { get; set; }
        public int intPaymentMethod { get; set; }


    }


}