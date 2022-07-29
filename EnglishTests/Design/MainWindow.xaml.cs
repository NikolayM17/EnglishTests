using Prism.Services.Dialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TeEn.Frames;

namespace EnglishTests.Design
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool _xPressed = false;
		private bool _footerPressed = false;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Footer_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_footerPressed = true;
		}

		private void Footer_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (_footerPressed)
			{
				Page page = new Page();

				if (sender is Label label)
				{
					switch (label.Content)
					{
						case "Test":
							page = new TestMenuPage();
							TeEnLabel.Visibility = Visibility.Collapsed;
							break;
						default:
							break;
					}
				}

				this.MainFrame.Content = page;

				_footerPressed = false;
			}
		}

		private void X_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_xPressed = true;
		}

		private void X_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (_xPressed)
			{
				Close();

				_xPressed = false;
			}
		}

		private void Header_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}
