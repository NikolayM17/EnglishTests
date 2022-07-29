using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using EnglishTests.Interfaces;
using EnglishTests.Models;
using EnglishTests.Models.ViewModels;

namespace EnglishTests.Parse
{
	public class ParseTxt : IParsable
	{
		public IEnumerable<RowModel> ParseModel(IEnumerable<string> lines)
		{
			foreach (var line in lines)
			{
				yield return ParseLine(line);
			}
		}

		public IEnumerable<RowViewModel> Parse(IEnumerable<string> lines)
		{
			foreach (var line in lines)
			{
				yield return ParseLineToViewModel(line);
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

		public RowViewModel? ParseLineToViewModel(string line = "Above - выше, больше")
		{
			string pattern = @" \W ";
			var regex = new Regex(pattern);

			var translatePartsOfLine = regex.Split(line);

			try
			{
				string lineForTranslate = translatePartsOfLine[0];
				string[] translateLines = translatePartsOfLine[1].Split(", ");

				return new RowViewModel(lineForTranslate, translateLines);
			}
			catch (IndexOutOfRangeException ex)
			{
				return new RowViewModel(translatePartsOfLine.First(), null);
			}
		}

		public static IEnumerable<string>? ParseLineToArray(string line)
		{
			string[] result = new string[] { line };

			result = result[0].Contains(", ") ?
				result[0].Split(", ") : result[0].Contains(",") ?
					result[0].Split(",") : result;

			return result;
		}
	}
}
