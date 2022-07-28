using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Models.ViewModels
{
	public class RowViewModel : RowModel
	{
		public int Index { get; set; }
		public string RowElement => ToStringArray().ToList()[Index];

		public RowViewModel() : base() { }

		public RowViewModel(string leftPart, string[] rightPart) : base(leftPart, rightPart) { }

		public override string ToString()
		{
			var result = LeftPart + " — " + RightPart[0];

			if (RightPart.Length > 1)
			{
				for (int i = 1; i < RightPart.Length; i++)
				{
					result += ", " + RightPart[i];
				}
			}

			return result;
		}
	}
}
