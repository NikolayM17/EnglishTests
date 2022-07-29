﻿using EnglishTests.Enums;
using EnglishTests.FileRepositories;
using EnglishTests.Interfaces;
using EnglishTests.Logic;
using EnglishTests.Models;
using EnglishTests.Parse;
using EnglishTests.Service;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
				switch(choiceLabel.Content)
				{
					case "5":
						/*IParsable parse = new ParseTxt();

						var fileRepository = new TxtFileRepository("file.txt");

						var lines = fileRepository.GetLines(new RandomRange(0, fileRepository.RowCount).GetRange().ToArray()[0..5]);

						var rowModels = parse.Parse(lines).ToList();

						var randomParts = rowModels.Select(row => RandomRange.GetRandomElementOf(row)).ToList();

						for (int i = 0; i < rowModels.Count; i++)
						{
							rowModels[i].Index = randomParts[i].Item2;
						}

						var checkDataModels = new List<CheckDataModel>();

						for (int i = 0; i < rowModels.Count; i++)
						{
							checkDataModels.Add(new CheckDataModel()
							{
								RowViewModel = rowModels[i],
								CompareWith = (RowModelPart)(Convert.ToInt32(randomParts[i].Item1 == RowModelPart.LeftPart)),
								CompareMode = CompareMode.Light
							});
						}*/

						NavigationService.Navigate(new TestPage("file.txt", 5, CompareMode.Light));

						break;
					default:
						break;
				}
			}
		}
		private void ChoiceLabel_MouseUp(object sender, MouseButtonEventArgs e)
		{

		}

		private void wordsLabel_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}
		private void wordsLabel_MouseUp(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
