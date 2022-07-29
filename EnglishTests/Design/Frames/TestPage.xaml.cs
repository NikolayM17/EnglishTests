using EnglishTests.Enums;
using EnglishTests.Extensions;
using EnglishTests.Models;
using EnglishTests.Service;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TeEn.Handlers;

namespace TeEn.Frames
{
	/// <summary>
	/// Логика взаимодействия для TestPage.xaml
	/// </summary>
	public partial class TestPage : Page
	{
		private const int _FitOnPage = 10;

		private readonly int _wordCount;
		private readonly int _pageCount = 1;

		private bool _testFinished = false;

		private readonly List<CheckDataModel> _checkDataModels;

		private FileService _fileService;

		public TestPage(string filePath, int dataAmount, CompareMode compareMode)
		{
			InitializeComponent();

			_fileService = new(filePath, dataAmount, compareMode);

			foreach (var dataItem in _fileService.FileData)
			{
				stackPanel.Children.Add(GridHandler.GetStylizedTextBox(dataItem.RowViewModel.RowElement.ToTitleCase()));
			}
		}

		private void FinishTest()
		{
			if (!_testFinished)
			{
				_fileService.SetObjectsToCheck(stackPanel.Children);

				MessageBox.Show(_fileService.ResultChecker.GetTotalResult(_fileService.FileData).ToString());

				foreach (int index in _fileService.ResultChecker.FailedIndexes)
				{
					GridHandler.SetIrregularStyle((TextBox)stackPanel.Children[index],
						_fileService.FileData[index].RowViewModel.GetPartToString(_fileService.FileData[index].CompareWith));
				}

				for (int i = 0; i < stackPanel.Children.Count; i++)
				{
					if (!_fileService.ResultChecker.FailedIndexes.Contains(i))
					{
						GridHandler.SetRegularStyle((TextBox)stackPanel.Children[i],
							_fileService.FileData[i].RowViewModel.GetPartToString(_fileService.FileData[i].CompareWith));
					}
				}

				GridHandler.DisableTextBoxes(stackPanel.Children);

				_testFinished = true;
			}
		}

		private void FinishButtonLabel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			FinishTest();
		}

		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				FinishTest();
			}
		}

		private void TryAgainButtonLabel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_fileService = new(_fileService.FilePath, _fileService.FileData.Count, _fileService.CompareMode);

			stackPanel.Children.Clear();

			foreach (var dataItem in _fileService.FileData)
			{
				stackPanel.Children.Add(GridHandler.GetStylizedTextBox(dataItem.RowViewModel.RowElement.ToTitleCase()));
			}

			_testFinished = false;
		}
	}
}
