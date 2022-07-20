using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnglishTests.Interfaces;
using EnglishTests.Models;

namespace EnglishTests.Parse
{
	internal class ParseJson : IParsable
	{
		public IEnumerable<RowModel> Parse(IEnumerable<string> lines)
		{
			throw new NotImplementedException();
		}

		public RowModel ParseLine(string line = "Above - выше, больше")
		{
			throw new NotImplementedException();
		}
	}
}
