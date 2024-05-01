namespace sobee_core.Models.AnalyticsModels {
    public class ReviewsViewModel {
        public List<dynamic> TopRatedProducts { get; set; }
        public List<dynamic> MostReviewedProducts { get; set; }

        public int? SelectedYear { get; set; }
        public int? SelectedMonth { get; set; }
        public int? SelectedDay { get; set; }
    }
}
