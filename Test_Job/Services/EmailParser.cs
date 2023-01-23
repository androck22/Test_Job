namespace Test_Job.Services
{
	public class EmailParser : IEmailParser
	{
		private List<string> emailList = new();

		public List<string> EmailList
		{
			get
			{
				return emailList;
			}
			set
			{
				emailList = value;
			}
		}

		public List<string> ParseEmail(IDocument document)
		{
			if (document is null)
				throw new ArgumentNullException(nameof(document));

			var items = document.All;

			foreach (var inem in items)
			{

				AddEmail(inem.TextContent.Trim());
			}

			return emailList;
		}

		public void AddEmail(string email)
		{
			Regex regex = new Regex(@"\w*@\w*.\w*");
			MatchCollection matches = regex.Matches(email);

			if (matches.Count > 0)
			{
				foreach (Match match in matches)
				{
					if (!emailList.Exists(e => e == match.Value))
					{
						emailList.Add(match.Value);
					}
				}
			}
		}
	}
}
