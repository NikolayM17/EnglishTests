using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnglishTests.Interfaces;
using EnglishTests.Models;

namespace EnglishTests.Parse
{
	internal class ParseHtml : IParsable
	{
		public void Parse(IEnumerable<string> lines)
		{

		}

		IEnumerable<RowModel> IParsable.Parse(IEnumerable<string> lines)
		{
			throw new NotImplementedException();
		}

		RowModel IParsable.ParseLine(string line)
		{
			throw new NotImplementedException();
		}
	}
}
