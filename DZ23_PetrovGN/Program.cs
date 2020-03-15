using DZ23_PetrovGN.Logic;
using DZ23_PetrovGN.Viewer;
using DZ23_PetrovGN.WiddleWare;
using System;

namespace DZ23_PetrovGN
{
    /// <summary>
    /// Пусть класс Program будет выполнять функцию view.
    /// </summary>
    class Program
    {
        

        static void Main(string[] args)
        {
            ConsoleViewer viewer = new ConsoleViewer();
            while (true)
            {
                viewer.SetNewValue();
                viewer.GetDoubleRezult();
            }
        }
    }
}
