using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeOnlyOneSymbolOfRaw
{
	/// <summary>
	/// Пытаюсь изменить символ в выведенной строке массива, не очищая коносль и выводя обновленный массив заного
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			ChangeSymbol cs = new ChangeSymbol();
			cs.Start();
			Console.ReadKey();
		}
	}
	class ChangeSymbol
	{


		public void Start()
		{
			string[,] field = {
				{ "о","о","о","о","о","о"},
				{ "о","о","о","о","о","о"},
				{ "о","S","M","P","L","о"},
				{ "о","о","о","о","о","о"},
				{ "о","о","о","о","о","о"},
				{ "о","о","о","о","о","о"},
				{ "о","о","о","о","о","о"}
			};

			ArrayShow(field);
			Console.ReadKey();
			//ChangingSymbol(4,3,"V");
			//Console.ReadKey();
			//ChangingSymbol(3,6,"N");//при выводе символов из массива, в коносле по умолчанию добавляется пробел,я могу вписывать и туда значения 
			//Console.ReadKey();
			RandomSymbolChangingStressTest(field);
			Console.ReadKey();

		}
		private void ArrayShow(string[,] field)
		{
			Console.Clear();
			for (int raw = 0; raw < field.GetLength(0); raw++)
			{
				Console.WriteLine();
				for (int column = 0; column < field.GetLength(1); column++)
				{
					if (field[raw, column] == "S") { Console.ForegroundColor = ConsoleColor.DarkGray; }
					if (field[raw, column] == "A") { Console.ForegroundColor = ConsoleColor.DarkGray; }
					if (field[raw, column] == "M") { Console.ForegroundColor = ConsoleColor.DarkGray; }
					if (field[raw, column] == "P") { Console.ForegroundColor = ConsoleColor.DarkGray; }
					if (field[raw, column] == "L") { Console.ForegroundColor = ConsoleColor.DarkGray; }
					if (field[raw, column] == "E") { Console.ForegroundColor = ConsoleColor.DarkGray; }
					Console.Write(field[raw, column] + " ");
					Console.ResetColor();
				}

			}
		}
		private void RandomSymbolChangingStressTest(string[,]field , int changesCount = 60)
		{
			Random rnd = new Random();
			var fieldRawCnt = field.GetLength(0);
			var fieldColumnCnt = field.GetLength(1);

			string[] symbols = { "R", "E", "D" };

			for (int i = 0; i < changesCount; i++)
			{
				ChangingSymbol(rnd.Next(0,fieldRawCnt-1), rnd.Next(0, fieldColumnCnt - 1), symbols[rnd.Next(0,symbols.Length-1)]);
				Thread.Sleep(300);
			}
		}

		private void ChangingSymbol(int leftCursorPosition, int rightCursorPosition,string addedSymbol)
		{
			//Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
			Console.SetCursorPosition(leftCursorPosition,rightCursorPosition);
			Console.ForegroundColor = ConsoleColor.Red; 
			Console.Write(addedSymbol);
			Console.ResetColor();
		}

	}
}
