using EnglishTests.Models;
using EnglishTests.Models.ViewModels;
using System.Collections.Generic;

namespace EnglishTests.Interfaces
{
	public interface IParsable
	{
		IEnumerable<RowViewModel> Parse(IEnumerable<string> lines);

		RowModel ParseLine(string line = "Above - выше, больше");
	}
}
