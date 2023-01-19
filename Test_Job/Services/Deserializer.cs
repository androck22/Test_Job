namespace Test_Job.Services
{
	public class Deserializer : IDeserializer
	{
		private InputObject.JsonFile incoming;

		public InputObject.JsonFile Incoming
		{
			get
			{
				return incoming;
			}
			set
			{
				incoming = value;
			}

		}
		public InputObject.JsonFile DecodeFile(string filename)
		{
			if (String.IsNullOrEmpty(filename))
				throw new ArgumentNullException(nameof(filename));

			using (StreamReader r = new StreamReader(filename))
			{
				string json = r.ReadToEnd();
				incoming = JsonSerializer.Deserialize<InputObject.JsonFile>(json);
			}

			return incoming;
		}
	}
}
