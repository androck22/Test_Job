namespace Test_Job.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FileParserController : ControllerBase
	{
		private readonly IInformationResponse _informationResponse;

		public FileParserController(IInformationResponse informationResponse)
		{
			_informationResponse = informationResponse;
		}

		[HttpPost]
		public async Task<ResponseFileOutput> GetInformation([FromBody] RequestFileInput file) // имя файла, который необходимо открыть
		{
			var response = await _informationResponse.CreateResponse(file);

			return response;
		}
	}
}
