using System;
using System.Linq;

namespace UCP
{
    class classCrypto
    {
        public string[] arrayRUS = new string[] { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" }; //Алфавит Русский
        public string[] array2RUS; //Доп массив Русский
        public string[] arrayENG = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; //Алфавит Английский
        public string[] array2ENG; //Доп массив Английский
        public string[] arrayDIG = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };//Цифры
        public string[] array2DIG; //Доп массив Цифры
        public string[] arraySYMn = new string[] { "!",  "@", "#", "$", "%", "^",  "&", "*", "(", ")", "<", "`", "{", "}", "-" }; //Символы 1
        public string[] arraySYMd = new string[] { "\"", "№", ";", ":", "?", "\\", "/", "|", ".", ",", ">", "~", "]", "[", "+" }; //Символы 2

        public string caesarusEncrypt(string text, int move)
        {
            bool isSpace = false; //Индекатор пробела
            string endText = ""; //Конечная строка

            array2RUS = arrayRUS.Skip(move).Concat(arrayRUS.Take(move)).ToArray(); //Смещение массивов
            array2ENG = arrayENG.Skip(move).Concat(arrayENG.Take(move)).ToArray();
            array2DIG = arrayDIG.Skip(move).Concat(arrayDIG.Take(move)).ToArray();

            foreach (char bykva in text)
            {
                isSpace = false;

                for (int i = 0; i < arrayRUS.Length; i++) //Проверка русского алфавита
                {
                    isSpace = false;

                    if (bykva.ToString().ToLower() == arrayRUS[i])
                    {
                        endText += array2RUS[i];
                        break;
                    }
                    else if (bykva.ToString().ToLower() == " " & !isSpace) //Проверка пробела
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }

                for (int i = 0; i < arrayENG.Length; i++) //Проверка английского алфавита
                {
                    if (bykva.ToString().ToLower() == arrayENG[i])
                    {
                        endText += array2ENG[i];
                        break;
                    }
                    else if (bykva.ToString().ToLower() == " " & !isSpace) //Проверка пробела
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }

                for (int i = 0; i < array2DIG.Length; i++) //Проверка цифр
                {
                    if (bykva.ToString() == arrayDIG[i])
                    {
                        endText += array2DIG[i];
                        break;
                    }
                    else if (bykva.ToString() == " " & !isSpace) //Проверка пробела
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }

                for (int i = 0; i < 15; i++) //Замена символов
                {
                    if (bykva.ToString() == arraySYMn[i])
                    {
                        endText += arraySYMd[i];
                        break;
                    }
                    else if (bykva.ToString() == arraySYMd[i])
                    {
                        endText += arraySYMn[i];
                        break;
                    }
                    else if (bykva.ToString() == " " & !isSpace) //Проверка пробела
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }
            }

            return endText;
        }

        public string caesarusDecode(string text, int move)
        {
            bool isSpace = false;
            string endText = "";
            move *= -1;

            array2RUS = arrayRUS.Skip(move + 33).Concat(arrayRUS.Take(move + 33)).ToArray(); //Измененные смещения массивов
            array2ENG = arrayENG.Skip(move + 26).Concat(arrayENG.Take(move + 26)).ToArray();
            array2DIG = arrayDIG.Skip(move + 10).Concat(arrayDIG.Take(move + 10)).ToArray();

            foreach (char bykva in text)
            {
                isSpace = false;

                for (int i = 0; i < arrayRUS.Length; i++)
                {
                    isSpace = false;

                    if (bykva.ToString().ToLower() == arrayRUS[i])
                    {
                        endText += array2RUS[i];
                        break;
                    }
                    else if (bykva.ToString().ToLower() == " " & !isSpace)
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }

                for (int i = 0; i < arrayENG.Length; i++)
                {
                    if (bykva.ToString().ToLower() == arrayENG[i])
                    {
                        endText += array2ENG[i];
                        break;
                    }
                    else if (bykva.ToString().ToLower() == " " & !isSpace)
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }

                for (int i = 0; i < arrayDIG.Length; i++)
                {
                    if (bykva.ToString() == arrayDIG[i])
                    {
                        endText += array2DIG[i];
                        break;
                    }
                    else if (bykva.ToString() == " " & !isSpace)
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }

                for (int i = 0; i < 15; i++)
                {
                    if (bykva.ToString() == arraySYMn[i])
                    {
                        endText += arraySYMd[i];
                        break;
                    }
                    else if (bykva.ToString() == arraySYMd[i])
                    {
                        endText += arraySYMn[i];
                        break;
                    }
                    else if (bykva.ToString() == " " & !isSpace)
                    {
                        endText += " ";
                        isSpace = true;
                        break;
                    }
                }
            }

            return endText;
        }
    }
}
