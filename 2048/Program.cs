using System;

namespace Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{	
			var m = new Model ();
			var g = new GUIForm();
			var v = new View(g,m);
			var c = new Controler(g,m);
			System.Windows.Forms.Application.Run(g);
		}
	}
}
