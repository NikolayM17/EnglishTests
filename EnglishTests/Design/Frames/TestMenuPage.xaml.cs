using EnglishTests.Design;
using EnglishTests.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace TeEn.Frames
{
	/// <summary>
	/// Логика взаимодействия для TestPage.xaml
	/// </summary>
	public partial class TestMenuPage : Page
	{
		public TestMenuPage()
		{
			InitializeComponent();
		}

		private void ChoiceLabel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (sender is Label choiceLabel)
			{
				NavigationService.Navigate(new TestPage("file.txt", int.Parse(choiceLabel.Content.ToString()), CompareMode.Light));
			}
		}
		private void ChoiceLabel_MouseUp(object sender, MouseButtonEventArgs e)
		{

		}

		private void wordsLabel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var childWindow = new InputWindow();

			var window = Window.GetWindow(this);

			childWindow.Left = window.Left + window.Width / 2 - childWindow.Width / 2;
			childWindow.Top = window.Top + window.Height / 2 - childWindow.Height / 2;

			if (childWindow.ShowDialog() == false)
			{
				if (sender is Label choiceLabel && int.TryParse(childWindow.wordsCountTextBox.Text, out int wordsCount))
				{
					NavigationService.Navigate(new TestPage("file.txt", wordsCount, CompareMode.Light));
				}
			}
		}
		private void wordsLabel_MouseUp(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
