using System;

namespace Application
{
	public enum Side{
		Left,
		Right,
		Up,
		Down
	};
	public interface IModelControler
	{
		void Move(Side side);
		void NewGame();
	}
}

