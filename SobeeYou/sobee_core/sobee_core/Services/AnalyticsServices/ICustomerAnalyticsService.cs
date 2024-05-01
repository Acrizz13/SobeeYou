using sobee_core.Models.AzureModels;

namespace sobee_core.Services.AnalyticsServices {
    public interface ICustomerAnalyticsService {
        List<dynamic> GetTopCustomers(List<Torder> filteredOrders, int? year, int? month);

        List<dynamic> GetRegisteredVsGuestCustomerSpending(List<Torder> filteredOrders);
    }
}
