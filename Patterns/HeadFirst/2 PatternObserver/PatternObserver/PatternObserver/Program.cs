using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{/// <summary>
/// Написать программу применяя паттерн Издатель - подписчик
/// Задача: написать программу которая получает данные опогоде (температура, влажность, давление)
/// в специальном классе WetherData, и сделать возможным вывод на трех дисплеях в разной форме ()
/// (текущие данные, статистика, прогноз), так же сделать возможным добавление новых форм дисплеев
/// </summary>
    class WeatherStation
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentCounditionsDisplay currentDisplay = new CurrentCounditionsDisplay(weatherData);
            #region другие дисплеи не имеют реализации, так как очень похоже
            //  StatisticDisplay statisticDisplay = new StatisticDisplay(weatherData);
            //  ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            #endregion

            weatherData.setMeasurements(80, 60, 30.4f);//}
            weatherData.setMeasurements(82, 70, 29.2f);//}}  имитация показателей
            weatherData.setMeasurements(78, 90, 29.2f);//}

            Console.ReadKey();
        }
    }

    class WeatherData : Subject  
    {/// <summary>
     /// WeatherData - отслеживает погодные условия
     /// </summary>

        private ArrayList observers; // необобщенный контейнер, для хранения наблюдателей
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new ArrayList();
        }

        public void registerObserver(Observer o) // доваление наблюдателей. FILO.
        {
            observers.Add(o);
        }
        public void removeObserver(Observer o) // удаление наблюдателей. 
        {
            int i = observers.IndexOf(o);
            if (i >= 0) { observers.Remove(i); }
         
        }
        public void notifyObservers()// обновляет изображение для трех элементов: текущего состояния, статистики, прогноза
        {
            for (int i = 0; i < observers.Count; i++)
            {
                Observer observer = (Observer)observers[i];
                observer.Update(temperature, humidity, pressure);
            }
        }

        void getTemperature() { }
        void getHumidity() { }// влажность
        void getPreassure() { } // атмосферное давление

        void measurementsChanged() // оповещение наблюдателей
        {
            notifyObservers();
        }

        /// <summary>
        /// метод который задает значение метоеданных. (симулирует получение значений.)
        /// </summary>
        public void setMeasurements(float temperature, float humidity, float pressure) 
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
         }


        
    }

   public interface Subject   // субьект (издатель)
    {
        void registerObserver(Observer o); // регистрация наблюдателя
        void removeObserver(Observer o);  // рисключение наблюдателя
        void notifyObservers(); // метод вызывается для оповещения наблюдателей об изменениях
    }
    /// <summary>
    /// все погодные еффекты реализуют интрефейс Observer, с этим интерфейсом
    /// взаимодействует субьект, когда приходит время обновления подписчиков
    /// </summary>
    public interface Observer   // Наблюдатль,(подписчик) - должен реализоваться всеми подписчиками
    {
        void Update(float temp,float humidity,float pressure); // параметры передаваемые наблюдателям при изменении состояни
    }

    public interface DisplayElements
    {/// <summary>
     /// реализуется всеми визуальными элементами, служит для отображения значений
     /// </summary>
      void Display();
    }

    /// <summary>
    /// Класс вычисляет и выводит минимальное среднее и максимальное значение
    /// </summary>
    class StatisticDisplay : Observer, DisplayElements
    {
        public void Display() // вывод статистики
        {

        }
        public void Update(float temp, float humidity, float pressure)
        {

        }

    }
    /// <summary>
    /// класс выводит прогноз погоды по показаниям барометра
    /// </summary>
    class ForecastDisplay : Observer, DisplayElements
    {
        public void Display() // вывод прогноза
        {
        }
        public void Update(float temp, float humidity, float pressure)
        {

        }
    }

    /// <summary>
    /// Разработчики реализуют интерфейсы Observer и Display для создания своих визуальных отчетов
    /// </summary>
    class ThirdPartyDisplay : Observer, DisplayElements // делает стороння команда, что то выводит на основании  полученных данных
    {
        public void Display()
        {
        }
        public void Update(float temp, float humidity, float pressure)
        {

        }
    }
    /// <summary>
    /// выводит текущие значения переменных обьекта WetherData
    /// класс подписчик на WetherData
    /// </summary>
    public class CurrentCounditionsDisplay : Observer, DisplayElements 
    {

        private float temperature;
        private float humidity;
        private Subject weatherData; // потребуется в случае отмены регистрации на событие
        public CurrentCounditionsDisplay(Subject weatherData) // конструктор передает елемент wetherData который исп. в качестве наблюдателя
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        public void Display() { Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity"); }// вывод текущих параметров
        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
    }
    }

    


}
