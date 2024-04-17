using sobee_core.Models.AzureModels;

namespace sobee_core.Models {
    public class ProductDTO {
        public int intProductID { get; set; }
        public string strName { get; set; }
        public decimal decPrice { get; set; }
        public string strStockAmount { get; set; }
        public double AverageRating { get; set; }
    }
}
