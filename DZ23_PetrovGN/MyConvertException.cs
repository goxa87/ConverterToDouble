using System;
using System.Collections.Generic;
using System.Text;

namespace DZ23_PetrovGN
{
    public enum ErrorCode 
    { 
        EmptyString = 11,
        IncorrectSymbol = 21,
        MoreThanOneSeparator = 31,
        IncorrectFormat = 32,
        Overflow =41
    }

    public class MyConvertException : Exception
    {
        public ErrorCode _code{ get;}
        public string MyMessage { get; }
        public MyConvertException(string message, ErrorCode code)
        {
            _code = code;
            MyMessage = $"Ошибка:  {_code}:{(int)_code} - {message}";
        }

    }
}
