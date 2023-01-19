namespace Test_Job.Repository
{
	public interface IInformationResponse
	{
		Task<ResponseFileOutput> CreateResponse(RequestFileInput file);
	}
}
