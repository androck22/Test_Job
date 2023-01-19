namespace Test_Job.Services
{
	public class Decrypter : IDecrypter
	{
		public string Decrypt(string toDecrypt, string key)
		{
			if (String.IsNullOrEmpty(toDecrypt)) 
				throw new ArgumentNullException(nameof(toDecrypt));

			if (String.IsNullOrEmpty(key))
				throw new ArgumentNullException(nameof(key));


			byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key); // AES-256 key
			PadToMultipleOf(ref keyArray, 8);
			byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
			//byte[] toEncryptArray = ConvertHexStringToByteArray(toDecrypt);

			RijndaelManaged rDel = new RijndaelManaged();
			rDel.KeySize = (keyArray.Length * 8);
			rDel.Key = keyArray;          // in bits
			rDel.Mode = CipherMode.ECB; // http://msdn.microsoft.com/en-us/library/system.security.cryptography.ciphermode.aspx
			rDel.Padding = PaddingMode.None;  // better lang support
			ICryptoTransform cTransform = rDel.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
			return UTF8Encoding.UTF8.GetString(resultArray);
		}

		public void PadToMultipleOf(ref byte[] src, int pad)
		{
			int len = (src.Length + pad - 1) / pad * pad;
			Array.Resize(ref src, len);
		}
	}
}
