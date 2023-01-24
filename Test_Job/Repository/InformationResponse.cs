namespace Test_Job.Repository
{
	public class InformationResponse : IInformationResponse
	{
		private readonly IConverter _converter;
		private readonly IDecrypter _decrypter;
		private readonly IDeserializer _deserializer;
		private readonly IDomBuilder _domBuilder;
		private readonly IDomParser _domParser;
		private readonly IEmailParser _emailParser;

		public InformationResponse(
			IConverter converter,
			IDecrypter decrypter,
			IDeserializer deserializer,
			IDomBuilder domBuilder,
			IDomParser domParser,
			IEmailParser emailParser)
		{
			_converter = converter;
			_decrypter = decrypter;
			_deserializer = deserializer;
			_domBuilder = domBuilder;
			_domParser = domParser;
			_emailParser = emailParser;
		}

		public async Task<ResponseFileOutput> CreateResponse(RequestFileInput file)
		{
			// конвертируем url из base64 в string
			string url = _converter.ToBase64Decode(file.Url_b64);

			// конвертируем page из base64 в string
			string page = _converter.ToBase64Decode(file.Page_b64);

			// парсинг page (преобразование HTML-текста в DOM-объект)
			IHtmlDocument document = await _domBuilder.DomBuild(page);

			// выбираем все элементы по CSS-селектору
			var listElements = _domParser.Parse(document, file.Selector, file.Attribute);

			// получаем значения всех email-адресов в коде страницы
			var emailList = _emailParser.ParseEmail(document);

			// получаем ключ
			string keyStr = _converter.ToBase64Decode(file.Key_bytes_b64);

			// расшифровываем текст
			string decryptResult = _decrypter.Decrypt(file.Encrypted_text_bytes_b64, keyStr);

			ResponseFileOutput responseFile = new ResponseFileOutput()
			{
				Is_error = Error.Is_error,
				Error_code = Error.Error_code,
				Error_message = Error.Error_message,
				Elements_count = listElements.Count,
				Emails_count = emailList.Count,
				Url = url,
				Decrypted_plain_text = decryptResult,
				Elements_attr_list = listElements,
				Emails_list = emailList
			};


			string path = "response1.json";
			FileInfo fileInf = new FileInfo(path);

			if (!fileInf.Exists)
			{
				path = "response1.json";
			}
			else
			{
				path = "response2.json";
			}
			

			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				var options = new JsonSerializerOptions
				{
					WriteIndented = true
				};

				await JsonSerializer.SerializeAsync<ResponseFileOutput>(fs, responseFile, options);
				Console.WriteLine("Данные были сохранены в файл");
			}

			return responseFile;
		}
	}
}
