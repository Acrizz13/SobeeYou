
namespace sobee_core.Models.AnalyticsModels {
    public class SalesViewModel {
        public List<dynamic> TopSellingProducts { get; set; }
        public List<dynamic> SalesTrends { get; set; }
        //    public List<dynamic> PromotionPerformance { get; set; }
        public List<dynamic> PaymentMethodBreakdown { get; set; }

        public int? SelectedYear { get; set; }
        public int? SelectedMonth { get; set; }
        public int? SelectedDay { get; set; }

        public bool IsMonthSelected { get; set; }

    }
}
