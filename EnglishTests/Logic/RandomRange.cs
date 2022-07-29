using EnglishTests.Enums;
using EnglishTests.Interfaces;
using EnglishTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTests.Logic
{
	public class RandomRange : IRandomRange
	{
		private readonly int _from, _count;

		public RandomRange(int from, int count)
		{
			_from = from;
			_count = count;
		}

		public IEnumerable<int> GetRange()
		{
			int[] range = Enumerable.Range(_from, _count).ToArray();

			//	_from = 0, _count = 10
			//	0, 1, 2, 3, 4, 5, 6, 7, 8, 9
			//	0, 1, 2, 3, 4, 5, 6, 9, 8, 7

			//	[0..9] (10)

			Random random = new();

			//		 i = 10 - 1 = 9; i >= 0;	 i--
			for (int i = _count - 1; i >= _from; i--)
			{
				//	value = random.Next(	0, 9 + 1);
				int value = random.Next(_from, i + 1);
				//	value = 7;

				//	temp = range[7];
				int temp = range[value];
				//	temp = 7;

			//	range[7]	 = range[9];
				range[value] = range[i];
			//	range[7]	 = 9;

			//	range[i] = 7;
				range[i] = temp;
			}

			return range;
		}

		public static IEnumerable<int> GetRange(int from, int count)
		{
			int[] range = Enumerable.Range(from, count).ToArray();

			//	_from = 0, _count = 10
			//	0, 1, 2, 3, 4, 5, 6, 7, 8, 9
			//	0, 1, 2, 3, 4, 5, 6, 9, 8, 7

			//	[0..9] (10)

			Random random = new();

			//		 i = 10 - 1 = 9; i >= 0;	 i--
			for (int i = count - 1; i >= from; i--)
			{
				//	value = random.Next(	0, 9 + 1);
				int value = random.Next(from, i + 1);
				//	value = 7;

				//	temp = range[7];
				int temp = range[value];
				//	temp = 7;

				//	range[7]	 = range[9];
				range[value] = range[i];
				//	range[7]	 = 9;

				//	range[i] = 7;
				range[i] = temp;
			}

			return range;
		}

		public static KeyValuePair<RowModelPart, string> GetRandomPartOf(RowModel rowModel)
		{
			var strRowModel = rowModel.ToStringArray();
			int randomIndex = new Random().Next(0, strRowModel.Count());

			var value = strRowModel.ToList()[randomIndex];

			var equals = rowModel.Equals(value);

			var key = (RowModelPart)Convert.ToInt32(equals.Item2);

			return new KeyValuePair<RowModelPart, string>(key, value);
		}

		public static (RowModelPart, int) GetRandomElementOf(RowModel rowModel)
		{
			var strRowModel = rowModel.ToStringArray();
			int randomIndex = new Random().Next(0, strRowModel.Count());

			var value = strRowModel.ToList()[randomIndex];

			var equals = rowModel.Equals(value);

			var rowModelPart = (RowModelPart)Convert.ToInt32(equals.Item2);

			return (rowModelPart, randomIndex);
		}

		/*public static CheckDataModel GetToCheckDataModel(RowModel rowModel, CompareMode compareMode)
		{
			var strRowModel = rowModel.ToStringArray();
			int randomIndex = new Random().Next(0, strRowModel.Count());

			var objectToCheck = strRowModel.ToList()[randomIndex];

			var equals = rowModel.Equals(objectToCheck);

			var compareWith = (RowModelPart)Convert.ToInt32(equals.Item2);

			return new CheckDataModel
			{
				RowModel = rowModel,
				ОbjectToСheck = objectToCheck,
				CompareWith = compareWith,
				CompareMode = compareMode
			};
		}*/
	}
}
