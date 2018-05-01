using System;

namespace Application
{
	public class Controler
	{
		GUIForm gui;
		IModelControler model;

		public Controler (GUIForm gui, IModelControler model)
		{
			this.gui = gui;
			this.model = model;
			gui.bNewGame.Click += NewGameAction;
			gui.bExit.Click += ExitAction;

			gui.bDown.Click += DownAction;
			gui.bUp.Click += UpAction;
			gui.bLeft.Click += LeftAction;
			gui.bRight.Click += RightAction;

			gui.KeyPress += Gui_KeyPress;
			gui.bDown.KeyPress += Gui_KeyPress;
			gui.bUp.KeyPress += Gui_KeyPress;
			gui.bLeft.KeyPress += Gui_KeyPress;
			gui.bRight.KeyPress += Gui_KeyPress;
			gui.bNewGame.KeyPress += Gui_KeyPress;
			gui.bExit.KeyPress += Gui_KeyPress;
		}

		void Gui_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 's') {
				DownAction (sender, e);
			}
			if (e.KeyChar == 'a') {
				LeftAction (sender, e);
			}
			if (e.KeyChar == 'd') {
				RightAction (sender, e);
			}
			if (e.KeyChar == 'w') {
				UpAction (sender, e);
			}
//				Console.WriteLine("Donwl");
////			System.Windows.Forms.MessageBox.Show(sender.ToString() + " " + e.ToString());
//			Console.WriteLine(sender.ToString() + " " + e.ToString());
		}

		void NewGameAction (object sender, EventArgs arg)
		{
			this.model.NewGame ();
		}

		void DownAction (object sender, EventArgs arg)
		{
			this.model.Move (Side.Down);
		}

		void UpAction (object sender, EventArgs arg)
		{
			this.model.Move (Side.Up);
		}

		void RightAction (object sender, EventArgs arg)
		{
			this.model.Move (Side.Right);
		}

		void LeftAction (object sender, EventArgs arg)
		{
			this.model.Move (Side.Left);
		}

		void ExitAction (object sender, EventArgs arg)
		{
			System.Windows.Forms.Application.Exit ();
		}
	}
}

