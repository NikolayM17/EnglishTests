using EnglishTests.Models;
using System.Collections.Generic;

namespace EnglishTests.Interfaces
{
	public interface IParsable
	{
		IEnumerable<RowModel> Parse(IEnumerable<string> lines);

		RowModel ParseLine(string line = "Above - выше, больше");
	}
}
