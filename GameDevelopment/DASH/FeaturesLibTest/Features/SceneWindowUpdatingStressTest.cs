using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace FeaturesLibTest
{
	/// <summary>
	/// счетчик времени 
	/// </summary>
	internal class TimerCounter
	{
		public string OperationName="";
		public DateTime StartTime;
		public DateTime StopTime;
		public TimeSpan TotalTime;
		public void Start(string operationName)
		{
			OperationName = operationName;
			StartTime = DateTime.Now;
		}

		public void Stop()
		{ 
			StopTime = DateTime.Now;
			TotalTime = GetTotalTime();
		}

		private TimeSpan GetTotalTime()
		{
			return StartTime - StopTime;
		}
	}


	/// <summary>
	/// Стресс тестирования обновления окна сцены(экрана) с большим кол-вом символов 
	/// </summary>
	public class SceneWindowUpdatingStressTest
	{
		private string[,] InitializeSceneArray(int sceneRawCount = 10, int sceneColumnCount = 10)
		{
			if (sceneRawCount < 1 || sceneColumnCount < 1) { sceneRawCount = 2; sceneColumnCount = 2; }
			string[,] scene = new string[sceneRawCount, sceneColumnCount];

			for (int raw = 0; raw < scene.GetLength(0); raw++)
			{
				for (int column = 0; column < scene.GetLength(1); column++)
				{
					scene[raw, column] = "o";
				}
			}

			if (sceneColumnCount >= 5) {
				string[] sample = { "S", "A", "M", "P", "L", "E" };

				for (int col = 0; col < sample.GetLength(0); col++) {
					scene[0, col] = sample[col];
				}
			}

			return scene;
		}


		private void ArrayShow(string[,] scene)
		{

			// setting buffer size of console - можно заранее проинициализировтаь консоль пустыми значениями.
			///Console.SetBufferSize(80, 80);

			Console.Clear();
			for (int raw = 0; raw < scene.GetLength(0); raw++)
			{
				for (int column = 0; column < scene.GetLength(1); column++)
				{
					switch (scene[raw, column])
					{
						case ("S"): Console.ForegroundColor = ConsoleColor.DarkGray; break;
						case ("A"): Console.ForegroundColor = ConsoleColor.DarkGray; break;
						case ("M"): Console.ForegroundColor = ConsoleColor.DarkGray; break;
						case ("P"): Console.ForegroundColor = ConsoleColor.DarkGray; break;
						case ("L"): Console.ForegroundColor = ConsoleColor.DarkGray; break;
						case ("E"): Console.ForegroundColor = ConsoleColor.DarkGray; break;
					}
					Console.Write(scene[raw, column]);
					Console.ResetColor();
					if (column + 1 == scene.GetLength(1)) { Console.WriteLine(); }
				}
			}

		}

		private void SetColorSymbol(string symbol) {

			switch (symbol)
			{
				case ("R"): Console.ForegroundColor = ConsoleColor.DarkRed; break;
				case ("E"): Console.ForegroundColor = ConsoleColor.Red; break;
				case ("D"): Console.ForegroundColor = ConsoleColor.Red; break;
				case ("U"): Console.ForegroundColor = ConsoleColor.Blue; break;
				case ("W"): Console.ForegroundColor = ConsoleColor.Yellow; break;
				case ("o"): Console.ForegroundColor = ConsoleColor.Green; break;
				default: Console.ResetColor(); break;
			}
		}

		private void RandomSymbolChangingStressTest(int rawCnt, int columnCnt, int changesCount = 60, int sleepMSecond = 16)
		{
			Random rnd = new Random();

			string[] symbols = { "R", "E", "D" };

			for (int i = 0; i < changesCount; i++)
			{
				ChangingSymbol(rnd.Next(0, columnCnt), rnd.Next(0, rawCnt), symbols[rnd.Next(0, symbols.Length - 1)]);
				Thread.Sleep(sleepMSecond);
			}
		}
		private void SymbolChangingUpStressTest(int rawCnt, int columnCnt, int changesCount = 60, int sleepMSecond = 16, bool showFast = true)
		{
			var runningTime = DateTime.Now;
			string fillSceneSymbol = "U";
			int sceneChanges = 0;

			for (int sceneRaw = 0; sceneRaw <= (rawCnt / 2 - 2); sceneRaw++)
			{
				for (int sceneCol = 0; sceneCol <= columnCnt && sceneChanges <= changesCount; sceneCol++, sceneChanges++)
				{
					ChangingSymbol(sceneRaw, sceneCol, fillSceneSymbol);
				}
			}
			var stopTime = DateTime.Now;
			var timeCount = stopTime - runningTime;
			ChangingSymbol(rawCnt + 3, 0, $"UpMethodTime:{timeCount.ToString()}"); ;
		}

		//TODO: закончить, 
		private void SymbolChangingDownStressTest(int rawCnt, int columnCnt, int changesCount = 60, int sleepMSecond = 16, bool showFast = true)
		{
			var runningTime = DateTime.Now;
			string fillSceneSymbol = "W";
			int sceneChanges = 0;

			for (int sceneRaw = rawCnt; sceneRaw >= (rawCnt / 2); sceneRaw--)
			{
				for (int sceneCol = columnCnt; sceneCol >= 0 && sceneChanges <= changesCount; sceneCol--, sceneChanges++)
				{
					ChangingSymbol(sceneRaw, sceneCol, fillSceneSymbol);
				}
			}
			var stopTime = DateTime.Now;
			var timeCount = stopTime - runningTime;
			ChangingSymbol(rawCnt + 1, 0, $"\nDownMethodTime:{timeCount.ToString()}"); ;
		}

		private void ChangingSymbol(int rawCursorPosition, int columnCursorPosition, string addedSymbol)
		{
			bool cursorVisible = false;
			//Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // для перестановки курсора в начало и конец
			Console.CursorVisible = cursorVisible;
			Console.SetCursorPosition(columnCursorPosition, rawCursorPosition);
			SetColorSymbol(addedSymbol);
			Console.Write(addedSymbol);
			Console.ResetColor();
		}


		/// <summary>
		/// метод отображения и обновления сцены
		/// </summary>
		public void ShowSceneArray(int raw = 10, int column = 10, int changesCount = 60, int sleepMSecond = 16)
		{
			ArrayShow(InitializeSceneArray(raw, column));
			Console.ReadKey();
			RandomSymbolChangingStressTest(raw, column, (raw * column), sleepMSecond);
		}


		/// <summary>
		/// Бстрого обновления большой сцены
		/// </summary>
		public void FastShowSceneArray(int raw = 10, int column = 10, int changesCount = 60, int sleepMSecond = 16)
		{
			var runningTime = DateTime.Now;
			ArrayShow(InitializeSceneArray(raw, column));
			Console.ReadKey();
			
			//Паралельное выполнение - результат такой же, так как консоль неявно синхронизирует потоки и получается синхронное выполнение.
			//припроста стокрости - нет
			Task.Run(() => SymbolChangingUpStressTest(raw, column, (raw * column), sleepMSecond, showFast: true));
			Task.Run(() => SymbolChangingDownStressTest(raw, column, (raw * column), sleepMSecond, showFast: true));
			var stopTime = DateTime.Now;
			var timeCount = stopTime - runningTime;
			ChangingSymbol(raw + 3, 0, $"\nTotalMethodTime:{timeCount.ToString()}"); ;
			Console.ReadKey();

			////вывести на консоль сразу строку через Write
			///Вот туту существенный прирост скорости!
			char simb = 'R';
			char[] textArray = new char[column];
			for (int i = 0; i < column; i++) { textArray[i] = simb; }
			string textRaw = String.Concat<char>(textArray);

			var runningTimeRaw = DateTime.Now;

			for (int i = 0; i < raw; i++)
			{
				ChangingSymbol(i, 0, textRaw); 
			}
			var stopTimeRaw = DateTime.Now;
			var timeCountRaw = stopTimeRaw - runningTimeRaw;
			ChangingSymbol(raw + 4, 0, $"\nStringMethodTime:{timeCountRaw.ToString()}"); ;

			Console.ReadKey();
		}

		///
		public void ColorizedScene(int raw = 10, int column = 10)
		{
			var methodTimeRun= DateTime.Now;

			var initForeachTimeRun = DateTime.Now;
			string[,] testArr = InitializeSceneArray(raw, column);

			foreach (var e in testArr) { }

			var initForeachTimeStop = DateTime.Now;
			var initForeachTimeTotal = initForeachTimeStop - initForeachTimeRun;
			ChangingSymbol(raw + 3, 0, $"\nInitForeachTimeTotal:{initForeachTimeTotal.ToString()}"); 

			//
			var showArrTimeRun = DateTime.Now;
			ArrayShow(testArr);

			var showArrTimeStop = DateTime.Now;
			var showArrTimeTotal = showArrTimeStop - showArrTimeRun;
			ChangingSymbol(raw + 4, 0, $"\nShowArrTimeTotal:{showArrTimeTotal.ToString()}");

			//
			var colorizedTimeRun = DateTime.Now;

			for (int i = 0; i < testArr.GetLength(0); i++)
			{
				for (int j = 0; j < testArr.GetLength(1); j++)
				{
					SetColorSymbol(testArr[i,j]);
				}
			}


			

			var colorizedTimeStop = DateTime.Now;
			var colorizedTimeTotal = colorizedTimeStop - colorizedTimeRun;
			ChangingSymbol(raw + 5, 0, $"\ncolorizedTimeRun:{colorizedTimeTotal.ToString()}");

			//ИТОГ
			var methodTimeStop = DateTime.Now;
			var methodTimeTotal = methodTimeStop - methodTimeRun;
			ChangingSymbol(raw + 6, 0, $"\nMethodTime:{methodTimeTotal.ToString()}");


		}


		
	}


	


}
