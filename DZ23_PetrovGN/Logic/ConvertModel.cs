using DZ23_PetrovGN.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ23_PetrovGN.Logic
{
    /// <summary>
    /// Модель преобразования строки в double.
    /// </summary>
    public class ConvertModel : IModel
    {
        // Разрешенные символы.
        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',','-' };
        // Сепаратор.
        char separator = ',';

        /// <summary>
        /// Преобразование строки в double.
        /// </summary>
        /// <param name="input">Входящая строка для преобразования.</param>
        /// <returns>Представление в виде double.</returns>
        public double ConvertToDouble(string input)
        {
            // Проверка на пустую строку или Null.
            if (string.IsNullOrWhiteSpace(input)) throw new MyConvertException("Строка пуста", ErrorCode.EmptyString);
            // Проверка на наличие запрещенных символов (разделитель , ).
            if (CheckLetters(input)) throw new MyConvertException("Нашлись какие-то запрещенные сиволы", ErrorCode.IncorrectSymbol);
            // Проверка на наличие более чем 1 сепаратора.
            if (CheckSeparator(input)) throw new MyConvertException("В строке нашлось больше 1 сепаратора", ErrorCode.MoreThanOneSeparator);
            // Проерка на формат. 1й или последний не должны быть сепараторами.
            if (CheckFormat(input)) throw new MyConvertException("Cепаратор не должен стоять на 1 или последнем месте", ErrorCode.IncorrectFormat);
            // Проверка на наличие минуса внутри строки.
            if (MinusInside(input)) throw new MyConvertException("Строка содержит знак - не на первом месте", ErrorCode.IncorrectFormat);
            return GetDouble(input);
        }
        /// <summary>
        /// Проверяет строку на вхождения букв или символов .
        /// </summary>
        /// <param name="input">Строка проверки.</param>
        /// <returns>False если строка не содержит запрещенных символов.</returns>
        bool CheckLetters(string input)
        {
            // Количество совпадений с массивом разрешенных символов.
            int Count;
            for (int i = 0; i < input.Length; i++)
            {
                // обнуляем для каждого элемента исходной строки.
                Count = 0;
                for (int num = 0; num < numbers.Length; num++)
                {
                    if (input[i] == numbers[num])
                    {
                        Count++;
                    }
                }
                // Если совпадений не было, значит это посторонний символ.
                if (Count == 0) return true;
            }
            return false;
        }
        /// <summary>
        /// Проверк на количество сепараторов.
        /// </summary>
        /// <param name="input">Строка проверки.</param>
        /// <returns>true - если содержит больше 1 сепаратора.</returns>
        bool CheckSeparator(string input)
        {
            int сount = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == separator) сount++;
            }
            // Если сепараторов больше 1, то ...
            if (сount > 1) return true;
            else return false;
        }

        /// <summary>
        /// Проверяет формат(1й или последний символ не должен быть сепаратором).
        /// </summary>
        /// <param name="input">Строка проверки/</param>
        /// <returns>True если есть ошибка/</returns>
        bool CheckFormat(string input)
        {
            if (input[0] == separator || input[input.Length - 1] == separator || (input[0]=='-' && input[1]==separator)) return true;
            else return false;
        }

        /// <summary>
        /// Вычисляет значение double.
        /// </summary>
        /// <param name="input">Cтрока для перевода</param>
        /// <returns>результат преобразования</returns>
        double GetDouble(string input)
        {
            try
            {
                double rezult = 0;
                // Множитель итерации порядка цикла
                // +1 т.к. вначале идут числа со степенью 10 больше 0.
                double factor = 1;
                // Оповещает False - значение в целой части; true - значение в дробной части.
                bool afterPoint = false;
                for (int i = 0; i < input.Length; i++) 
                {
                    // Пропускаем, если это знак минус.
                    if (input[i] == '-') continue;

                    // Если доходим до сепаратора, то логика вычислений меняется.
                    if (input[i] == separator)
                    {
                        afterPoint = true;
                        // становиться делителем
                        factor = 10;
                        continue;
                    }

                    if (!afterPoint)
                    {
                        // Знаки до запятой.
                        // 10 т.к. десятичная система счисления.
                        rezult *= 10;
                        rezult += GetInt(input[i]);
                    }
                    else
                    {
                        // Знаки после запятой.
                        // Вычисляемчислитель на основе введеного  числа, а значенатель - это степенб 10ки которая представляет factor. 
                        rezult += (GetInt(input[i]) / factor);
                        factor *= 10;
                    }                    
                }

                if (input[0] == '-') return -rezult;
                return rezult;
            }
            catch(OverflowException)
            {
                throw new MyConvertException("Произошло переполнение", ErrorCode.Overflow);
            }
        }

        /// <summary>
        /// Проверяет наличие знака минус не на 1 месте.
        /// </summary>
        /// <param name="input">Строка для проверки.</param>
        /// <returns>True - если зайдено значение внутир строки.</returns>
        bool MinusInside(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '-') return true;
            }
            return false;
        }

        /// <summary>
        /// Получает десятичное число из символа.
        /// </summary>
        /// <param name="ch">Символ.</param>
        /// <returns>Цифровое представление.</returns>
        int GetInt(char ch)
        {
            int rezult;
            switch (ch)
            {
                case '0':
                    {
                        rezult = 0;
                        break;
                    }

                case '1':
                    {
                        rezult = 1;
                        break;
                    }

                case '2':
                    {
                        rezult = 2;
                        break;
                    }

                case '3':
                    {
                        rezult = 3;
                        break;
                    }

                case '4':
                    {
                        rezult = 4;
                        break;
                    }

                case '5':
                    {
                        rezult = 5;
                        break;
                    }

                case '6':
                    {
                        rezult = 6;
                        break;
                    }

                case '7':
                    {
                        rezult = 7;
                        break;
                    }

                case '8':
                    {
                        rezult = 8;
                        break;
                    }

                case '9':
                    {
                        rezult = 9;
                        break;
                    }
                default:
                    {
                        throw new MyConvertException("Некорректный символ", ErrorCode.IncorrectSymbol);
                    }
            }
            return rezult;
        }

    }
}
