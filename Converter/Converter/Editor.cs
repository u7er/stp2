using System;

namespace Converter {
	public class Editor {
		string number = zero;
		const string delim = ".";
		const string zero = "0";

		public string Number { get => number; set => number = value; }

		public string AddDigit(int n) {
			if (n < 0 || n > 16)
				throw new IndexOutOfRangeException();
			if (number == zero)
				number = Conver_10_p.int_to_Char(n).ToString();
			else
				number += Conver_10_p.int_to_Char(n);
			return Number;
		}

		//Возвращает точность
		public int Acc() {
			return number.Contains(delim) ? number.Length - number.IndexOf(delim) - 1 : 0;
		}

		public string AddZero() {
			return AddDigit(0);
		}

		public string AddDelim() {
			if (number.Length > 0 && !number.Contains(delim))
				number += delim;
			return Number;
		}

		//Удалить символ справа
		public string Bs() {
			if (number.Length > 1)
				number = number.Remove(Number.Length - 1);
			else
				number = zero;
			return Number;
		}

		public string Clear() {
			number = zero;
			return Number;
		}

		public string DoEdit(int j) {
			switch (j) {
				case 0:
				AddZero();
				break;
				case 1:
				AddDigit(1);
				break;
				case 2:
				AddDigit(2);
				break;
				case 3:
				AddDigit(3);
				break;
				case 4:
				AddDigit(4);
				break;
				case 5:
				AddDigit(5);
				break;
				case 6:
				AddDigit(6);
				break;
				case 7:
				AddDigit(7);
				break;
				case 8:
				AddDigit(8);
				break;
				case 9:
				AddDigit(9);
				break;
				case 10:
				AddDigit(10);
				break;
				case 11:
				AddDigit(11);
				break;
				case 12:
				AddDigit(12);
				break;
				case 13:
				AddDigit(13);
				break;
				case 14:
				AddDigit(14);
				break;
				case 15:
				AddDigit(15);
				break;
				case 16:
				AddDelim();
				break;
				case 17:
				Bs();
				break;
				case 18:
				Clear();
				break;
				default:
				return number;
			}
			return number;
		}
	}
}
