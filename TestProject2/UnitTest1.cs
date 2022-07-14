using NUnit.Framework;

using EnglishTests.Interfaces;
using EnglishTests.Parse;
using System;
using EnglishTests.FileRepositories;
using System.Collections.Generic;
using System.Linq;

namespace TestProject2
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			var expectedResult = new ValueTuple<string, string[]>("Above", new string[] { "выше", "больше" });

			//	Act

			var result = parse.ParseLine();

			//	Assert

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void Test2()
		{
			//	Arrange

			IParsable parse = new ParseTxt();

			IFileRepository fileRepository = new TxtFileRepository("file.txt");

			var expectedResult = new ValueTuple<string, string[]>("Apple", new string[] { "яблоко" });

			//	Act

			var lines = fileRepository.GetLines(1);

			var result = parse.ParseLine(lines.ToList()[0]);

			//	Assert

			Assert.AreEqual(expectedResult, result);
		}
	}
}
