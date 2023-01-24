namespace Test_Job.Services
{
	public class DomParser : IDomParser
	{
		public List<string> Parse(IHtmlDocument document, string selector, string attribute)
		{
			if (document == null)
				throw new ArgumentNullException(nameof(document));

			if (String.IsNullOrEmpty(selector))
				throw new ArgumentNullException(nameof(selector));

			var list = new List<string>();
			var items = document.QuerySelectorAll(selector);

			foreach (var item in items)
			{
				list.Add(item.GetAttribute(attribute));
			}

			return list;
		}
	}
}
