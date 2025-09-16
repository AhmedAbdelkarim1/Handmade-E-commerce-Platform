namespace Models.DTOs.ServiceReview
{
	public class ServiceReviewDto //للعرض فقط 
	{

		public int Id { get; set; }
		public int ServiceId { get; set; }
		public string ServiceTitle { get; set; }

		public string ReviewerId { get; set; }
		public string ReviewerName { get; set; }

		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
