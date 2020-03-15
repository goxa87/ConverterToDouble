using System;
using System.Collections.Generic;
using System.Text;

namespace DZ23_PetrovGN
{
    /// <summary>
    /// Коды и статусы ошибок.
    /// </summary>
    public enum ErrorCode 
    { 
        EmptyString = 11,
        IncorrectSymbol = 21,
        MoreThanOneSeparator = 31,
        IncorrectFormat = 32,
        Overflow =41
    }
    /// <summary>
    /// Мое кастомное исключение.
    /// </summary>
    public class MyConvertException : Exception
    {
        /// <summary>
        /// код ошибки
        /// </summary>
        public ErrorCode _code{ get;}
        /// <summary>
        /// Настраиваемое сообщение.
        /// </summary>
        public string MyMessage { get; }
        /// <summary>
        /// Инициализация ошибки.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="code">Статус код.</param>
        public MyConvertException(string message, ErrorCode code)
        {
            _code = code;
            MyMessage = $"Ошибка:  {_code}:{(int)_code} - {message}";
        }

    }
}
