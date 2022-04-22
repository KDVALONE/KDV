using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeaturesLibTest;

namespace StartConsoleTest
{	/// <summary>
	/// Проект для старта консолек и отладки. 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			TestsReposytory testsRepo = new TestsReposytory();
			testsRepo.StartConsoleCustomFont();
			
		}
	}
	public class TestsReposytory {

		SceneWindowUpdatingStressTest sceneUpd = new SceneWindowUpdatingStressTest();
		ConsoleCustomColor consCustomClr = new ConsoleCustomColor();
		ConsoleCustomSize consCustomSize = new ConsoleCustomSize();
		SceneWindowUpdatingColorizedStressTest sceneUpdClrFast = new SceneWindowUpdatingColorizedStressTest();
		ConsoleFontCustomSize consoleFontCustomSize = new ConsoleFontCustomSize();


		
		public void StartShowSceneArray(int raw = 60, int column = 120, int changescount = 60 ,int sleepMSecond = 16) {
		
			sceneUpd.ShowSceneArray(raw,column, changescount,sleepMSecond);
			Console.ReadKey();
		}
		public void StartShowSceneArrayFast(int raw = 60, int column = 120, int changescount = 60, int sleepMSecond = 16)
		{
			sceneUpd.FastShowSceneArray(raw, column, changescount, sleepMSecond);
			Console.ReadKey();
		}


		public void StartShowTextCustomColor(int colorNumber = 0)
		{

			consCustomClr.ShowTextCustomColor(colorNumber);
			Console.ReadKey();
		}

		public void StartColorizedArray(int raw = 60, int column = 120)
		{
			sceneUpd.ColorizedScene(raw, column);
			Console.ReadKey();
		}

		//Тут будет подбираться наиболее быстрая отрисовка в цвете сцены
		public void StartColorizeSceneVariant()
		{
			sceneUpdClrFast.ColorizeEqualsVariant();
			Console.ReadKey();
		}

		public void StartConsoleCustomSize()
		{
			consCustomSize.ChaingeConsoleSizeSample();
			Console.ReadKey();
		}

		public void StartConsoleCustomFont()
		{
			consoleFontCustomSize.ShowCustomFont();
			Console.ReadKey();
		}
	}
}
