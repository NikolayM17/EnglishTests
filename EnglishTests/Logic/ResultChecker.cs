using EnglishTests.Enums;
using EnglishTests.Interfaces;
using EnglishTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
