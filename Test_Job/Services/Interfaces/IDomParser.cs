namespace Test_Job.Services.Interfaces
{
	public interface IDomParser
	{
		List<string> Parse(IHtmlDocument document, string selector);
	}
}
