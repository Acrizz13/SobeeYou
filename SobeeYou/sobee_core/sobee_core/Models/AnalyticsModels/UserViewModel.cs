namespace sobee_core.Models.AnalyticsModels {
    public class UserViewModel {
        public string Id { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public bool IsAdmin { get; set; }
    }
}
