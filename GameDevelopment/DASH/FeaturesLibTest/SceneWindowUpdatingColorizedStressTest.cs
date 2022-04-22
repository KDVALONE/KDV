using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturesLibTest
{
	/// <summary>
	/// Следующая итерация, обновление сцены и окрашивание.
	/// попытка получить максимальный ФПС
	/// </summary>
	public class SceneWindowUpdatingColorizedStressTest
	{

		private string[,] InitializeSceneArrayForColorized(int sceneRawCount, int sceneColumnCount)
		{

			string[,] scene = new string[sceneRawCount, sceneColumnCount];

			for (int raw = 0; raw < scene.GetLength(0); raw++)
			{
				for (int column = 0; column < scene.GetLength(1); column++)
				{
					scene[raw, column] = "o";
				}
			}
			return scene;
		}

		/// Добавляет к сцене цифры 5-4-3-2-1-0

		private string[,] InitToSceneNumberFive(string[,] scene)
		{
			var sceneNumberFive = new string[scene.GetLength(0), scene.GetLength(1)];

			string number = "R";
			//верхняя палка вправо
			for (int raw = 4; raw < 6; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberFive[raw, column] = number;
				}
			}

			//верхнаяя черта вниз
			for (int raw = 6; raw < 9; raw++)
			{
				for (int column = 5; column < 8; column++)
				{
					sceneNumberFive[raw, column] = number;
				}
			}

			//средняя палка вправо
			for (int raw = 9; raw < 11; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberFive[raw, column] = number;
				}
			}

			//средняя черта вниз
			for (int raw = 11; raw < 17; raw++)
			{
				for (int column = scene.GetLength(1) - 8; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberFive[raw, column] = number;
				}
			}

			//нижняя черта вправо
			for (int raw = 17; raw < 20; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberFive[raw, column] = number;
				}
			}

			return sceneNumberFive;

		}
		private string[,] InitToSceneNumberFour(string[,] scene)
		{
			var sceneNumberFour = new string[scene.GetLength(0), scene.GetLength(1)];

			string number = "V";
			//верхнаяя черта вниз
			for (int raw = 4; raw < 9; raw++)
			{
				for (int column = 5; column < 8; column++)
				{
					sceneNumberFour[raw, column] = number;
				}
			}

			//средняя палка вправо
			for (int raw = 9; raw < 11; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberFour[raw, column] = number;
				}
			}

			//Верхняя правая черта вниз общая
			for (int raw = 4; raw < 20; raw++)
			{
				for (int column = scene.GetLength(1) - 8; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberFour[raw, column] = number;
				}
			}

			return sceneNumberFour;

		}
		private string[,] InitToSceneNumberThree(string[,] scene)
		{

			var sceneNumberThree = new string[scene.GetLength(0), scene.GetLength(1)];
			string number = "S";

			//верхняя палка вправо
			for (int raw = 4; raw < 6; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberThree[raw, column] = number;
				}
			}

			//Верхняя правая черта вниз общая
			for (int raw = 4; raw < 20; raw++)
			{
				for (int column = scene.GetLength(1) - 8; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberThree[raw, column] = number;
				}
			}

			//средняя палка вправо
			for (int raw = 9; raw < 11; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberThree[raw, column] = number;
				}
			}

			//нижняя черта вправо
			for (int raw = 17; raw < 20; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberThree[raw, column] = number;
				}
			}

			return sceneNumberThree;

		}
		private string[,] InitToSceneNumberTwo(string[,] scene)
		{

			var sceneNumberTwo = new string[scene.GetLength(0), scene.GetLength(1)];

			string number = "T";

			//верхняя палка вправо
			for (int raw = 4; raw < 6; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberTwo[raw, column] = number;
				}
			}

			//Верхняя левая черта вниз половина
			for (int raw = 4; raw < 9; raw++)
			{
				for (int column = scene.GetLength(1) - 8; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberTwo[raw, column] = number;
				}
			}

			//средняя палка вправо
			for (int raw = 9; raw < 11; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberTwo[raw, column] = number;
				}
			}

			//левая средняя черта вниз
			for (int raw = 11; raw < 17; raw++)
			{
				for (int column = 5; column < 8; column++)
				{
					sceneNumberTwo[raw, column] = number;
				}
			}

			//нижняя черта вправо
			for (int raw = 17; raw < 20; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberTwo[raw, column] = number;
				}
			}

			return sceneNumberTwo;

		}
		private string[,] InitToSceneNumberOne(string[,] scene)
		{

			var sceneNumberOne = new string[scene.GetLength(0), scene.GetLength(1)];

			string number = "D";

			//Верхняя правая черта вниз общая
			for (int raw = 4; raw < 20; raw++)
			{
				for (int column = scene.GetLength(1) - 8; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberOne[raw, column] = number;
				}
			}

			return sceneNumberOne;

		}
		private string[,] InitToSceneNumberZero(string[,] scene)
		{
			var sceneNumberZero = new string[scene.GetLength(0), scene.GetLength(1)];

			string number = "N";

			//верхняя палка вправо
			for (int raw = 4; raw < 6; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberZero[raw, column] = number;
				}
			}

			//Верхняя правая черта вниз общая
			for (int raw = 4; raw < 20; raw++)
			{
				for (int column = scene.GetLength(1) - 8; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberZero[raw, column] = number;
				}
			}
			//Верхняя левая черта вниз общая
			for (int raw = 4; raw < 20; raw++)
			{
				for (int column = 5; column < 8; column++)
				{
					sceneNumberZero[raw, column] = number;
				}
			}

			//нижняя черта вправо
			for (int raw = 17; raw < 20; raw++)
			{
				for (int column = 5; column < scene.GetLength(1) - 5; column++)
				{
					sceneNumberZero[raw, column] = number;
				}
			}


			return sceneNumberZero;

		}

		//установить цвет в зависимости от символа
		private void SetColorSymbol(string symbol)
		{

			switch (symbol)
			{
				case ("R"): Console.ForegroundColor = ConsoleColor.DarkRed; break;
				case ("T"): Console.ForegroundColor = ConsoleColor.Red; break;
				case ("D"): Console.ForegroundColor = ConsoleColor.Cyan; break;
				case ("S"): Console.ForegroundColor = ConsoleColor.Blue; break;
				case ("V"): Console.ForegroundColor = ConsoleColor.Yellow; break;
				case ("N"): Console.ForegroundColor = ConsoleColor.Green; break;
				default: Console.ResetColor(); break;
			}
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
		private void ChangingElements(int rawCursorPosition, int columnCursorPosition, string addedSymbol, string color)
		{
			bool cursorVisible = false;
			//Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // для перестановки курсора в начало и конец
			Console.CursorVisible = cursorVisible;
			Console.SetCursorPosition(columnCursorPosition, rawCursorPosition);
			SetColorSymbol(color);
			Console.Write(addedSymbol);
			Console.ResetColor();
		}

		private void ChangingElementsNoChangeColor(string addedSymbol, string color)
		{
			bool cursorVisible = false;
			//Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // для перестановки курсора в начало и конец
			Console.CursorVisible = cursorVisible;
			//SetColorSymbol(color);
			Console.Write(addedSymbol);
			//Console.ResetColor();
		}


		/// <summary>
		/// Отобразить сцену,
		/// Пребором каждого символа массива
		/// Медленный способ
		/// </summary>
		private void ShowSceneOneSybolChangingRealisation(string[,] scene)
		{

			for (int sceneRaw = 0; sceneRaw < scene.GetLength(0); sceneRaw++)
			{
				for (int sceneCol = 0; sceneCol < scene.GetLength(1); sceneCol++)
				{
					ChangingSymbol(sceneRaw, sceneCol, scene[sceneRaw, sceneCol]);
				}
			}

		}

		/// <summary>
		/// Отобразить сцену,
		/// загружать их по одной строчке выставляя цвет
		/// очень быстры способ, 0.017mc но подходит для только для ЧБ реализации
		/// </summary>
		private void ShowSceneOneLiningRealisation(string[,] scene)
		{

			//Переключаем на нужный цвет консоль 
			string color = "o";
			bool changingSybol = false;

			for (int sceneRaw = 0; sceneRaw < scene.GetLength(0); sceneRaw++)
			{
				for (int sceneCol = 0; sceneCol < scene.GetLength(1); sceneCol++)
				{
					if (scene[sceneRaw, sceneCol] == "R" ||
						scene[sceneRaw, sceneCol] == "T" ||
						scene[sceneRaw, sceneCol] == "D" ||
						scene[sceneRaw, sceneCol] == "S" ||
						scene[sceneRaw, sceneCol] == "V" ||
						scene[sceneRaw, sceneCol] == "N") { color = scene[sceneRaw, sceneCol]; changingSybol = true; break; }

					// Удалить //ChangingSymbol(sceneRaw, sceneCol, scene[sceneRaw, sceneCol]);
				}
				if (changingSybol == true) { break; }
			}

			// парсим в строку елементов в тип Стринг (Определенно переделать в стринг билдер или топ того)
			List<string> rawList = new List<string>();
			for (int sceneRaw = 0; sceneRaw < scene.GetLength(0); sceneRaw++)
			{
				string rawConcate = "";
				for (int sceneCol = 0; sceneCol < scene.GetLength(1); sceneCol++)
				{
					if (String.IsNullOrEmpty(scene[sceneRaw, sceneCol]))
					{
						rawConcate += " ";
					}
					else { rawConcate += scene[sceneRaw, sceneCol]; }

				}
				rawList.Add(rawConcate);
			}


			//SetColorSymbol(color);

			//Построчно обнавляем сразу строкой
			for (int sceneRaw = 0; sceneRaw < scene.GetLength(0); sceneRaw++)
			{
				ChangingElements(sceneRaw, 0, rawList[sceneRaw], color);
			}
		}

		/// <summary>
		/// Отобразить сцену,
		/// Декомпазировать по цеветам, загружать их по одной строчке
		/// Выдает!!! СУПЕР!! не по строчке а разом! скорочть 0.020сек
		/// </summary>
		private void ShowSceneLiningIterationRealisation(string[,] scene) 
		{
			string color = "";

			//Список линий по колву выводимых строк, в которых сгруппированы символы для расскрашивания 
			List<List<string>> rawLines = new List<List<string>>(scene.GetLength(0));
			for (int lines = 0; lines < scene.GetLength(0); lines++) { rawLines.Add( new List<string>()); }

			string buf = "";
			string rawConcate = "";
			for (int sceneRaw = 0; sceneRaw < scene.GetLength(0); sceneRaw++)
			{
				buf = "";
				rawConcate = "";
				for (int sceneCol = 0; sceneCol < scene.GetLength(1); sceneCol++)
				{


					//TODO: Вывод в строку в текущей реализации сбоит с NULL значениями, они замешаются пробелами в моей реализации,
					// что ведет к появлению пустых строчек, так как они перезатирают пердидущие символы.
					// пробелы нужны, По хорошему нужно переписать создав структуру которая будет хранить в себе информацию о позиции и тд.
					#region old realization
					//** Вот тут можно переписать чтоб сохранять расположение курсора и прыгать по нему, 

					//Запоминаем предидущий символ при первой проходке
					//if (sceneCol == 0) { buf = scene[sceneRaw, sceneCol]; }

					//конатенируем строку и заодно запоминаем текущий символ
					if (String.IsNullOrEmpty(scene[sceneRaw, sceneCol]))
					{
						if (buf != " " && sceneCol != 0) { buf = " "; rawLines[sceneRaw].Add(rawConcate); } 
						else rawConcate += " "; 						
					}
					else {

						if (buf != scene[sceneRaw, sceneCol]) { buf = scene[sceneRaw, sceneCol]; rawLines[sceneRaw].Add(rawConcate); rawConcate = ""; }
						else { rawConcate += scene[sceneRaw, sceneCol]; }
					}
				}
				//rawLines[sceneRaw].Add(rawConcate);

				#endregion
			}

			//Построчно обнавляем группами строк
			for (int listRaw = 0; listRaw < rawLines.Count; listRaw++)
			{
				Console.SetCursorPosition(0, listRaw);
				foreach (var e in rawLines[listRaw])
				{
					SetColorSymbol(char.ToString(e[0]));
					ChangingElementsNoChangeColor(e, color);
				}
				
			}


		}

		//Сравнение скорости обновлений экрана
		public void ColorizeEqualsVariant(int raw = 60, int column = 120)
		{
			//логирование
			var LogTimeMethod = new TimerCounter();
			var LogTimeShowSceneOneSybolChanging = new TimerCounter();
			var LogTimeShowSceneLining = new TimerCounter();
			var ShowSceneLiningIteration = new TimerCounter();

			//Пауза для 
			Console.WriteLine("PressSpaceToStart!");
			Console.ReadKey();
			//логирование всего хода исполнения
			LogTimeMethod.Start("FullMethodTime");




			//пустая сцена
			var sceneEpty = InitializeSceneArrayForColorized(raw, column);
			//сцены с цифрами
			var sceneFive = InitToSceneNumberFive(sceneEpty);
			var sceneFour = InitToSceneNumberFour(sceneEpty);
			var sceneThree = InitToSceneNumberThree(sceneEpty);
			var sceneTwo = InitToSceneNumberTwo(sceneEpty);
			var sceneOne = InitToSceneNumberOne(sceneEpty);
			var sceneZero = InitToSceneNumberZero(sceneEpty);



			//вывод массива, тяжелая версия каждый вывод почти 1 секунду
			LogTimeShowSceneOneSybolChanging.Start("ShowSceneOneSybolChangingRealization");
			ShowSceneOneSybolChangingRealisation(sceneEpty);
			//ShowSceneOneSybolChangingRealisation(sceneFive);
			//ShowSceneOneSybolChangingRealisation(sceneFour);
			LogTimeShowSceneOneSybolChanging.Stop();

			//смена реализации
			Console.ReadKey();
			Console.WriteLine("\n END. PRESS ANY KEY TO NEXT REALIZATION ");
			//Очистка экрана
			//Console.Clear();



			//вывод массива построчно более быстрая версия. !! обновление происходит за 0.017 секунды!
			//LogTimeShowSceneLining.Start("ShowSceneOneLiningRealisation");
			//ShowSceneOneLiningRealisation(sceneFive);
			//LogTimeShowSceneLining.Stop();


			//смена реализации
			//Console.ReadKey();
			//Console.WriteLine("\n END. PRESS ANY KEY TO NEXT REALIZATION ");
			//Очистка экрана
			//Console.Clear();

			//Вывод массив построчно, раскраска 

			ShowSceneLiningIteration.Start("ShowSceneLiningIterationRealization");
			
			//Смотри сколько разм сможет за секунду 45 fps Выдает!!! СУПЕР!! Вот это можно еще оптимизировать
			
			//TODO:
			//Так, погоди! Ты сделал метод который раскрашивает все за одно исполнение!
			//Теперь оптимизируй чтоб он раскрашивал только те символы которые менялись!

			int fpsCount = 0;
			var startTime = DateTime.Now.Millisecond;
			var stopTime = startTime - 1;
			bool isFive = true;
			//while (DateTime.Now.Millisecond > stopTime) 
			//{
				//if (isFive) { 
					ShowSceneLiningIterationRealisation(sceneFive); isFive = false; 
				//}else { 
				//	ShowSceneLiningIterationRealisation(sceneFour); isFive = true; }
				//fpsCount++;
			//}
			
			ShowSceneLiningIteration.Stop();


			// вывод статистики
			LogTimeMethod.Stop();
			Console.ReadKey();
			Console.WriteLine("\n");
			Console.Write($"Strart:{LogTimeShowSceneOneSybolChanging.StartTime}_Finish:{LogTimeShowSceneOneSybolChanging.StopTime}_execute:{LogTimeShowSceneOneSybolChanging.TotalTime.ToString()}_{LogTimeShowSceneOneSybolChanging.OperationName}_ \n");
			//Console.WriteLine($"{LogTimeShowSceneLining.TotalTime}_{LogTimeShowSceneLining.OperationName} \n");
			Console.WriteLine($"Strart:{ShowSceneLiningIteration.StartTime}_Finish:{ShowSceneLiningIteration.StopTime}_execute{ShowSceneLiningIteration.TotalTime}_{ShowSceneLiningIteration.OperationName}_ {fpsCount} \n");
			//Общее время
			Console.WriteLine($"{LogTimeMethod.TotalTime}_{LogTimeMethod.OperationName} \n");
			Console.ReadKey();

		}
	}

}
