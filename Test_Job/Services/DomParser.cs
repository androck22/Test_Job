namespace Test_Job.Services
{
	public class DomParser : IDomParser
	{
		public List<string> Parse(IHtmlDocument document, string selector)
		{
			if (document == null)
				throw new ArgumentNullException(nameof(document));

			if (String.IsNullOrEmpty(selector))
				throw new ArgumentNullException(nameof(selector));

			Regex regex = new Regex(@"src|href");
			MatchCollection matches = regex.Matches(selector);
			string atribute = string.Empty;
			if (matches.Count > 0)
			{
				foreach (Match match in matches)
				{
					atribute = match.Value;
				}
			}

			var list = new List<string>();
			var items = document.QuerySelectorAll(selector);

			foreach (var item in items)
			{
				list.Add(item.GetAttribute(atribute));
			}

			return list;
		}
	}
}
