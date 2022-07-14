using EnglishTests.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.FileRepositories
{
	public class TxtFileRepository : IFileRepository
	{
		private FileStream? _file;

		private string _filePath;

		public TxtFileRepository(string path)
		{
			_filePath = path;

			/*OpenFileForReading(_filePath);*/
		}

		public void OpenFileForReading(string path)
		{
			_file = new FileStream(path, FileMode.Open, FileAccess.Read);
		}

		public IEnumerable<string?> GetLines(params int[] lineNumbers)
		{
			foreach(var number in lineNumbers)
			{
				yield return File.ReadLines(_filePath).Skip(number - 1).FirstOrDefault();
			}
		}

		public int CountLines()
		{
			return 0;
		}

		public void OpenFile(string path)
		{
			throw new NotImplementedException();
		}
	}
}
