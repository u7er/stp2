using System;
using System.Windows.Forms;

namespace Converter {
	public partial class Form1 : Form {
		Control_ ctl = new Control_();
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			label1.Text = ctl.ed.Number;
			trackBar1.Value = ctl.Pin;
			trackBar2.Value = ctl.Pout;
			label3.Text = "Основание с. сч. исходного числа " + trackBar1.Value;
			label4.Text = "Основание с. сч. результата " + trackBar2.Value;
			label2.Text = "0";
			UpdateButtons();
		}

		private void DoCmnd(int j) {
			if (j == 19) {
				label2.Text = ctl.DoCmnd(j);
			} else {
				if (ctl.St == Control_.State.Converted) {
					label1.Text = ctl.DoCmnd(18);
				}
				label1.Text = ctl.DoCmnd(j);
				label2.Text = "0";
			}
		}
		private void UpdateButtons() {
			foreach (Control i in Controls) {
				if (i is Button) {
					int j = Convert.ToInt16(i.Tag.ToString());
					if (j < trackBar1.Value) {
						i.Enabled = true;
					}
					if ((j >= trackBar1.Value) && (j <= 15)) {
						i.Enabled = false;
					}
				}
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e) {
			numericUpDown1.Value = trackBar1.Value;
			UpdateP1();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			trackBar1.Value = Convert.ToByte(numericUpDown1.Value);
			UpdateP1();
		}

		private void UpdateP1() {
			label3.Text = "Основание с. сч. исходного числа " +
			trackBar1.Value;
			ctl.Pin = trackBar1.Value;
			UpdateButtons();
			label1.Text = ctl.DoCmnd(18);
			label2.Text = "0";
		}

		private void trackBar2_Scroll(object sender, EventArgs e) {
			numericUpDown2.Value = trackBar2.Value;
			UpdateP2();
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
			trackBar2.Value = Convert.ToByte(numericUpDown2.Value);
			UpdateP2();
		}

		private void UpdateP2() {
			ctl.Pout = trackBar2.Value;
			label2.Text = ctl.DoCmnd(19);
			label4.Text = "Основание с. сч. результата " +
			trackBar2.Value;
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void историяToolStripMenuItem_Click(object sender, EventArgs e) {
			Form2 history = new Form2();
			history.Show();
			if (ctl.his.Count() == 0) {
				history.textBox1.AppendText("История пуста");
				return;
			}
			for (int i = 0; i < ctl.his.Count(); i++) {
				history.textBox1.AppendText(ctl.his[i].ToString() + Environment.NewLine);
			}
		}

		private void справкаToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutBox1 a = new AboutBox1();
			a.Show();
		}

		private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
			int i = -1;
			if (e.KeyChar >= 'A' && e.KeyChar <= 'F')
				i =	e.KeyChar - 'A' + 10;
			if (e.KeyChar >= 'a' && e.KeyChar <= 'f')
				i =	e.KeyChar - 'a' + 10;
			if (e.KeyChar >= '0' && e.KeyChar <= '9')
				i = e.KeyChar - '0';
			if (e.KeyChar == '.')
				i = 16;
			if (e.KeyChar == 8)
				i = 17;
			if (e.KeyChar == 13)
				i = 19;
			if ((i < ctl.Pin) || (i >= 16))
				DoCmnd(i);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete)
				DoCmnd(18);
			if (e.KeyCode == Keys.Execute)
				DoCmnd(19);
			if (e.KeyCode == Keys.Decimal)
				DoCmnd(16);
		}

		private void button_Click(object sender, EventArgs e) {
			Button but = (Button)sender;
			int j = Convert.ToInt16(but.Tag.ToString());
			DoCmnd(j);
		}
	}
}
