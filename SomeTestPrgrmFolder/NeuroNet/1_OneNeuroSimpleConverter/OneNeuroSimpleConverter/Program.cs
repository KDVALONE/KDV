using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNeuroSimpleConverter
{
	/// <summary>
	/// Программа с одним искусственным нейроном 
	/// Нейрон обучаеся конвертировать мили в километры, а также конвертировать валюты по курсу.
	/// Ссылка на ролик https://www.youtube.com/watch?v=k4FkXs-J3VM&feature=youtu.be
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			Neuro neuron = new Neuro();

			decimal km = 100;
			decimal expectedMiles = 62.1371m;


			//Обучение нейрона
			int i = 0;
			do
			{
				i++;

				neuron.Training(km, expectedMiles);
				
				Console.WriteLine($"Iteration: {i} | Result error: {neuron.LastError}");

			}
			while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

			Console.WriteLine($"Training:  Success! ");

			Console.WriteLine($"Input km: {km} | Output miles: {Math.Round(neuron.ProcessInputData(km), 4)} | {expectedMiles} Expected miles");
			Console.ReadKey();
		 
		}
	}

	/// <summary> Нейрон, с комментариями </summary>
	public class Neuro
	{
		// Вес для нейрона, decimal так как нужна достаточная точность в числах с плавающей точкой.
		// Вообще первичные веса, обычно, носят примерное значение, и уточняются в процессе обучения нейрона
		public decimal Weight = 0.5m;

		//Свойство для обучени нейрона, в ктором хранится последннее неудачное занчение нейрона
		public decimal LastError { get; private set; }

		// Для коррекции, так как без такого "сглаживания" шаг коррекиции будет слишком большой
		// чем выше сглаживание тем точнее но дольше будет обучатсья нейрон 
		public decimal Smoothing = 0.00001m; //0.01m быстрее но меннее точно чем 0.00001m;

		public decimal ProcessInputData(decimal input)
		{
			return input * Weight;
		}

		public decimal RestoreInputData(decimal output)
		{ 
			return output / Weight;
 		}
		/// <summary>  Метод для обучения нейрона. 
		/// param name="input" - входящий результат.
		/// param name="expectedResult" - правильный результат </summary>
		public void Training(decimal input, decimal expectedResult) 
		{
			var actualResult = input * Weight;

			//теперь зная ошибку, мы вычсляем значение корректировки нашего нейрона
			//1. Записываем разницу ождаемого и актуального результата
			LastError = expectedResult - actualResult;

			//2. Получаем знаечение корректировки
			var correction = (LastError / actualResult) * Smoothing;
			
			//3. теперь непосредственно корректируем наш вес
			Weight += correction;
		}
	}

	/// <summary> Тот же нейрон, только без комментариев, для наглядности </summary>
	public class NeuroCleane
	{		
		public decimal Weight = 0.5m;	
		public decimal LastError { get; private set; }
		public decimal Smoothing = 0.00001m; 

		public decimal ProcessInputData(decimal input)
		{
			return input * Weight;
		}

		public decimal RestoreInputData(decimal output)
		{
			return output / Weight;
		}
		
		public void Training(decimal input, decimal expectedResult)
		{
			var actualResult = input * Weight;			
			LastError = expectedResult - actualResult;

			var correction = (LastError / actualResult) * Smoothing;
			Weight += correction;
		}
	}
}
