using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SobeeYou.Models
{
    public class MasterModel
    {
        public int intUserID { get; set; }

        public int intUserRoleID { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string strFirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string strLastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string strEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string strPassword { get; set; }


        [Display(Name = "Billing Address")]
        public string strBillingAddress { get; set; }


        [Display(Name = "Shipping Address")]
        public string strShippingAddress { get; set; }



        public int intProductID { get; set; }
        public string strName { get; set; }
        public string strPrice { get; set; }
        public string strStockAmount { get; set; }



        public int intOrderItemID { get; set; }
        public int intOrderID { get; set; }
        public int intQuantity { get; set; }
        public SqlMoney monPricePerUnit { get; set; }


        public int intShoppingCartID { get; set; }
    
        public decimal decTotalPrice { get; set; }
        public DateTime dtmDateCreated { get; set; }
        public DateTime dtmLastUpdated { get; set; }


        public int intCartItemID { get; set; }
    
        public DateTime dtmDateAdded { get; set; }
    }




}