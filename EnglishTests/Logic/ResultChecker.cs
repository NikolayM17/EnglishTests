using EnglishTests.Interfaces;
using EnglishTests.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTests.Logic
{
	public class ResultChecker : IResultChecker
	{
		public List<int> FailedIndexes { get; }

		public ResultChecker()
		{
			FailedIndexes = new List<int>();
		}

		public ResultModel GetTotalResult(List<CheckDataModel> data)
		{
			var result = new ResultModel(data.Count());

			for (int i = 0; i < data.Count(); i++)
			{
				if (data[i].RowViewModel.EqualWith(
					data[i].ОbjectToСheck,
					data[i].CompareWith,
					data[i].CompareMode))
				{
					result++;
				}
				else
				{
					FailedIndexes.Add(i);
				}
			}

			return result;
		}
	}
}
