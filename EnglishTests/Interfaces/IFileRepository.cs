using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Interfaces
{
	public interface IFileRepository
	{
		void OpenFile(string path);

		IEnumerable<string?> GetLines(params int[] lineNumbers);

		int CountLines();
	}
}
