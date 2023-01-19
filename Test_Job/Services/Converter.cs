using Test_Job.Models.Error;

namespace Test_Job.Services
{
	public class Converter : IConverter
	{
		public string ToBase64Decode(string base64EncodedText)
		{
			if (String.IsNullOrEmpty(base64EncodedText))
				throw new ArgumentNullException(nameof(base64EncodedText));

			byte[] base64EncodedBytes = null!;

			try
			{
				base64EncodedBytes = Convert.FromBase64String(base64EncodedText);
			}
			catch (ArgumentException e)
			{
				Error.Is_error += 1;
				Error.Error_code = "Ошибка конвертации!";
				Error.Error_message = e.Message;

				Console.WriteLine(e);
				throw;
			}


			return Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}
