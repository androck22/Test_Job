using AngleSharp.Html.Parser;

namespace Test_Job.Services
{
	public class DomBuilder : IDomBuilder
	{
		public async Task<IDocument> DomBuild(string page)
		{
			if(String.IsNullOrEmpty(page))
				throw new ArgumentNullException(nameof(page));

			var parser = new HtmlParser(new HtmlParserOptions
			{
				IsNotConsumingCharacterReferences = true,
			});
			IDocument document = await parser.ParseDocumentAsync(page);

			return document;
		}
	}
}
