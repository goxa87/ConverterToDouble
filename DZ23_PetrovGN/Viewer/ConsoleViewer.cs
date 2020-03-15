using DZ23_PetrovGN.Logic;
using DZ23_PetrovGN.WiddleWare;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ23_PetrovGN.Viewer
{
    public class ConsoleViewer : IView
    {
        /// <summary>
        /// Презентер.
        /// </summary>
        public Presenter _presenter { get; set; }

        string inputValue;
        /// <summary>
        /// Входящее значение.
        /// </summary>
        public string InputValue
        {
            get
            {
                return inputValue;
            } 
            set
            {
                inputValue = value;
                _presenter.DoWork(value);                
            }
        }
        /// <summary>
        /// Результат преобразования ытроки в double.
        /// </summary>
        public double? OutputValue { get; set; }

        /// <summary>
        /// инициализация нового представления
        /// </summary>
        public ConsoleViewer()
        {
            // Добавляем презентер и заполняем в этом случае объектом консольного вывода(_view).
            _presenter = new Presenter(new ConvertModel(), this);
        }

        public void SetNewValue()
        {
            try
            {
                Console.WriteLine("Введите строку для преобразования в тип DOUBLE:");
                InputValue = Console.ReadLine();
            }
            catch (MyConvertException ex)
            {
                Console.WriteLine(ex.MyMessage);
            }
        }

        public void GetDoubleRezult()
        {
            if(OutputValue.HasValue==true) Console.WriteLine($"\nРезультат преобразования: {OutputValue}\n");
            else Console.WriteLine($"\nНе удалось выполнить преобразование строки: {InputValue}\n");
            OutputValue = null;
        }
    }
}
