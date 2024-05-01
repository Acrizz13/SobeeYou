namespace sobee_core.Models.AnalyticsModels {
    public class InactiveUserViewModel {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
