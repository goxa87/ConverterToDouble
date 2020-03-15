using System;
using System.Collections.Generic;
using System.Text;

namespace DZ23_PetrovGN.Interfaces
{
    /// <summary>
    /// Представление бизнес логики предобразования строки в число.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Метод непосредственного преобразования.
        /// </summary>
        /// <param name="input">Входящая строка для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public double ConvertToDouble(string input);
    }
}
