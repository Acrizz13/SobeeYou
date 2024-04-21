namespace sobee_core.Models {
	public class ReviewDTO {
		public int ReviewId { get; set; }
		public string ReviewText { get; set; }
		public int Rating { get; set; }
		public DateTime ReviewDate { get; set; }
		public string UserFirstName { get; set; }
	}
}
