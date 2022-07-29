using EnglishTests.Extensions;
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
			result.Foreground = Brushes.LightGray;
			result.BorderBrush = Brushes.Gray;
			result.CaretBrush = Brushes.LightGray;
			result.FontFamily = new FontFamily("Stark");
			result.Margin = new Thickness(12);
			result.Padding = new Thickness(0,0,0,5);
			result.SelectionBrush = Brushes.DarkGray;
			
			MaterialDesignThemes.Wpf.HintAssist.SetHint(result, hintText);
			MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(result, 0.8);
			MaterialDesignThemes.Wpf.HintAssist.SetForeground(result, Brushes.White);
			MaterialDesignThemes.Wpf.TextFieldAssist.SetUnderlineBrush(result, Brushes.White);

			return result;
		}

		public static void SetIrregularStyle(TextBox textBox, string expectedData)
		{
			Brush brush = new SolidColorBrush(Color.FromRgb(255,75,25));

			textBox.Foreground = brush;

			MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox, HintAssist.GetHint(textBox) + " — " + expectedData.ToTitleCase());
			MaterialDesignThemes.Wpf.HintAssist.SetForeground(textBox, brush);
			MaterialDesignThemes.Wpf.TextFieldAssist.SetUnderlineBrush(textBox, brush);
		}

		public static void SetRegularStyle(TextBox textBox, string expectedData)
		{
			textBox.Foreground = Brushes.Lime;

			MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox, HintAssist.GetHint(textBox) + " — " + expectedData.ToTitleCase());
			MaterialDesignThemes.Wpf.HintAssist.SetForeground(textBox, Brushes.Lime);
			MaterialDesignThemes.Wpf.TextFieldAssist.SetUnderlineBrush(textBox, Brushes.Lime);
		}

		public static void DisableTextBoxes(UIElementCollection uIElementCollection)
		{
			foreach (UIElement element in uIElementCollection)
			{
				if (element is TextBox textBox)
				{
					textBox.IsReadOnly = true;
					textBox.IsReadOnlyCaretVisible = false;
				}
			}
		}
	}
}
