using DZ23_PetrovGN.Interfaces;
using DZ23_PetrovGN.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ23_PetrovGN.WiddleWare
{
    /// <summary>
    /// Презентер для связи представления и логики.
    /// </summary>
    public class Presenter
    {
        /// <summary>
        /// Представление.
        /// </summary>
        public IView _view { get; set; }
        // Используем внедрение зависимостей для имплементации логики преобразования строки в double.
        /// <summary>
        /// Модель бизнес логики.
        /// </summary>
        public IModel _model { get; private set; }

        public Presenter(IModel model, IView view)
        {
            _model = model;
            _view = view;
        }

        /// <summary>
        /// Метод вызова логики для входящих данных.
        /// </summary>
        /// <param name="input">Строка для преобразования.</param>
        public void DoWork(string input)
        {
            _view.OutputValue = _model.ConvertToDouble(input);
        }
    }
}
