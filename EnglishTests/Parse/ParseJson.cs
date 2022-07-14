using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnglishTests.Interfaces;

namespace EnglishTests.Parse
{
	internal class ParseJson : IParsable
	{
		public void Parse(IEnumerable<string> lines)
		{

		}

		public (string, string[]) ParseLine(string line)
		{
			throw new NotImplementedException();
		}

		IEnumerable<(string, string[])> IParsable.Parse(IEnumerable<string> lines)
		{
			throw new NotImplementedException();
		}
	}
}
