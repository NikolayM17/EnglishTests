using EnglishTests.Enums;
using System.Linq;

namespace EnglishTests.Models.ViewModels
{
	public class RowViewModel : RowModel
	{
		public int Index { get; set; }
		public string RowElement => ToStringArray().ToList()[Index];

		public RowViewModel() : base() { }

		public RowViewModel(string leftPart, string[] rightPart) : base(leftPart, rightPart) { }

		public string GetAnotherPartToString(RowModelPart thisPart)
		{
			return thisPart is RowModelPart.RightPart ? LeftPart : RightPartToString();
		}
		public string GetPartToString(RowModelPart thisPart)
		{
			return thisPart is RowModelPart.RightPart ? RightPartToString() : LeftPart;
		}

		private string RightPartToString()
		{
			string result = RightPart[0];

			if (RightPart.Length > 1)
			{
				foreach (var rowElement in RightPart[1..])
				{
					result += ", " + rowElement;
				}
			}

			return result;
		}

		public override string ToString()
		{
			var result = LeftPart + " — " + RightPartToString();

			return result;
		}
	}
}
