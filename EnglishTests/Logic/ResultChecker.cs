using EnglishTests.Interfaces;
using EnglishTests.Models;
using EnglishTests.Parse;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTests.Logic
{
	public class ResultChecker : IResultChecker
	{
		/*public ResultModel Result { get; }*/

		public List<int> FailedIndexes { get; }

		public ResultChecker()
		{
			//	Result = new();

			FailedIndexes = new();
		}

		public ResultModel GetTotalResult(List<CheckDataModel> data)
		{
			var result = new ResultModel(data.Count());

			FailedIndexes.Clear();

			for (int i = 0; i < data.Count(); i++)
			{
				if (data[i].RowViewModel.EqualWith(
					ParseTxt.ParseLineToArray(data[i].ОbjectToСheck as string),
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
