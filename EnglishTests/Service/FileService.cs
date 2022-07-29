using EnglishTests.Enums;
using EnglishTests.FileRepositories;
using EnglishTests.Interfaces;
using EnglishTests.Logic;
using EnglishTests.Models;
using EnglishTests.Models.ViewModels;
using EnglishTests.Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EnglishTests.Service
{
	public class FileService
	{
		private readonly string _filePath;
		private readonly int _dataAmount;

		private CompareMode _compareMode;

		private List<RowViewModel> _rowModels;
		private List<(RowModelPart, int)> _rowModelRandomElementsWithIndexes;
		private List<CheckDataModel> _randomFileData;

		private IResultChecker _resultChecker;

		public List<CheckDataModel> FileData => _randomFileData;
		public string FilePath => _filePath;
		public CompareMode CompareMode => _compareMode;

		public ResultChecker ResultChecker
		{
			get
			{
				_resultChecker ??= new ResultChecker();

				return (ResultChecker)_resultChecker;
			}
		}

		public FileService(string filePath, int dataAmount, CompareMode compareMode)
		{
			_filePath = filePath;
			_dataAmount = dataAmount;
			_compareMode = compareMode;

			InitServiceData();
		}

		public void SetObjectsToCheck(UIElementCollection collection)
		{
			if (_randomFileData.Count == collection.Count)
			{
				for (int i = 0; i < _randomFileData.Count; i++)
				{
					_randomFileData[i].ОbjectToСheck = ((TextBox)collection[i]).Text;
				}
			}
			else throw new Exception("Incomparable amounts!");
		}

		private void InitServiceData()
		{
			IParsable parse = new ParseTxt();
			IFileRepository fileRepository = new TxtFileRepository(_filePath);
			IRandomRange randomRange = new RandomRange(0, fileRepository.RowCount);

			var fileLines = fileRepository.GetLines(randomRange.GetRange().ToArray()[0.._dataAmount]);
			_rowModels = parse.Parse(fileLines).ToList();
			_rowModelRandomElementsWithIndexes = _rowModels.Select(row => RandomRange.GetRandomElementOf(row)).ToList();

			for (int i = 0; i < _rowModels.Count; i++)
			{
				_rowModels[i].Index = _rowModelRandomElementsWithIndexes[i].Item2;
			}

			_randomFileData = new();

			for (int i = 0; i < _rowModels.Count; i++)
			{
				_randomFileData.Add(new CheckDataModel()
				{
					RowViewModel = _rowModels[i],
					CompareWith = (RowModelPart)(Convert.ToInt32(_rowModelRandomElementsWithIndexes[i].Item1 == RowModelPart.LeftPart)),
					CompareMode = CompareMode.Light
				});
			}
		}
	}
}
