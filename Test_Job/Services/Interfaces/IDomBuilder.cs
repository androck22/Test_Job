namespace Test_Job.Services.Interfaces
{
	public interface IDomBuilder
	{
		Task<IDocument> DomBuild(string page);
	}
}
