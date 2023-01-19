namespace Test_Job.Services.Interfaces
{
	public interface IDomParser
	{
		List<string> Parse(IDocument document, string selector);
	}
}
