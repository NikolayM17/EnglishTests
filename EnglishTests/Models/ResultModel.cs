using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTests.Models
{
	public class ResultModel
	{
		public int Score { get; set; }
		public int MaxScore { get; }

		public ResultModel(int maxScore)
		{
			Score = 0;
			MaxScore = maxScore;
		}
		public ResultModel(int score, int maxScore)
		{
			Score = score;
			MaxScore = maxScore;
		}

		public override string ToString()
		{
			return $"{Score} / {MaxScore}";
		}

		public static ResultModel operator++ (ResultModel model)
		{
			return new ResultModel(model.Score + 1, model.MaxScore);
		}

		public static ResultModel operator+ (ResultModel model, int value)
		{
			return new ResultModel(model.Score + value, model.MaxScore);
		}

		public static bool operator== (ResultModel model, int value)
		{
			return model.Score == value;
		}

		public static bool operator!= (ResultModel model, int value)
		{
			return !(model.Score == value);
		}
	}
}
