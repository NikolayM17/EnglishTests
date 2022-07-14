using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnglishTests.Interfaces;

namespace EnglishTests.Parse
{
	public class ParseTxt : IParsable
	{
		public IEnumerable<(string, string[])> Parse(IEnumerable<string> lines)
		{
			foreach (var line in lines)
			{
				yield return ParseLine(line);
			}
		}

		public (string, string[]) ParseLine(string line = "Above - выше, больше")
		{
			var translatePartsOfLine = line.Split(" - ");

			string lineForTranslate = translatePartsOfLine[0];
			string[] translateLines = translatePartsOfLine[1].Split(", ");

			return new ValueTuple<string, string[]>(lineForTranslate, translateLines);
		}
	}
}
