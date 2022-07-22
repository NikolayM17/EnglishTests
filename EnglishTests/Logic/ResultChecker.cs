using EnglishTests.Interfaces;
using EnglishTests.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTests.Logic
{
	public class ResultChecker : IResultChecker
	{
		public ResultModel GetTotalResult(IEnumerable<ToCheckDataModel> data)
		{
			var result = new ResultModel(data.Count());

			foreach (var dataModel in data)
			{
				if (dataModel.RowModel.EqualWith(
					dataModel.ОbjectToCompare,
					dataModel.CompareWith,
					dataModel.CompareMode))
				{
					result++;
				}
			}

			return result;
		}
	}
}
