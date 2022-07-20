using EnglishTests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Models
{
	public class ToCheckDataModel
	{
		public RowModel RowModel { get; set; }
		public object? ОbjectToCompare { get; set; }
		public RowModelPart CompareWith { get; set; }
		public CompareMode CompareMode { get; set; }
	}
}
