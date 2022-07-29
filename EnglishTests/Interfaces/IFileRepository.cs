using System.Collections.Generic;

namespace EnglishTests.Interfaces
{
	public interface IFileRepository
	{
		public string FilePath { get; }
		public int RowCount { get; }

		IEnumerable<string?> GetLines(params int[] lineNumbers);
	}
}
