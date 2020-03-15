using DZ23_PetrovGN.WiddleWare;
using System;
using System.Collections.Generic;
using System.Text;


namespace DZ23_PetrovGN
{
    /// <summary>
    /// Описывает предаставление.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Презентер связывающий логику и представление.
        /// </summary>
        Presenter _presenter { get; set; }
        /// <summary>
        /// Входящее значение.
        /// </summary>
        string InputValue { get; set; }
        /// <summary>
        /// Результат преобразований.
        /// </summary>
        double? OutputValue { get; set; }
    }
}
