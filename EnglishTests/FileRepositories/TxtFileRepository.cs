using EnglishTests.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnglishTests.FileRepositories
{
	public class TxtFileRepository : IFileRepository
	{
		private FileStream? _file;

		public string FilePath { get; }
		public int RowCount
		{
			get
			{
				return File.ReadLines(FilePath).Count();
			}
		}

		public TxtFileRepository(string path)
		{
			FilePath = path;
		}

		public void OpenFileForReading(string path)
		{
			_file = new FileStream(path, FileMode.Open, FileAccess.Read);
		}

		public IEnumerable<string?> GetLines(params int[] lineNumbers)
		{
			foreach(var number in lineNumbers)
			{
				yield return File.ReadLines(FilePath).Skip(number - 1).FirstOrDefault();
			}
		}

		public IEnumerable<string?> GetLines(IEnumerable<int> lineNumbers)
		{
			foreach (var number in lineNumbers)
			{
				yield return File.ReadLines(FilePath).Skip(number - 1).FirstOrDefault();
			}
		}
	}
}
