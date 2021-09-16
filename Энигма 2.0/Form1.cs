using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Энигма_2._0
{
	public partial class Form1 : Form
	{
		Boolean ok = true, check = true, twice = true;
		int word = 0, past = 0, temp;
		String Al = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		String Rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
		String Rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
		String Rotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
		String Rotor4 = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
		String Rotor5 = "VZBRGITYUPSDNHLXAWMJQOFECK";
		String Rotor6 = "JPGVOUMFYQBENHZRDKASXLICTW";
	    String Rotor7 = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
		String Rotor8 = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
		String ReflectorB = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
		String ReflectorA = "EJMZALYXVBWFCRQUONTSPIKHGD";
		String ReflectorC = "FVPJIAOYEDRZXWGCTKUQSBNMHL";

		public void Reflectors() //функция, позволяющая выбрать различные рефлекторы
		{
			if (domainUpDown11.Text == "B")
				ReflectorB = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
				if (domainUpDown11.Text == "A")
				ReflectorB = "EJMZALYXVBWFCRQUONTSPIKHGD";
			if (domainUpDown11.Text == "C")
				ReflectorB = "FVPJIAOYEDRZXWGCTKUQSBNMHL";
		}
		public void Rotors() //функция, позволяющая выбрать различные роторы в произвольном порядке
		{
			switch (numericUpDown1.Value)
			{
				case 1: Rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; break;
				case 2: Rotor1 = "AJDKSIRUXBLHWTMCQGZNPYFVOE"; break;
				case 3: Rotor1 = "BDFHJLCPRTXVZNYEIWGAKMUSQO"; break;
				case 4: Rotor1 = "ESOVPZJAYQUIRHXLNFTGKDCMWB"; break;
				case 5: Rotor1 = "VZBRGITYUPSDNHLXAWMJQOFECK"; break;
				case 6: Rotor1 = "JPGVOUMFYQBENHZRDKASXLICTW"; break;
				case 7: Rotor1 = "NZJHGRCXMYSWBOUFAIVLPEKQDT"; break;
				case 8: Rotor1 = "FKQHTLXOCBJSPDZRAMEWNIUYGV"; break;
			}
			switch (numericUpDown2.Value)
			{
				case 1: Rotor2 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; break;
				case 2: Rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE"; break;
				case 3: Rotor2 = "BDFHJLCPRTXVZNYEIWGAKMUSQO"; break;
				case 4: Rotor2 = "ESOVPZJAYQUIRHXLNFTGKDCMWB"; break;
				case 5: Rotor2 = "VZBRGITYUPSDNHLXAWMJQOFECK"; break;
				case 6: Rotor2 = "JPGVOUMFYQBENHZRDKASXLICTW"; break;
				case 7: Rotor2 = "NZJHGRCXMYSWBOUFAIVLPEKQDT"; break;
				case 8: Rotor2 = "FKQHTLXOCBJSPDZRAMEWNIUYGV"; break;
			}
			switch (numericUpDown3.Value)
			{
				case 1: Rotor3 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; break;
				case 2: Rotor3 = "AJDKSIRUXBLHWTMCQGZNPYFVOE"; break;
				case 3: Rotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO"; break;
				case 4: Rotor3 = "ESOVPZJAYQUIRHXLNFTGKDCMWB"; break;
				case 5: Rotor3 = "VZBRGITYUPSDNHLXAWMJQOFECK"; break;
				case 6: Rotor3 = "JPGVOUMFYQBENHZRDKASXLICTW"; break;
				case 7: Rotor3 = "NZJHGRCXMYSWBOUFAIVLPEKQDT"; break;
				case 8: Rotor3 = "FKQHTLXOCBJSPDZRAMEWNIUYGV"; break;
			}
		}
		public void StartPosition() //функция меняет позиции роторов
		{
			if (check) //это для того, чтобы буква не печаталась в richtextbox1 дважды, когда мы используем клавиатуру
				richTextBox1.Text += Al[word];
			else
				check = true;
			vScrollBar1.Value = Al.IndexOf(textBox1.Text);
			vScrollBar2.Value = Al.IndexOf(textBox2.Text);
			vScrollBar3.Value = Al.IndexOf(textBox3.Text);
			if (vScrollBar1.Value + 1 < 26)
				textBox1.Text = Convert.ToString(Al[vScrollBar1.Value + 1]);
			else
				textBox1.Text = Convert.ToString(Al[0]);

			if (textBox1.Text == "R")
				if (vScrollBar2.Value + 1 < 26)
					textBox2.Text = Convert.ToString(Al[vScrollBar2.Value + 1]);
				else
					textBox2.Text = Convert.ToString(Al[0]);

			if (textBox2.Text == "R")
				if (vScrollBar3.Value + 1 < 26)
					textBox3.Text = Convert.ToString(Al[vScrollBar3.Value + 1]);
				else
					textBox3.Text = Convert.ToString(Al[0]);
		}
		public void Light() //функция, реализующая подсветку букв, поданых на выход
		{
			switch (past)//лампочки (лэйблы) гаснут
			{
				case 0: label44.ForeColor = Color.Black; break;
				case 1: label29.ForeColor = Color.Black; break;
				case 2: label31.ForeColor = Color.Black; break;
				case 3: label39.ForeColor = Color.Black; break;
				case 4: label50.ForeColor = Color.Black; break;
				case 5: label38.ForeColor = Color.Black; break;
				case 6: label37.ForeColor = Color.Black; break;
				case 7: label40.ForeColor = Color.Black; break;
				case 8: label45.ForeColor = Color.Black; break;
				case 9: label35.ForeColor = Color.Black; break;
				case 10: label34.ForeColor = Color.Black; break;
				case 11: label36.ForeColor = Color.Black; break;
				case 12: label27.ForeColor = Color.Black; break;
				case 13: label28.ForeColor = Color.Black; break;
				case 14: label43.ForeColor = Color.Black; break;
				case 15: label42.ForeColor = Color.Black; break;
				case 16: label52.ForeColor = Color.Black; break;
				case 17: label49.ForeColor = Color.Black; break;
				case 18: label41.ForeColor = Color.Black; break;
				case 19: label48.ForeColor = Color.Black; break;
				case 20: label46.ForeColor = Color.Black; break;
				case 21: label30.ForeColor = Color.Black; break;
				case 22: label51.ForeColor = Color.Black; break;
				case 23: label32.ForeColor = Color.Black; break;
				case 24: label47.ForeColor = Color.Black; break;
				case 25: label33.ForeColor = Color.Black; break;
			}

			switch (word)//лампочки (лэйблы) зажигаются
			{
				case 0: label44.ForeColor = Color.Yellow; break;
				case 1: label29.ForeColor = Color.Yellow; break;
				case 2: label31.ForeColor = Color.Yellow; break;
				case 3: label39.ForeColor = Color.Yellow; break;
				case 4: label50.ForeColor = Color.Yellow; break;
				case 5: label38.ForeColor = Color.Yellow; break;
				case 6: label37.ForeColor = Color.Yellow; break;
				case 7: label40.ForeColor = Color.Yellow; break;
				case 8: label45.ForeColor = Color.Yellow; break;
				case 9: label35.ForeColor = Color.Yellow; break;
				case 10: label34.ForeColor = Color.Yellow; break;
				case 11: label36.ForeColor = Color.Yellow; break;
				case 12: label27.ForeColor = Color.Yellow; break;
				case 13: label28.ForeColor = Color.Yellow; break;
				case 14: label43.ForeColor = Color.Yellow; break;
				case 15: label42.ForeColor = Color.Yellow; break;
				case 16: label52.ForeColor = Color.Yellow; break;
				case 17: label49.ForeColor = Color.Yellow; break;
				case 18: label41.ForeColor = Color.Yellow; break;
				case 19: label48.ForeColor = Color.Yellow; break;
				case 20: label46.ForeColor = Color.Yellow; break;
				case 21: label30.ForeColor = Color.Yellow; break;
				case 22: label51.ForeColor = Color.Yellow; break;
				case 23: label32.ForeColor = Color.Yellow; break;
				case 24: label47.ForeColor = Color.Yellow; break;
				case 25: label33.ForeColor = Color.Yellow; break;
			}
			past = word;
		}
		public void Algorithm() //функция шифрует введенный пользователем символ
		{
			//Сам алгоритм шифрования (источник вдохновения: https://habr.com/ru/post/217331/)
			temp = word;
			word = (word + vScrollBar1.Value) % 26; //с клавиатуры подаем символ на 1 ротор;  word - это пременная,которая хранит индекс буквы в алфавите

			word = Al.IndexOf(Rotor1[word]); //символ подается с первого ротора на второй
			if (Math.Abs(vScrollBar2.Value - vScrollBar1.Value) < (26 - Math.Abs(vScrollBar2.Value - vScrollBar1.Value)))
				word = (word + Math.Abs(vScrollBar2.Value - vScrollBar1.Value)) % 26;
			else
				word = (word + (26 - Math.Abs(vScrollBar2.Value - vScrollBar1.Value))) % 26;

			word = Al.IndexOf(Rotor2[word]);//символ подается со второг ротора на третий
			if (Math.Abs(vScrollBar3.Value - vScrollBar2.Value) < (26 - Math.Abs(vScrollBar3.Value - vScrollBar2.Value)))
				word = (word + Math.Abs(vScrollBar3.Value - vScrollBar2.Value)) % 26;
			else
				word = (word + (26 - Math.Abs(vScrollBar3.Value - vScrollBar2.Value))) % 26;

			word = Al.IndexOf(Rotor3[word]);//символ подается с третьего ротора на рефлектор
			if (vScrollBar3.Value > word)
				word += 26;
			word = (word - vScrollBar3.Value) % 26;
			word = Al.IndexOf(ReflectorB[word]);
			word = (word + vScrollBar3.Value) % 26;//после преобразований символ подается с рефлектора на третий ротор

			word = Rotor3.IndexOf(Al[word]);//символ подается с третьего ротора на второй
			if (Math.Abs(vScrollBar3.Value - vScrollBar2.Value) < (26 - Math.Abs(vScrollBar3.Value - vScrollBar2.Value)))
			{
				if (Math.Abs(vScrollBar3.Value - vScrollBar2.Value) > word)
					word += 26;
				word = (word - Math.Abs(vScrollBar3.Value - vScrollBar2.Value)) % 26;
			}
			else
			{
				if (Math.Abs(vScrollBar3.Value - vScrollBar2.Value) > word)
					word += 26;
				word = (word - (26 - Math.Abs(vScrollBar3.Value - vScrollBar2.Value))) % 26;
			}

			word = Rotor2.IndexOf(Al[word]);//символ подается со второго ротора на третий
			if (Math.Abs(vScrollBar2.Value - vScrollBar1.Value) < (26 - Math.Abs(vScrollBar2.Value - vScrollBar1.Value)))
			{
				if (Math.Abs(vScrollBar2.Value - vScrollBar1.Value) > word)
					word += 26;
				word = (word - Math.Abs(vScrollBar2.Value - vScrollBar1.Value)) % 26;
			}
			else
			{
				if (Math.Abs(vScrollBar2.Value - vScrollBar1.Value) > word)
					word += 26;
				word = (word - (26 - Math.Abs(vScrollBar2.Value - vScrollBar1.Value))) % 26;
			}

			word = Rotor1.IndexOf(Al[word]);//символ подается с первого ротора на выход

			if (vScrollBar1.Value > word)
				word += 26;
			word = (word - vScrollBar1.Value) % 26;

			if (temp == word) //проверяем, чтобы выходной символ не был равен входному, если равняется, то сдвигаем его на 1 единицу вперед
				word = (word + 1) % 26;
		}
		public void Komutators() //функция, реализующая коммутацию
		{
			if (domainUpDown1.Text == domainUpDown2.Text)
				checkBox1.Checked = false;
			if (domainUpDown3.Text == domainUpDown4.Text)
				checkBox2.Checked = false;
			if (domainUpDown5.Text == domainUpDown6.Text)
				checkBox3.Checked = false;
			if (domainUpDown7.Text == domainUpDown8.Text)
				checkBox4.Checked = false;
			if (domainUpDown9.Text == domainUpDown10.Text)
				checkBox5.Checked = false;

			if (checkBox1.Checked)
			{
				if ((checkBox2.Checked && (domainUpDown1.Text != domainUpDown3.Text && domainUpDown1.Text != domainUpDown4.Text) &&
					(checkBox2.Checked && (domainUpDown2.Text != domainUpDown3.Text && domainUpDown2.Text != domainUpDown4.Text))) ||
					(checkBox3.Checked && (domainUpDown1.Text != domainUpDown5.Text && domainUpDown1.Text != domainUpDown6.Text) &&
					(checkBox3.Checked && (domainUpDown2.Text != domainUpDown5.Text && domainUpDown2.Text != domainUpDown6.Text))) ||
					(checkBox4.Checked && (domainUpDown1.Text != domainUpDown7.Text && domainUpDown1.Text != domainUpDown8.Text) &&
					(checkBox4.Checked && (domainUpDown2.Text != domainUpDown7.Text && domainUpDown2.Text != domainUpDown8.Text))) ||
					(checkBox5.Checked && (domainUpDown1.Text != domainUpDown9.Text && domainUpDown1.Text != domainUpDown10.Text) &&
					(checkBox5.Checked && (domainUpDown2.Text != domainUpDown9.Text && domainUpDown2.Text != domainUpDown10.Text))) ||
					(!checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked))
				{
					if (word == Al.IndexOf((domainUpDown1.Text)))
						word = Al.IndexOf((domainUpDown2.Text));
					else if (word == Al.IndexOf((domainUpDown2.Text)))
						word = Al.IndexOf((domainUpDown1.Text));
				}
				else
				{
					ok = false;
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = false;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
				}
			}
			if (checkBox2.Checked)
			{
				if ((checkBox1.Checked && (domainUpDown3.Text != domainUpDown1.Text && domainUpDown3.Text != domainUpDown2.Text) &&
					(checkBox1.Checked && (domainUpDown4.Text != domainUpDown1.Text && domainUpDown4.Text != domainUpDown2.Text))) ||
					(checkBox3.Checked && (domainUpDown3.Text != domainUpDown5.Text && domainUpDown3.Text != domainUpDown6.Text) &&
					(checkBox3.Checked && (domainUpDown4.Text != domainUpDown5.Text && domainUpDown4.Text != domainUpDown6.Text))) ||
					(checkBox4.Checked && (domainUpDown3.Text != domainUpDown7.Text && domainUpDown3.Text != domainUpDown8.Text) &&
					(checkBox4.Checked && (domainUpDown4.Text != domainUpDown7.Text && domainUpDown4.Text != domainUpDown8.Text))) ||
					(checkBox5.Checked && (domainUpDown3.Text != domainUpDown9.Text && domainUpDown3.Text != domainUpDown10.Text) &&
					(checkBox5.Checked && (domainUpDown4.Text != domainUpDown9.Text && domainUpDown4.Text != domainUpDown10.Text))) ||
					(!checkBox1.Checked && !checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked))
				{
					if (word == Al.IndexOf((domainUpDown3.Text)))
						word = Al.IndexOf((domainUpDown4.Text));
					else if (word == Al.IndexOf((domainUpDown4.Text)))
						word = Al.IndexOf((domainUpDown3.Text));
				}
				else
				{
					ok = false;
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = false;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
				}
			}
			if (checkBox3.Checked)
			{
				if ((checkBox1.Checked && (domainUpDown5.Text != domainUpDown1.Text && domainUpDown5.Text != domainUpDown2.Text) &&
					(checkBox1.Checked && (domainUpDown6.Text != domainUpDown1.Text && domainUpDown6.Text != domainUpDown2.Text))) ||
					(checkBox2.Checked && (domainUpDown5.Text != domainUpDown3.Text && domainUpDown5.Text != domainUpDown4.Text) &&
					(checkBox2.Checked && (domainUpDown6.Text != domainUpDown3.Text && domainUpDown6.Text != domainUpDown4.Text))) ||
					(checkBox4.Checked && (domainUpDown5.Text != domainUpDown7.Text && domainUpDown5.Text != domainUpDown8.Text) &&
					(checkBox4.Checked && (domainUpDown6.Text != domainUpDown7.Text && domainUpDown6.Text != domainUpDown8.Text))) ||
					(checkBox5.Checked && (domainUpDown5.Text != domainUpDown9.Text && domainUpDown5.Text != domainUpDown10.Text) &&
					(checkBox5.Checked && (domainUpDown6.Text != domainUpDown9.Text && domainUpDown6.Text != domainUpDown10.Text))) ||
					(!checkBox1.Checked && !checkBox2.Checked && !checkBox4.Checked && !checkBox5.Checked))
				{
					if (word == Al.IndexOf((domainUpDown5.Text)))
						word = Al.IndexOf((domainUpDown6.Text));
					else if (word == Al.IndexOf((domainUpDown6.Text)))
						word = Al.IndexOf((domainUpDown5.Text));
				}
				else
				{
					ok = false;
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = false;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
				}
			}
			if (checkBox4.Checked)
			{
				if ((checkBox1.Checked && (domainUpDown7.Text != domainUpDown1.Text && domainUpDown7.Text != domainUpDown2.Text) &&
					(checkBox1.Checked && (domainUpDown8.Text != domainUpDown1.Text && domainUpDown8.Text != domainUpDown2.Text))) ||
					(checkBox2.Checked && (domainUpDown7.Text != domainUpDown3.Text && domainUpDown7.Text != domainUpDown4.Text) &&
					(checkBox2.Checked && (domainUpDown8.Text != domainUpDown3.Text && domainUpDown8.Text != domainUpDown4.Text))) ||
					(checkBox3.Checked && (domainUpDown7.Text != domainUpDown5.Text && domainUpDown7.Text != domainUpDown6.Text) &&
					(checkBox3.Checked && (domainUpDown8.Text != domainUpDown5.Text && domainUpDown8.Text != domainUpDown6.Text))) ||
					(checkBox5.Checked && (domainUpDown7.Text != domainUpDown9.Text && domainUpDown7.Text != domainUpDown10.Text) &&
					(checkBox5.Checked && (domainUpDown8.Text != domainUpDown9.Text && domainUpDown8.Text != domainUpDown10.Text))) ||
					(!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox5.Checked))
				{
					if (word == Al.IndexOf((domainUpDown7.Text)))
						word = Al.IndexOf((domainUpDown8.Text));
					else if (word == Al.IndexOf((domainUpDown8.Text)))
						word = Al.IndexOf((domainUpDown7.Text));
				}
				else
				{
					ok = false;
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = false;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
				}
			}
			if (checkBox5.Checked)
			{
				if ((checkBox1.Checked && (domainUpDown9.Text != domainUpDown1.Text && domainUpDown9.Text != domainUpDown2.Text) &&
					(checkBox1.Checked && (domainUpDown10.Text != domainUpDown1.Text && domainUpDown10.Text != domainUpDown2.Text))) ||
					(checkBox2.Checked && (domainUpDown9.Text != domainUpDown3.Text && domainUpDown9.Text != domainUpDown4.Text) &&
					(checkBox2.Checked && (domainUpDown10.Text != domainUpDown3.Text && domainUpDown10.Text != domainUpDown4.Text))) ||
					(checkBox3.Checked && (domainUpDown9.Text != domainUpDown5.Text && domainUpDown9.Text != domainUpDown6.Text) &&
					(checkBox3.Checked && (domainUpDown10.Text != domainUpDown5.Text && domainUpDown10.Text != domainUpDown6.Text))) ||
					(checkBox4.Checked && (domainUpDown9.Text != domainUpDown7.Text && domainUpDown9.Text != domainUpDown8.Text) &&
					(checkBox4.Checked && (domainUpDown10.Text != domainUpDown7.Text && domainUpDown10.Text != domainUpDown8.Text))) ||
					(!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked))
				{
					if (word == Al.IndexOf((domainUpDown9.Text)))
						word = Al.IndexOf((domainUpDown10.Text));
					else if (word == Al.IndexOf((domainUpDown10.Text)))
						word = Al.IndexOf((domainUpDown9.Text));
				}
				else
				{
					ok = false;
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = false;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
				}
			}

			if (!ok && twice)
			{
				MessageBox.Show("Ошибка в коммутации. Проверьте правильность включения коммутаторов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				twice = false;
			}
		}
		public void Keyboard(object sender, KeyEventArgs e) //функция, обрабатывающая нажатия с клавиатуры
		{
			if (e.KeyCode == Keys.Space) //нажатие пробела
			{
				richTextBox2.Text += " ";
			}
			if (e.KeyCode == Keys.Enter) //нажатие enter
			{ 
				richTextBox2.Text += "\n";
			}
			if (e.KeyCode == Keys.Q) //нажатия различных клавиш на клавиатуре...
			{
				check = false;
				label1_Click(sender,e);
				richTextBox1.SelectionStart += 1;
			}
			if (e.KeyCode == Keys.W)
			{
				check = false;
				label2_Click(sender, e);
			}
			if (e.KeyCode == Keys.E)
			{
				check = false;
				label3_Click(sender, e);
			}
			if (e.KeyCode == Keys.R)
			{
				check = false;
				label4_Click(sender, e);
			}
			if (e.KeyCode == Keys.T)
			{
				check = false;
				label5_Click(sender, e);
			}
			if (e.KeyCode == Keys.Y)
			{
				check = false;
				label6_Click(sender, e);
			}
			if (e.KeyCode == Keys.U)
			{
				check = false;
				label7_Click(sender, e);
			}
			if (e.KeyCode == Keys.I)
			{
				check = false;
				label8_Click(sender, e);
			}
			if (e.KeyCode == Keys.O)
			{
				check = false;
				label10_Click(sender, e);
			}
			if (e.KeyCode == Keys.P)
			{
				check = false;
				label11_Click(sender, e);
			}
			if (e.KeyCode == Keys.A)
			{
				check = false;
				label9_Click(sender, e);
			}
			if (e.KeyCode == Keys.S)
			{
				check = false;
				label12_Click(sender, e);
			}
			if (e.KeyCode == Keys.D)
			{
				check = false;
				label14_Click(sender, e);
			}
			if (e.KeyCode == Keys.F)
			{
				check = false;
				label15_Click(sender, e);
			}
			if (e.KeyCode == Keys.G)
			{
				check = false;
				label16_Click(sender, e);
			}
			if (e.KeyCode == Keys.H)
			{
				check = false;
				label13_Click(sender, e);
			}
			if (e.KeyCode == Keys.J)
			{
				check = false;
				label18_Click(sender, e);
			}
			if (e.KeyCode == Keys.K)
			{
				check = false;
				label19_Click(sender, e);
			}
			if (e.KeyCode == Keys.L)
			{
				check = false;
				label17_Click_1(sender,e);
			}
			if (e.KeyCode == Keys.Z)
			{
				check = false;
				label20_Click(sender, e);
			}
			if (e.KeyCode == Keys.X)
			{
				check = false;
				label21_Click(sender, e);
			}
			if (e.KeyCode == Keys.C)
			{
				check = false;
				label22_Click(sender, e);
			}
			if (e.KeyCode == Keys.V)
			{
				check = false;
				label23_Click(sender, e);
			}
			if (e.KeyCode == Keys.B)
			{
				check = false;
				label24_Click(sender, e);
			}
			if (e.KeyCode == Keys.N)
			{
				check = false;
				label25_Click(sender, e);
			}
			if (e.KeyCode == Keys.M)
			{
				check = false;
				label26_Click(sender, e);
			}
		}
		public void ShowOnScreen() //функция, выводящая буквы нв экран
		{
			richTextBox2.Text += Al[word]; //выводим букву на экран
			richTextBox1.SelectionStart += richTextBox1.Text.Length+1; // это сдвиг курсора
			twice = true; //чтобы предупреждение об ошибке появлялось только один раз
		}

	public void Shifr() //основная функция
		{
			Komutators(); //функция, реализующая коммутацию
			Rotors(); //функция, позволяющая выбрать различные роторы в произвольном порядке
			Reflectors(); //функция, позволяющая выбрать различные рефлекторы
			StartPosition(); //функция меняет позиции роторов
			Algorithm(); //функция шифрует введенный пользователем символ 
			Komutators(); //функция, реализующая коммутацию
			ShowOnScreen(); //функция, выводящая буквы нв экран
			Light(); //функция, реализующая подсветку букв, поданых на выход
		}
		private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			Keyboard(sender, e); //функция, обрабатывающая нажатия с клавиатуры
		}
		public void textbox()
		{
			vScrollBar1.Value = Al.IndexOf(textBox1.Text);
			vScrollBar2.Value = Al.IndexOf(textBox2.Text);
			vScrollBar3.Value = Al.IndexOf(textBox3.Text);
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void label21_Click(object sender, EventArgs e)
		{
			word = 23;
			Shifr();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			word = 16;
			Shifr();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			word = 0;
			Shifr();
		}

		private void label24_Click(object sender, EventArgs e)
		{
			word = 1;
			Shifr();
		}

		private void label22_Click(object sender, EventArgs e)
		{
			word = 2;
			Shifr();
		}

		private void label14_Click(object sender, EventArgs e)
		{
			word = 3;
			Shifr();
		}

		private void label3_Click(object sender, EventArgs e)
		{
			word = 4;
			Shifr();
		}

		private void label15_Click(object sender, EventArgs e)
		{
			word = 5;
			Shifr();
		}

		private void label16_Click(object sender, EventArgs e)
		{
			word = 6;
			Shifr();
		}

		private void label13_Click(object sender, EventArgs e)
		{
			word = 7;
			Shifr();
		}

		private void label18_Click(object sender, EventArgs e)
		{
			word = 9;
			Shifr();
		}

		private void label8_Click(object sender, EventArgs e)
		{
			word = 8;
			Shifr();
		}

		private void label19_Click(object sender, EventArgs e)
		{
			word = 10;
			Shifr();
		}

		private void label17_Click_1(object sender, EventArgs e)
		{
			word = 11;
			Shifr();
		}

		private void label26_Click(object sender, EventArgs e)
		{
			word = 12;
			Shifr();
		}

		private void label25_Click(object sender, EventArgs e)
		{
			word = 13;
			Shifr();
		}

		private void label10_Click(object sender, EventArgs e)
		{
			word = 14;
			Shifr();
		}

		private void label11_Click(object sender, EventArgs e)
		{
			word = 15;
			Shifr();
		}

		private void label4_Click(object sender, EventArgs e)
		{
			word = 17;
			Shifr();
		}

		private void label12_Click(object sender, EventArgs e)
		{
			word = 18;
			Shifr();
		}

		private void label5_Click(object sender, EventArgs e)
		{
			word = 19;
			Shifr();
		}

		private void label7_Click(object sender, EventArgs e)
		{
			word = 20;
			Shifr();
		}

		private void label23_Click(object sender, EventArgs e)
		{
			word = 21;
			Shifr();
		}

		private void label2_Click(object sender, EventArgs e)
		{
			word = 22;
			Shifr();
		}

		private void label6_Click(object sender, EventArgs e)
		{
			word = 24;
			Shifr();
		}

		private void label20_Click(object sender, EventArgs e)
		{
			word = 25;
			Shifr();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			textbox();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			textbox();
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			textbox();
		}

		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			textBox1.Text = Convert.ToString(Al[vScrollBar1.Value]);
		}

		private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
		{

		}

		private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			switch (past)//лампочки (лэйблы) гаснут через 5 секунд
			{
				case 0: label44.ForeColor = Color.Black; break;
				case 1: label29.ForeColor = Color.Black; break;
				case 2: label31.ForeColor = Color.Black; break;
				case 3: label39.ForeColor = Color.Black; break;
				case 4: label50.ForeColor = Color.Black; break;
				case 5: label38.ForeColor = Color.Black; break;
				case 6: label37.ForeColor = Color.Black; break;
				case 7: label40.ForeColor = Color.Black; break;
				case 8: label45.ForeColor = Color.Black; break;
				case 9: label35.ForeColor = Color.Black; break;
				case 10: label34.ForeColor = Color.Black; break;
				case 11: label36.ForeColor = Color.Black; break;
				case 12: label27.ForeColor = Color.Black; break;
				case 13: label28.ForeColor = Color.Black; break;
				case 14: label43.ForeColor = Color.Black; break;
				case 15: label42.ForeColor = Color.Black; break;
				case 16: label52.ForeColor = Color.Black; break;
				case 17: label49.ForeColor = Color.Black; break;
				case 18: label41.ForeColor = Color.Black; break;
				case 19: label48.ForeColor = Color.Black; break;
				case 20: label46.ForeColor = Color.Black; break;
				case 21: label30.ForeColor = Color.Black; break;
				case 22: label51.ForeColor = Color.Black; break;
				case 23: label32.ForeColor = Color.Black; break;
				case 24: label47.ForeColor = Color.Black; break;
				case 25: label33.ForeColor = Color.Black; break;
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void domainUpDown2_SelectedItemChanged_1(object sender, EventArgs e)
		{
			checkBox1.Checked = false;
		}

		private void domainUpDown1_SelectedItemChanged_1(object sender, EventArgs e)
		{
			checkBox1.Checked = false;
		}

		private void domainUpDown4_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox2.Checked = false;
		}

		private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox2.Checked = false;
		}

		private void domainUpDown8_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox3.Checked = false;
		}

		private void domainUpDown7_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox3.Checked = false;
		}

		private void domainUpDown6_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox4.Checked = false;
		}

		private void domainUpDown5_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox4.Checked = false;
		}

		private void domainUpDown10_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox5.Checked = false;
		}

		private void domainUpDown9_SelectedItemChanged(object sender, EventArgs e)
		{
			checkBox5.Checked = false;
		}

		private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
		{
			textBox2.Text = Convert.ToString(Al[vScrollBar2.Value]);
		}

		private void vScrollBar3_Scroll(object sender, ScrollEventArgs e)
		{
			textBox3.Text = Convert.ToString(Al[vScrollBar3.Value]);
		}
	}
}