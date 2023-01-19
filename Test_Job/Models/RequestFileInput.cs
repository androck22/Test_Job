namespace Test_Job.Models
{
	public class RequestFileInput
	{
		[Required]
		public string Selector { get; set; }

		[Required]
		public string Attribute { get; set; }

		[Required]
		public string Url_b64 { get; set; }

		[Required]
		public string Encrypted_text_bytes_b64 { get; set; }

		[Required]
		public string Key_bytes_b64 { get; set; }

		[Required]
		public string Page_b64 { get; set; }
	}
}
