using EnglishTests.Enums;

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
