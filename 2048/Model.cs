
using System;

namespace Application
{
	public delegate void GameOver (int score);
	public class Model: IModelView, IModelControler
	{
		int[,] board;
		public event GameOver Win;
		public event GameOver Lose;
		public event GameOver BoardChange;
		int score;
		Random ran;

		public Model ()
		{
			board = new int[4, 4];
			Win = x => {
			};
			Lose = x => {
			};
			BoardChange = x => {
			};
			NewGame ();
		}

		public Model (int value)
		{
			board = new int[4, 4];
			Win = x => {
			};
			Lose = x => {
			};
			BoardChange = x => {
			};
			NewGame (value);
		}

		public int GetTableElement (int i, int j)
		{
			return board [i, j];
		}

		public int[,] GetTable ()
		{
			return board;
		}

		public void NewGame ()
		{
			ran = new Random ();
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					board [i, j] = 0;
				}
			}
			score = 0;
			NewItem();
			BoardChange (score);
		}

		public void NewGame (int Seed)
		{
			NewGame ();
			ran = new Random (Seed);
	
		}

		public void setTable (int[,] value)
		{
			board = value;
		}

		public void NewItem ()
		{
			if (BoardIsBlocked ())
				throw new OverflowException ("Board is Full");
			else {
				int temp = ran.Next (16);
				for (int i = 0;; i++) {
					int temp2 = (temp + i) % 16;
					if (board [temp2 / 4, temp2 % 4] == 0) {
						board [temp2 / 4, temp2 % 4] = ((ran.Next (5) == 0) ? (4) : (2));
						break;
					}
				}
			}
		}

		public void Move (Side side)
		{
			bool BlockMoved;
			switch (side) {
			case Side.Left:
				BlockMoved = Left ();
				break;
			case Side.Right:
				BlockMoved = Right ();
				break;
			case Side.Down:
				BlockMoved = Down ();
				break;
			case Side.Up:
				BlockMoved = Up ();
				break;
			default:
				return;
			}
			if (BlockMoved) {
				score++;
				if (IsWin ()) {
					Win (score);
					NewGame ();
					return;
				}
				NewItem ();
				BoardChange(score);
			}
			if (NoMove () && BoardIsBlocked()) {
				Lose (score);
				NewGame ();
				return;
			}
		}

		public bool Left ()
		{
			bool IsMoved = false;
			IsMoved |= Gravity (0, -1);
			IsMoved |= ConnectLeftUp (0, -1);
			IsMoved |= Gravity (0, -1);
			return IsMoved;
		}

		public bool Right ()
		{
			bool IsMoved = false;
			IsMoved |= Gravity (0, 1);
			IsMoved |= ConnectRightDown (0, 1);
			IsMoved |= Gravity (0, 1);
			return IsMoved;
		}

		public bool Up ()
		{
			bool IsMoved = false;
			IsMoved |= Gravity (-1, 0);
			IsMoved |= ConnectLeftUp (-1, 0);
			IsMoved |= Gravity (-1, 0);
			return IsMoved;
		}

		public bool Down ()
		{
			bool IsMoved = false;
			IsMoved |= Gravity (1, 0);
			IsMoved |= ConnectRightDown (1, 0);
			IsMoved |= Gravity (1, 0);
			return IsMoved;
		}

		bool BoardIsBlocked ()
		{
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++)
					if (board [i, j] == 0)
						return false;
			}
			return true;
		}

		bool Gravity (int deltaI, int deltaJ)
		{
			bool Fall = false;
			for (int iter = 0; iter < 4; iter++) {
				int tempI = ((deltaI < 0) ? (-deltaI) : (0));
				int tempJ = ((deltaJ < 0) ? (-deltaJ) : (0));

				for (int i = tempI; (i + deltaI < 4) && (i < 4); i++) {
					for (int j = tempJ; (j + deltaJ < 4) && (j < 4); j++) {
						if (board [i + deltaI, j + deltaJ] == 0 && board [i, j] != 0) {
							Fall = true;
							board [i + deltaI, j + deltaJ] = board [i, j];
							board [i, j] = 0;
						}
					}
				}
			}
			return Fall;
		}

		bool ConnectLeftUp (int deltaI, int deltaJ)
		{
			bool ConnectAnyBlock = false;

			int tempI = ((deltaI < 0) ? (-deltaI) : (0));
			int tempJ = ((deltaJ < 0) ? (-deltaJ) : (0));

			for (int i = tempI; (i + deltaI < 4) && (i < 4); i++) {
				for (int j = tempJ; (j + deltaJ < 4) && (j < 4); j++) {
					if (board [i + deltaI, j + deltaJ] == board [i, j] && board [i, j] != 0) {
						ConnectAnyBlock = true;
						board [i + deltaI, j + deltaJ] += board [i, j];
						board [i, j] = 0;
					}
				}
			}
			return ConnectAnyBlock;
		}

		bool ConnectRightDown (int deltaI, int deltaJ)
		{
			bool ConnectAnyBlock = false;

			int tempI = ((deltaI > 0) ? (2) : (3));
			int tempJ = ((deltaJ > 0) ? (2) : (3));

			for (int i = tempI; (i >= 0); i--) {
				for (int j = tempJ; (j >= 0); j--) {
					if (board [i + deltaI, j + deltaJ] == board [i, j] && board [i, j] != 0) {
						ConnectAnyBlock = true;
						board [i + deltaI, j + deltaJ] += board [i, j];
						board [i, j] = 0;
					}
				}
			}
			return ConnectAnyBlock;
		}

		bool IsWin ()
		{
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++)
					if (board [i, j] == 2048)
						return true;
			}
			return false;
		}

		bool NoMove ()
		{
			var testmodel = new Model ();
			var tab = new int[4, 4];
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					tab [i, j] = GetTable () [i, j];
				}
			}

			bool ret = false;
			testmodel.setTable (tab);
			ret |= testmodel.Left ();
			testmodel.setTable (tab);
			ret |= testmodel.Right ();
			testmodel.setTable (tab);
			ret |= testmodel.Up ();
			testmodel.setTable (tab);
			ret |= testmodel.Down ();
			return !ret;
		}
	}
}

