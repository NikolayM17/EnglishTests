using System.Collections.Generic;

namespace EnglishTests.Interfaces
{
	public interface IFileRepository
	{
		void OpenFile(string path);

		IEnumerable<string?> GetLines(params int[] lineNumbers);

		int CountLines();
	}
}
