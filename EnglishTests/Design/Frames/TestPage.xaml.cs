using EnglishTests.Extensions;
using EnglishTests.Logic;
using EnglishTests.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
				LeftNav.Visibility = Visibility.Hidden;
				RightNav.Content = "Finish";
			}

			foreach (var checkDataModel in _checkDataModels)
			{
				stackPanel.Children.Add(GridHandler.GetStylizedTextBox(checkDataModel.RowViewModel.RowElement.ToTitleCase()));
			}

			//	MessageBox.Show(MaterialDesignThemes.Wpf.HintAssist.GetHint(stackPanel.Children[0]).ToString());
		}

		public TestPage()
		{
			InitializeComponent();

			if (_pageCount == 1)
			{
				LeftNav.Visibility = Visibility.Hidden;
				RightNav.Content = "Finish";
			}

			PrepareContent();

			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
			stackPanel.Children.Add(GridHandler.GetStylizedTextBox());
		}

		private void FinishTest()
		{
			for (int i = 0; i < stackPanel.Children.Count; i++)
			{
				_checkDataModels[i].ОbjectToСheck = ((TextBox)stackPanel.Children[i]).Text;

				/*if (i == 0)
				{
					MessageBox.Show(_checkDataModels[i].RowViewModel.ToString() + "\n" +
						_checkDataModels[i].ОbjectToСheck.ToString() + "\n" +
						_checkDataModels[i].CompareWith.ToString() + "\n" +
						_checkDataModels[i].CompareMode.ToString());
				}*/
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

			//	GetResultsPage.xaml;
		}

		private void Next()
		{
			++_currentPage;

			if (_currentPage == _pageCount - 1)
			{
				LeftNav.Visibility = Visibility.Hidden;
				RightNav.Content = "Finish";
			}
		}

		private void Back()
		{
			--_currentPage;
		}

		private void PrepareContent()
		{
			PrepareLabels();
		}

		private void PrepareLabels()
		{
			if (_currentPage == _pageCount - 1)
			{
				FillLastPage();
			}
			else
			{
				FillPage();
			}
		}

		private void FillPage()
		{

		}

		private void FillLastPage()
		{
			//	l1.Content = "Border";
		}

		private void RightNav_MouseDown(object sender, MouseButtonEventArgs e)
		{
			FinishTest();
		}
	}
}
