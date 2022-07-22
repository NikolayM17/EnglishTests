using EnglishTests.Enums;
using System;
using System.Linq;

namespace EnglishTests.Models
{
	public class RowModel
	{
		public string LeftPart { get; set; }
		public string[] RightPart { get; set; }

		public RowModel()
		{
			LeftPart = new string("");
			RightPart = Array.Empty<string>();
		}

		public RowModel(string leftPart, string[] rightPart)
		{
			LeftPart = leftPart;
			RightPart = rightPart;
		}
		
		/*
		public override bool Equals(object? obj)
		{
			bool arePartsEqual = false;

			if (obj is null)
			{
				return LeftPart is null || RightPart is null;
			}
			else if (obj is string)
			{
				arePartsEqual = ((string)obj).ToLower() == LeftPart.ToLower();
			}
			else if (obj is string[])
			{
				arePartsEqual = CompareWithRightPart((string[])obj);
			}

			return arePartsEqual;
		}*/

		public bool EqualWith(object? obj, RowModelPart compareWith, CompareMode mode)
			=> mode == CompareMode.Hight ?
			HightCompare(obj, compareWith) : LightCompare(obj, compareWith);

		private bool LightCompare(object? obj, RowModelPart compareWith)
			=> compareWith == RowModelPart.LeftPart ?
			CompareWithLeftPart((string)obj) : CompareWithRightPart((string)obj);

		private bool HightCompare(object? obj, RowModelPart compareWith)
		{
			if (obj is string o && (
				compareWith == RowModelPart.LeftPart || RightPart.Length == 1))
			{
				return compareWith == RowModelPart.LeftPart ?
					CompareWithLeftPart(o) : CompareWithRightPart(o);
			}
			else if (obj is string[] o2 && compareWith == RowModelPart.RightPart)
			{
				return CompareWithRightPart(o2);
			}

			return false;
		}

		public Tuple<bool, bool> Equals(RowModel model)
		{
			return new Tuple<bool, bool>(
				CompareWithLeftPart(model.LeftPart),
				CompareWithRightPart(model.RightPart));
		}

		private string[] ToLower(string[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = arr[i].ToLower();
			}

			return arr;
		}

		private bool CompareWithRightPart(string[] arr)
		{
			var tempRightPart = ToLower(RightPart);
			var tempArr = ToLower(arr);

			foreach (var str in tempRightPart)
			{
				if (!tempArr.Contains(str)) return false;
			}

			return true;
		}
		
		private bool CompareWithRightPart(string str)
			=> ToLower(RightPart).Contains(str.ToLower());

		private bool LightCompareWithRightPart(string[] arr)
		{
			var tempRightPart = ToLower(RightPart);
			var tempArr = ToLower(arr);

			foreach (var str in tempRightPart)
			{
				if (tempArr.Contains(str)) return true;
			}

			return false;
		}

		private bool CompareWithLeftPart(string str)
			=> LeftPart.ToLower() == str.ToLower();
	}
}
