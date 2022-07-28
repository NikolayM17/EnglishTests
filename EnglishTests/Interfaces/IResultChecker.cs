using EnglishTests.Models;
using System.Collections.Generic;

namespace EnglishTests.Interfaces
{
	public interface IResultChecker
	{
		ResultModel GetTotalResult(List<CheckDataModel> data);
	}
}
