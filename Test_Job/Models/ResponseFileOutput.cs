namespace Test_Job.Models
{
	public class ResponseFileOutput
	{
		public int Is_error { get; set; }
		public string Error_code { get; set; }
		public string Error_message { get; set; }
		public int Elements_count { get; set; }
		public int Emails_count { get; set; }
		public string Url { get; set; }
		public string Decrypted_plain_text { get; set; }
		public List<string> Elements_attr_list { get; set; }
		public List<string> Emails_list { get; set; }
	}
}
