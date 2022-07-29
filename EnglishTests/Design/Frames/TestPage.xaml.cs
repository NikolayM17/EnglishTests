using EnglishTests.Enums;
using EnglishTests.Extensions;
using EnglishTests.Models;
using EnglishTests.Service;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
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

		private readonly List<CheckDataModel> _checkDataModels;

		/*private readonly List<string> _wordsForTranslate;
		private readonly List<TextBox> _translates;*/

		private FileService _fileService;

		private int _currentPage = 0;

		public TestPage(List<CheckDataModel> checkDataModels /*List<string> wordsForTranslate*/)
		{
			InitializeComponent();

			_wordCount = checkDataModels.Count;
			_pageCount = _wordCount / _FitOnPage + (_wordCount % _FitOnPage > 0 ? 1 : 0);

			_checkDataModels = checkDataModels;

			//	_wordsForTranslate = wordsForTranslate;

			if (_pageCount == 1)
			{
				//	LeftNav.Visibility = Visibility.Hidden;
				FinishButtonLabel.Content = "Finish";
			}

			foreach (var checkDataModel in _checkDataModels)
			{
				stackPanel.Children.Add(GridHandler.GetStylizedTextBox(checkDataModel.RowViewModel.RowElement.ToTitleCase()));
			}

			//	MessageBox.Show(MaterialDesignThemes.Wpf.HintAssist.GetHint(stackPanel.Children[0]).ToString());
		}

		public TestPage(FileService fileService)
		{
			InitializeComponent();

			_fileService = fileService;

			foreach (var dataItem in _fileService.FileData)
			{
				stackPanel.Children.Add(GridHandler.GetStylizedTextBox(dataItem.RowViewModel.RowElement.ToTitleCase()));
			}
		}

		public TestPage()
		{
			InitializeComponent();

			if (_pageCount == 1)
			{
				//	LeftNav.Visibility = Visibility.Hidden;
				FinishButtonLabel.Content = "Finish";
			}

			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
		}

		public TestPage(string filePath, int dataAmount, CompareMode compareMode)
		{
			InitializeComponent();

			_fileService = new(filePath, dataAmount, compareMode);

			foreach (var dataItem in _fileService.FileData)
			{
				stackPanel.Children.Add(GridHandler.GetStylizedTextBox(dataItem.RowViewModel.RowElement.ToTitleCase()));
			}
		}
		
		/*private void FinishTest()
		{
			for (int i = 0; i < stackPanel.Children.Count; i++)
			{
				_checkDataModels[i].ОbjectToСheck = ((TextBox)stackPanel.Children[i]).Text;
			}

			var resultChecker = new ResultChecker();

			MessageBox.Show(resultChecker.GetTotalResult(_checkDataModels).ToString());

			if (resultChecker.FailedIndexes.Count > 0)
			{
				string message = "";

				foreach (int failedIndex in resultChecker.FailedIndexes)
				{
					message += _checkDataModels[failedIndex].ToString();
				}

				MessageBox.Show(message);
			}
		}*/

		private void FinishTest()
		{
			_fileService.SetObjectsToCheck(stackPanel.Children);

			MessageBox.Show(_fileService.ResultChecker.GetTotalResult(_fileService.FileData).ToString());

			if (_fileService.ResultChecker.FailedIndexes.Count > 0)
			{
				string message = "";

				foreach (int failedIndex in _fileService.ResultChecker.FailedIndexes)
				{
					message += _fileService.FileData[failedIndex].ToString();
				}

				MessageBox.Show(message);

				message = "";
			}

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
		}
	}
}
