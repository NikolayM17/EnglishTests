using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglishTests.Design
{
	/// <summary>
	/// Логика взаимодействия для InputWindow.xaml
	/// </summary>
	public partial class InputWindow : Window
    {
		private bool _xPressed = false;

		public InputWindow()
        {
            InitializeComponent();
        }

		private void X_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_xPressed = true;
		}

		private void X_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (_xPressed)
			{
				wordsCountTextBox.Text = String.Empty;

				Close();

				_xPressed = false;
			}
		}

		private void Label_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (sender is Label label)
			{
				if (label.Content.ToString() == "Cancel")
				{
					wordsCountTextBox.Text = String.Empty;
				}

				Close();
			}
		}

		private void Header_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}
