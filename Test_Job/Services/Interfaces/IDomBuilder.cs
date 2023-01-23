namespace Test_Job.Services.Interfaces
{
	public interface IDomBuilder
	{
		Task<IHtmlDocument> DomBuild(string page);
	}
}
