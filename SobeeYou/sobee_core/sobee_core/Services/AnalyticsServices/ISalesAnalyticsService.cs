using sobee_core.Data;
using sobee_core.Models.AzureModels;

namespace sobee_core.Services.AnalyticsServices {
    public interface ISalesAnalyticsService {
        List<dynamic> GetSalesTrends(List<Torder> filteredOrders, int? year, int? month);
        List<dynamic> GetTopSellingProducts(IQueryable<Torder> orders);
        List<dynamic> GetPaymentMethodBreakdown(List<Torder> filteredOrders);
        List<dynamic> GetMostReviewedProducts(int? year, int? month, int? day);
        List<dynamic> GetTopRatedProducts(int? year, int? month, int? day);

        List<dynamic> GetProductSalesData(List<Torder> filteredOrders);
        IQueryable<Torder> FilterOrdersByDate(IQueryable<Torder> orders, int? year, int? month, int? day);
    }
}
