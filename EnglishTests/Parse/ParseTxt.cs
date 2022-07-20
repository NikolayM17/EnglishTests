using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using EnglishTests.Interfaces;
using EnglishTests.Models;

namespace EnglishTests.Parse
{
	public class ParseTxt : IParsable
	{
		public IEnumerable<RowModel> Parse(IEnumerable<string> lines)
		{
			foreach (var line in lines)
			{
				yield return ParseLine(line);
			}
		}

		public RowModel? ParseLine(string line = "Above - выше, больше")
		{
			string pattern = @" \W ";
			var regex = new Regex(pattern);

			var translatePartsOfLine = regex.Split(line);

			try
			{
				string lineForTranslate = translatePartsOfLine[0];
				string[] translateLines = translatePartsOfLine[1].Split(", ");

				return new RowModel(lineForTranslate, translateLines);
			}
			catch (IndexOutOfRangeException ex)
			{
				return new RowModel(translatePartsOfLine.First(), null);
			}
		}
	}
}
