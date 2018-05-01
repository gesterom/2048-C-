using System;
using System.Windows.Forms;
using System.Drawing;

namespace Application
{
	public class GUIForm :Form
	{
		public Button bLeft;
		public Button bRight;
		public Button bUp;
		public Button bDown;
		public Button bNewGame;
		public Button bExit;
		public Label[,] lTab;
		//MenuStrip m;

		public GUIForm ()
		{
			bNewGameC ();
			bExitC ();
			bLeftC ();
			bRightC ();
			bUpC ();
			bDownC ();
			mainwindow ();
			Tabel ();

			Show ();
		}

		void mainwindow ()
		{
			Height = 500;
			Width = 550;
			CenterToScreen ();
			this.Text = "2048 by Sylwester Mazanek";
			FormClosed += clo;
		}

		void clo (object obj, EventArgs arg)
		{
			MessageBox.Show ("Dziękuję za grę!!!.\n\n Autor Sylwester Mazanek\n\n" + "Build:\t   " + System.Windows.Forms.Application.ProductVersion);
		}

		void bNewGameC ()
		{
			this.bNewGame = new Button ();
			this.bNewGame.Location = new Point (32, 32);
			this.bNewGame.Text = "New Game";
			this.bNewGame.Width = 128;
			this.bNewGame.Height = 64;
			this.Controls.Add (bNewGame);
		}

		void bExitC ()
		{
			this.bExit = new Button ();
			this.bExit.Location = new Point (32 + 128 + 32, 32);
			this.bExit.Text = "Exit";
			this.bExit.Width = 128;
			this.bExit.Height = 64;
			this.Controls.Add (bExit);
		}

		void bDownC ()
		{
			this.bDown = new Button ();
			this.bDown.Location = new Point (400 - 64 + 64, 400 - 64 + 64);
			this.bDown.Text = "Down";
			this.bDown.Width = 64;
			this.bDown.Height = 64;
			this.Controls.Add (bDown);
		}

		void bUpC ()
		{
			this.bUp = new Button ();
			this.bUp.Location = new Point (400 - 64 + 64, 400 - 64 * 3 + 64);
			this.bUp.Text = "Up";
			this.bUp.Width = 64;
			this.bUp.Height = 64;
			this.Controls.Add (bUp);
		}

		void bLeftC ()
		{
			this.bLeft = new Button ();
			this.bLeft.Location = new Point (400 - 64 * 2 + 64, 400 - 128 + 64);
			this.bLeft.Text = "Left";
			this.bLeft.Width = 64;
			this.bLeft.Height = 64;
			this.Controls.Add (bLeft);
		}

		void bRightC ()
		{
			this.bRight = new Button ();
			this.bRight.Location = new Point (400 + 64, 400 - 128 + 64);
			this.bRight.Text = "Right";
			this.bRight.Width = 64;
			this.bRight.Height = 64;
			this.Controls.Add (bRight);
		}

		void Tabel ()
		{
			lTab = new Label[4, 4];
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					lTab [i, j] = NewTabElement (i, j);
				}
			}
		}

		Label NewTabElement (int x, int y)
		{
			Label l11 = new Label ();
			l11.BackColor = Color.Chocolate;
			l11.Location = new Point (64 + y * 64, 128 + x * 64);
			l11.Height = 48;
			l11.Width = 48;
			l11.Text = (x*4+y+1).ToString();
			this.Controls.Add (l11);
			return l11;
		}
	}
}

