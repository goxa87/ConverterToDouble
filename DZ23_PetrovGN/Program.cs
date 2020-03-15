using DZ23_PetrovGN.Logic;
using DZ23_PetrovGN.Viewer;
using DZ23_PetrovGN.WiddleWare;
using System;

namespace DZ23_PetrovGN
{
    class Program
    {       
        static void Main(string[] args)
        {
            // Класс реализующий IView.
            ConsoleViewer viewer = new ConsoleViewer();
            while (true)
            {
                // Получение чтроки.
                viewer.SetNewValue();
                // Вывод результатов.
                viewer.GetDoubleRezult();
            }
        }
    }
}
