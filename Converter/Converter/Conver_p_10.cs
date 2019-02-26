using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter {
	public class Conver_p_10 {
		private static int char_To_num(char ch) {
			string AllVariants = "0123456789ABCDEF";
			if (!AllVariants.Contains(ch))
				throw new IndexOutOfRangeException();
			return AllVariants.IndexOf(ch);
		}

		private static double convert(string P_num, int P, double weight) {
			if (weight % P != 0)
				throw new Exception();

			long Degree = (long)Math.Log(weight, P) - 1;
			double Result = 0.0f;

			for (int i = 0; i < P_num.Length; ++i, --Degree)
				Result += char_To_num(P_num.ElementAt(i)) * Math.Pow(P, Degree);

			return Result;
		}

		public static double dval(string P_num, int P) {
			if (P < 2 || P > 16)
				throw new IndexOutOfRangeException();
			foreach (char ch in P_num) {
				if (ch == '.')
					continue;
				if (char_To_num(ch) > P)
					throw new Exception();
			}

			double Number = 0.0f;
			Regex LeftRight = new Regex("^[0-9A-F]+\\.[0-9A-F]+$");
			Regex Right = new Regex("^0\\.[0-9A-F]+$");
			Regex Left = new Regex("^[0-9A-F]+$");
			if (LeftRight.IsMatch(P_num)) {
				Number = convert(P_num.Remove(P_num.IndexOf('.'), 1), P, Math.Pow(P, P_num.IndexOf('.')));
			} else if (Left.IsMatch(P_num)) {
				Number = convert(P_num, P, Math.Pow(P, P_num.Length));
			} else if (Right.IsMatch(P_num)) {
				Number = convert(P_num.Remove(P_num.IndexOf('.'), 1), P, 0);
			} else throw new Exception();

			return Number;
		}
	}
}