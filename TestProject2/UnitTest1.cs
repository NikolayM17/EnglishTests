using NUnit.Framework;

using EnglishTests.Interfaces;
using EnglishTests.Parse;
using System;
using EnglishTests.FileRepositories;
using System.Collections.Generic;
using System.Linq;
using EnglishTests.Logic;
using EnglishTests.Models;
using System.Collections;
using EnglishTests.Enums;

namespace TestProject2
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestParse()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			var expectedResult = new RowModel("Abve", new string[] { "выше", "больше" });

			//	Act

			var result = parse.ParseLine("Admit : Признавать, допускать");

			//	Assert

			//	Assert.IsTrue(expectedResult.Equals(result).Item2);
			//	Assert.IsTrue(expectedResult.Equals(result).Item1);

			Assert.AreEqual(expectedResult.LeftPart, result.LeftPart);
		}

		[Test]
		public void TestRepository()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			IFileRepository fileRepository = new TxtFileRepository("file.txt");

			var expectedResult = new RowModel("Apple", new string[] { "Яблоко" });

			//	Act

			var lines = fileRepository.GetLines(1);

			var result = parse.ParseLine(lines.ToList()[0]);

			//	Assert

			Assert.IsTrue(expectedResult.Equals(result).Item1);
			Assert.IsTrue(expectedResult.Equals(result).Item2);
		}

		[Test]
		public void TestChecker()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			IFileRepository fileRepository = new TxtFileRepository("file.txt");

			string expectedResult = "3 / 3";

			List<string[]> inputStrings = new()
			{
				new string[] { "Яблоко" },
				new string[] { "Безопасность" },
				new string[] { "Имя Сайта", "дОмен" }
			};

			//	Act

			var lines = fileRepository.GetLines(1, 19, 21);

			var rowModels = new List<RowModel>(parse.Parse(lines));

			var dataForChecking = new List<Tuple<RowModel, object>>();

			for (int i = 0; i < 3; i++)
			{
				Tuple<RowModel, object> itemForChecking = new(rowModels[i], inputStrings[i]);

				dataForChecking.Add(itemForChecking);
			}

			IResultChecker checker = new ResultChecker();
			//	var result = checker.GetTotalResult(dataForChecking);

			//	Assert

			//	Assert.AreEqual(expectedResult, result.ToString());
		}

		[Test]
		public void TestGetLines()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			var fileRepository = new TxtFileRepository("file.txt");

			var expectedResult = new string[] { "qwer", "erhgwe", "erfbwd" };

			//	Act

			var lines = fileRepository.GetLines(new int[] { 1, 2, 3 }).ToArray();

			//	Assert

			Assert.AreEqual(lines[0], lines[2]);
		}

		[Test]
		public void TestRandom()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			var fileRepository = new TxtFileRepository("file.txt");

			var expectedResult = new string[] { "qwer", "erhgwe", "erfbwd" };

			//	Act

			var lines = fileRepository.GetLines(new RandomRange(0, fileRepository.RowCount).GetRange().ToArray()[0..3]).ToArray();

			//	var rowModels = new List<RowModel>(parse.Parse(lines));


			//	Assert

			Assert.AreEqual(lines[0], lines[2]);
			//	Assert.AreEqual(lines[0], lines[2]);
		}

		[Test]
		public void TestParseExceptions()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			var fileRepository = new TxtFileRepository("file.txt");

			//	Act

			var range = new RandomRange(0, fileRepository.RowCount).GetRange();

			var lines = fileRepository.GetLines(range);

			var result = parse.Parse(lines).ToList().FindAll(rm => rm.RightPart is null).Count;

			//	Assert

			//	var rslt = result.First().LeftPart == result.First().RightPart[0];

			Assert.AreEqual(result, 0);
		}

		[Test]
		public void TestProgram()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			var fileRepository = new TxtFileRepository("file.txt");

			//	Act

			var range = new RandomRange(0, fileRepository.RowCount).GetRange();

			var lines = fileRepository.GetLines(range);

			var result = parse.Parse(lines).ToList();

			//	Assert

			Assert.AreEqual(result.First().LeftPart, result.First().RightPart[0]);
		}

		[Test]
		public void TestResultChecker()
		{
			//	Arrange

			IParsable parse = new ParseTxt();
			IFileRepository fileRepository = new TxtFileRepository("file.txt");

			ResultModel expectedResult = new ResultModel(3, 3);

			var expectedAnswers = new ArrayList
			{
				"AppLe",
				//	"также",
				new string[] { "также", "тОже" },
				new string[] { "ВведеНие", "инЪекция" }
			};

			//	Act

			var fileLines = fileRepository.GetLines(1, 135, 157);

			var rowModels = parse.Parse(fileLines).ToList();

			List<ToCheckDataModel> toCheckValues = new();

			toCheckValues.Add(new ToCheckDataModel
			{
				RowModel = rowModels[0],
				ОbjectToCompare = expectedAnswers[0],
				CompareWith = RowModelPart.LeftPart,
				CompareMode = CompareMode.Light
			});

			toCheckValues.Add(new ToCheckDataModel
			{
				RowModel = rowModels[1],
				ОbjectToCompare = expectedAnswers[1],
				CompareWith = RowModelPart.RightPart,
				CompareMode = CompareMode.Hight
			});

			toCheckValues.Add(new ToCheckDataModel
			{
				RowModel = rowModels[2],
				ОbjectToCompare = expectedAnswers[2],
				CompareWith = RowModelPart.RightPart,
				CompareMode = CompareMode.Hight
			});

			var result = new ResultChecker().GetTotalResult(toCheckValues);

			//	Assert

			Assert.AreEqual(expectedResult.Score, result.Score);
		}
	}
}
