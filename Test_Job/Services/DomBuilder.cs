namespace Test_Job.Services
{
	public class DomBuilder : IDomBuilder
	{
		public async Task<IHtmlDocument> DomBuild(string page)
		{
			if(String.IsNullOrEmpty(page))
				throw new ArgumentNullException(nameof(page));

			var parser = new HtmlParser(new HtmlParserOptions
			{
				IsNotConsumingCharacterReferences = true,
			});
			IHtmlDocument document = await parser.ParseDocumentAsync(page);

			return document;
		}
	}
}
