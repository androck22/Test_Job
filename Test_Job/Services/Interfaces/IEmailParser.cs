namespace Test_Job.Services.Interfaces
{
	public interface IEmailParser
	{
		List<string> EmailList { get; set; }
		List<string> ParseEmail(IDocument document);
		void AddEmail(string email);
	}
}
