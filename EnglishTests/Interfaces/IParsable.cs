using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Interfaces
{
	public interface IParsable
	{
		IEnumerable<(string, string[])> Parse(IEnumerable<string> lines);

		(string, string[]) ParseLine(string line = "Above - выше, больше");
	}
}
