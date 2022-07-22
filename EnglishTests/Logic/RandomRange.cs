using EnglishTests.Interfaces;
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

			Random random = new Random();

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
	}
}
