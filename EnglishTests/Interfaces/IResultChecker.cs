using EnglishTests.Enums;
using EnglishTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Interfaces
{
	public interface IResultChecker
	{
		ResultModel GetTotalResult(IEnumerable<ToCheckDataModel> data);
	}
}
