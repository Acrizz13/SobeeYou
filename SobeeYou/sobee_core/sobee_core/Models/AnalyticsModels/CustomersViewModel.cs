namespace sobee_core.Models.AnalyticsModels {
    public class CustomersViewModel {
        public List<dynamic> TopRegisteredCustomers { get; set; }
        public List<dynamic> RegisteredVsGuestSpending { get; set; }
        public int? SelectedYear { get; set; }
        public int? SelectedMonth { get; set; }
    }
}
