using System;

namespace Application
{
	public interface IModelView
	{
		int GetTableElement(int i,int j);
		event GameOver Win;
		event GameOver Lose;
		event GameOver BoardChange;

	}
}

