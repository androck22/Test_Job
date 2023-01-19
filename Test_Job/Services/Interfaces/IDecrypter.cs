namespace Test_Job.Services.Interfaces
{
	public interface IDecrypter
	{
		string Decrypt(string toDecrypt, string key);
		void PadToMultipleOf(ref byte[] src, int pad);
	}
}
