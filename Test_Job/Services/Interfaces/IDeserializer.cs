namespace Test_Job.Services.Interfaces
{
	public interface IDeserializer
	{
		public InputObject.JsonFile Incoming { get; set; }
		public InputObject.JsonFile DecodeFile(string filename);
	}
}
