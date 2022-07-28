using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TeEn.Handlers
{
	public static class GridHandler
	{
		public static TextBox GetStylizedTextBox(string hintText = "N/A")
		{
			var result = new TextBox();

			result.Style = Application.Current.FindResource("MaterialDesignFloatingHintTextBox") as Style;

			result.Height = 50;
			result.FontSize = 20;
			result.Foreground = Brushes.Gray;
			result.CaretBrush = Brushes.Gray;
			result.FontFamily = new FontFamily("Stark");
			result.Margin = new Thickness(10);
			result.SelectionBrush = Brushes.Gray;
			result.SelectionTextBrush = Brushes.White;

			MaterialDesignThemes.Wpf.HintAssist.SetHint(result, hintText);
			MaterialDesignThemes.Wpf.HintAssist.SetForeground(result, Brushes.White);
			MaterialDesignThemes.Wpf.TextFieldAssist.SetUnderlineBrush(result, Brushes.White);

			return result;
		}

		/*public GridHandler(ResourceDictionary resources)
		{
			resources.MergedDictionaries
		}

		private Label CreateLabel()
		{

		}

		private TextBox CreateTextBox()
		{

		}

		private void HideElements()
		{

		}*/
	}
}
