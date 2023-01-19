namespace Test_Job.Models
{
	public class InputObject
	{
		public record struct JsonFile(
			string selector,
			string attribute,
			string url_b64,
			string encrypted_text_bytes_b64,
			string key_bytes_b64,
			string page_b64
		);
	}
}
