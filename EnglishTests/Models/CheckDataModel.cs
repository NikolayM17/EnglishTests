using EnglishTests.Enums;
using EnglishTests.Models.ViewModels;

namespace EnglishTests.Models
{
	public class CheckDataModel
	{
		public RowViewModel RowViewModel { get; set; }
		public object? ОbjectToСheck { get; set; }
		public RowModelPart CompareWith { get; set; }
		public CompareMode CompareMode { get; set; }

		public override string ToString()
		{
			return RowViewModel.ToString() + "\n" +
			ОbjectToСheck.ToString() + "\n" +
			CompareWith.ToString() + "\n" +
			CompareMode.ToString() + "\n\n";
		}
	}
}
