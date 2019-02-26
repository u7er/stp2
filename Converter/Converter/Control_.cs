using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter {
	class Control_ {
		int pin = 10;
		int pout = 16;
		const int accuracy = 10;
		public History his = new History();
		public enum State { Edit, Converted }
		private State st;

		internal State St { get => st; set => st = value; }
		public int Pin { get => pin; set => pin = value; }
		public int Pout { get => pout; set => pout = value; }

		public Control_() {
			St = State.Edit;
			Pin = pin;
			Pout = pout;
		}

		public Editor ed = new Editor();

		public string DoCmnd(int j) {
			if (j == 19) {
				double r = Conver_p_10.dval(ed.Number, Pin);
				string res = Conver_10_p.Do(r, Pout, acc());
				St = State.Converted;
				his.AddRecord(Pin, Pout, ed.Number, res);
				return res;
			} else {
				St = State.Edit;
				return ed.DoEdit(j);
			}
		}

		private int acc() {
			return (int)Math.Round(ed.Acc() * Math.Log(Pin) / Math.Log(Pout) + 0.5);
		}
	}
}
