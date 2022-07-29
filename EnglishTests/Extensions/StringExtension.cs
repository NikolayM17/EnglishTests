namespace EnglishTests.Extensions
{
	public static class StringExtension
	{
		public static string ToTitleCase(this string str)
		{
			return char.ToUpper(str[0]) + str.Substring(1);
		}

		public static string ToTextCase(this string str)
		{
			return char.ToLower(str[0]) + str.Substring(1);
		}
	}
}
