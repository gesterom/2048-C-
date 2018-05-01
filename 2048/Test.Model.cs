using NUnit.Framework;
using System;
using Application;

namespace Tests{
	namespace Model
	{
		[TestFixture ()]
		public class NewItem
		{
			[Test ()]
			public void EmptyBoard ()
			{
				//Init
					Application.Model m = new Application.Model (100); //set seed for rng 

				//Test
				m.NewItem ();

				//Assert
				bool ret = false;
				for(int i=0;i<4;i++){
					for (int j = 0; j < 4; j++) {
						if (m.GetTable () [i, j] != 0 && ret == false)
							ret = true;
						else if (m.GetTable () [i, j] != 0 && ret == true)
							Assert.Fail ();
					}
				}
				Assert.AreEqual (true, ret);
			}

			[Test()]
			public void OneSlot(){

				//Init
					Application.Model m = new Application.Model (100);
				for(int i =0;i<4;i++){
					for(int j=0;j<4;j++){
						m.GetTable() [i, j] = i * 4 + j;
					}
				}

				//Test
				m.NewItem ();

				//Assert
				for(int i =0;i<4;i++){
					for(int j=0;j<4;j++){
						if (m.GetTable () [i, j] == 0)
							Assert.Fail ();
					}
				}
				Assert.Pass ();
			}

			[Test()]
			public void FullBoard(){
				//Init
					Application.Model m = new Application.Model (100);
				for(int i =0;i<4;i++){
					for(int j=0;j<4;j++){
							m.GetTable() [i, j] = i * 4 + j+1;
					}
				}

				//Test
				

				//Assert
					Assert.Throws<OverflowException>(()=>{m.NewItem ();},"Board is Full");
			}
		}

		[TestFixture()]
		public class Left{
			[Test()]
			public void OneElement(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				
				//Test
				bool t = m.Left();

				//Assert
				for(int i=0;i<4;i++){
					for(int j=0;j<4;j++){
						if(i==3 && j==0)
							Assert.AreEqual(2,m.GetTable()[i,j]);
						else
							Assert.AreEqual(0,m.GetTable()[i,j]);
					}
				}
				Assert.AreEqual (true, t);
			}
			
			[Test()]
			public void Nothing(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 4;
				m.GetTable () [3, 2] = 3;
				m.GetTable () [3, 1] = 2;
				m.GetTable () [3, 0] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Left();

				//Assert
				temp [3, 3] = 4;
				temp [3, 2] = 3;
				temp [3, 1] = 2;
				temp [3, 0] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (false, t);
			}

			[Test()]
			public void DoubleConnect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [3, 2] = 2;
				m.GetTable () [3, 1] = 2;
				m.GetTable () [3, 0] = 2;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Left ();

				//Assert
				temp [3, 3] = 0;
				temp [3, 2] = 0;
				temp [3, 1] = 4;
				temp [3, 0] = 4;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Connect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [3, 2] = 2;
				m.GetTable () [3, 1] = 4;
				m.GetTable () [3, 0] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Left();

				//Assert
				temp [3, 3] = 0;
				temp [3, 2] = 4;
				temp [3, 1] = 4;
				temp [3, 0] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
			[Test()]
			public void ConnectPriority(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [3, 2] = 2;
				m.GetTable () [3, 1] = 2;
				m.GetTable () [3, 0] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Left();

				//Assert
				temp [3, 3] = 0;
				temp [3, 2] = 2;
				temp [3, 1] = 4;
				temp [3, 0] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
		}
		[TestFixture()]
		public class Right{
			[Test()]
			public void OneElement(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 0] = 2;

				//Test
				bool t = m.Right();

				//Assert
				for(int i=0;i<4;i++){
					for(int j=0;j<4;j++){
						if(i==3 && j==3)
							Assert.AreEqual(2,m.GetTable()[i,j]);
						else
							Assert.AreEqual(0,m.GetTable()[i,j]);
					}
				}
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Nothing(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 4;
				m.GetTable () [3, 2] = 3;
				m.GetTable () [3, 1] = 2;
				m.GetTable () [3, 0] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Right();

				//Assert
				temp [3, 3] = 4;
				temp [3, 2] = 3;
				temp [3, 1] = 2;
				temp [3, 0] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (false, t);
			}

			[Test()]
			public void DoubleConnect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [3, 2] = 2;
				m.GetTable () [3, 1] = 2;
				m.GetTable () [3, 0] = 2;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Right ();

