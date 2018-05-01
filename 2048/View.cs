using System;

namespace Application
{
	public class View
	{
		GUIForm gui;
		IModelView model;

		public View (GUIForm GUI, IModelView Model)
		{
			this.gui = GUI;
			this.model = Model;
			this.model.Lose += LoseMessage;
			this.model.Win += WinMessage;
			this.model.BoardChange += Change;
		}

		void LoseMessage (int score)
		{
			System.Windows.Forms.MessageBox.Show ("Przegrałeś!!! Twój wynik to: " + score);
		}

		void WinMessage (int score)
		{
			System.Windows.Forms.MessageBox.Show ("Gratulacje Wygrałeś!!! Twój wynik to: " + score);
		}

		System.Drawing.Color Colored (int i)
		{
			switch (i) {
			case 0:
				return System.Drawing.Color.Wheat;
				case 1:
				return System.Drawing.Color.Gold;
				case 2:
				return System.Drawing.Color.YellowGreen;
				case 3:
				return System.Drawing.Color.Yellow;
				case 4:
				return System.Drawing.Color.Coral;
				case 5:
				return System.Drawing.Color.Aqua;
				case 6:
				return System.Drawing.Color.DodgerBlue;
				case 7:
				return System.Drawing.Color.DarkSeaGreen;
				case 8:
				return System.Drawing.Color.Cyan;
				case 9:
				return System.Drawing.Color.DarkCyan;
				case 10:
				return System.Drawing.Color.DarkGreen;
				case 11:
				return System.Drawing.Color.DarkOrange;
			default:
				return System.Drawing.Color.DeepPink;
			}
		}

		void Change (int score)
		{
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					gui.lTab [i, j].Text = model.GetTableElement (i, j).ToString();
					gui.lTab[i,j].BackColor = Colored(powof2(model.GetTableElement (i, j)));
				}
			}
		}
		static int powof2(int value){
			for(int i=0;;i++)
				if(value/2==0)
				{
					return i;
				}
				else
					value=value/2;
		}
	}
}

