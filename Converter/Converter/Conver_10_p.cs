using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter {
	public class Conver_10_p {
		public static string Do(double n, int p, int c) {
			if (p < 2 || p > 16)
				throw new IndexOutOfRangeException();
			if (c < 0 || c > 10)
				throw new IndexOutOfRangeException();

			int LeftSide = (int)n;

			double RightSide = 0f;
			RightSide = n - LeftSide;
			if (RightSide < 0)
				RightSide *= -1;

			string LeftSideString = int_to_P(LeftSide, p);
			string RightSideString = flt_to_P(RightSide, p, c);

			return LeftSideString + (RightSideString == String.Empty ? "" : ".") + RightSideString;
		}

		public static char int_to_Char(int d) {
			if (d < 0 || d > 15)
				throw new IndexOutOfRangeException();

			string SymbolArray = "0123456789ABCDEF";
			return SymbolArray.ElementAt(d);
		}

		public static string int_to_P(int n, int p) {
			if (p < 2 || p > 16)
				throw new IndexOutOfRangeException();
			bool HaveMinus = false;
			if (n < 0) {
				HaveMinus = true;
				n *= -1;
			}
			string PNumber = string.Empty;

			while (n > 0) {
				PNumber += int_to_Char(n % p);
				n /= p;
			}

			if (HaveMinus)
				PNumber += "-";

			char[] TempArray = PNumber.ToCharArray();
			Array.Reverse(TempArray);
			return new string(TempArray);
		}

		public static string flt_to_P(double n, int p, int c) {
			if (p < 2 || p > 16)
				throw new IndexOutOfRangeException();
			if (c < 0 || c > 10)
				throw new IndexOutOfRangeException();

			string PNumber = string.Empty;
			for (int i = 0; i < c; ++i) {
				PNumber += int_to_Char((int)(n * p));
				n = n * p - (int)(n * p);
			}
			return PNumber;
		}
	}
}