				//Assert
				temp [3, 3] = 4;
				temp [3, 2] = 4;
				temp [3, 1] = 0;
				temp [3, 0] = 0;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Connect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [3, 2] = 2;
				m.GetTable () [3, 1] = 4;
				m.GetTable () [3, 0] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Right();

				//Assert
				temp [3, 3] = 4;
				temp [3, 2] = 4;
				temp [3, 1] = 1;
				temp [3, 0] = 0;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
			[Test()]
			public void ConnectPriority(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [3, 2] = 2;
				m.GetTable () [3, 1] = 2;
				m.GetTable () [3, 0] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Right();

				//Assert
				temp [3, 3] = 4;
				temp [3, 2] = 2;
				temp [3, 1] = 1;
				temp [3, 0] = 0;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
		}
		[TestFixture()]
		public class Up{
			[Test()]
			public void OneElement(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 0] = 2;

				//Test
				bool t = m.Up();

				//Assert
				for(int i=0;i<4;i++){
					for(int j=0;j<4;j++){
						if(i==0 && j==0)
							Assert.AreEqual(2,m.GetTable()[i,j]);
						else
							Assert.AreEqual(0,m.GetTable()[i,j]);
					}
				}
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Nothing(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 4;
				m.GetTable () [2, 3] = 3;
				m.GetTable () [1, 3] = 2;
				m.GetTable () [0, 3] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Up();

				//Assert
				temp [3,3] = 4;
				temp [2,3] = 3;
				temp [1,3] = 2;
				temp [0,3] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (false, t);
			}

			[Test()]
			public void DoubleConnect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [2, 3] = 2;
				m.GetTable () [1, 3] = 2;
				m.GetTable () [0, 3] = 2;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Up ();

				//Assert
				temp [3, 3] = 0;
				temp [2, 3] = 0;
				temp [1, 3] = 4;
				temp [0, 3] = 4;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Connect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [2, 3] = 2;
				m.GetTable () [1, 3] = 4;
				m.GetTable () [0, 3] = 1;
				int[,] temp = new int[4, 4];//m.GetTable ();

				//Test
				bool t = m.Up();

				//Assert
				temp [3, 3] = 0;
				temp [2, 3] = 4;
				temp [1, 3] = 4;
				temp [0, 3] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
			[Test()]
			public void ConnectPriority(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [2, 3] = 2;
				m.GetTable () [1, 3] = 2;
				m.GetTable () [0, 3] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Up();

				//Assert
				temp [3, 3] = 0;
				temp [2, 3] = 2;
				temp [1, 3] = 4;
				temp [0, 3] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
		}
		[TestFixture()]
		public class Down{
			[Test()]
			public void OneElement(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [0, 0] = 2;

				//Test
				bool t = m.Down();

				//Assert
				for(int i=0;i<4;i++){
					for(int j=0;j<4;j++){
						if(i==3 && j==0)
							Assert.AreEqual(2,m.GetTable()[i,j]);
						else
							Assert.AreEqual(0,m.GetTable()[i,j]);
					}
				}
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Nothing(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 4;
				m.GetTable () [2, 3] = 3;
				m.GetTable () [1, 3] = 2;
				m.GetTable () [0, 3] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Down();

				//Assert
				temp [3,3] = 4;
				temp [2,3] = 3;
				temp [1,3] = 2;
				temp [0,3] = 1;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (false, t);
			}

			[Test()]
			public void DoubleConnect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [2, 3] = 2;
				m.GetTable () [1, 3] = 2;
				m.GetTable () [0, 3] = 2;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Down ();

				//Assert
				temp [3, 3] = 4;
				temp [2, 3] = 4;
				temp [1, 3] = 0;
				temp [0, 3] = 0;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}

			[Test()]
			public void Connect(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [2, 3] = 2;
				m.GetTable () [1, 3] = 4;
				m.GetTable () [0, 3] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Down();

				//Assert
				temp [3, 3] = 4;
				temp [2, 3] = 4;
				temp [1, 3] = 1;
				temp [0, 3] = 0;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
			[Test()]
			public void ConnectPriority(){
				//Init
				Application.Model m = new Application.Model (100);
				m.GetTable () [3, 3] = 2;
				m.GetTable () [2, 3] = 2;
				m.GetTable () [1, 3] = 2;
				m.GetTable () [0, 3] = 1;
				int[,] temp = new int[4,4];

				//Test
				bool t = m.Down();

				//Assert
				temp [3, 3] = 4;
				temp [2, 3] = 2;
				temp [1, 3] = 1;
				temp [0, 3] = 0;
				Assert.AreEqual(temp,m.GetTable());
				Assert.AreEqual (true, t);
			}
		}

	}
}