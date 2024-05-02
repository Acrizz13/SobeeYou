namespace sobee_core.Models {
    public class PromotionDTO {
        public int PromotionId { get; set; }
        public string PromoCode { get; set; }
        public string StrDiscountPercentage { get; set; }

        public decimal DecimalPercent { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}