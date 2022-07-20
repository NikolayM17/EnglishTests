using EnglishTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Interfaces
{
	public interface IParsable
	{
		IEnumerable<RowModel> Parse(IEnumerable<string> lines);

		RowModel ParseLine(string line = "Above - выше, больше");
	}
}
