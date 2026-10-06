using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EncryptSingleChar();
        }

        static void EncryptSingleChar()
        {
            Console.WriteLine("--- 5. Шифрование символа (XOR) ---\n");

            Console.Write("Введите один символ: ");
            string charInput = Console.ReadLine();

            if (string.IsNullOrEmpty(charInput) || charInput.Length != 1)
            {
                Console.WriteLine("Ошибка: нужно ввести ровно один символ.\n");
                return;
            }

            char originalChar = charInput[0];
            int key = ReadInt("Секретный ключ (1–255): ");

            if (key < 1 || key > 255)
            {
                Console.WriteLine("Ошибка: ключ должен быть от 1 до 255.\n");
                return;
            }

            int originalCode = (int)originalChar;
            int encryptedCode = originalCode ^ key;
            char encryptedChar = (char)encryptedCode;

            int decryptedCode = encryptedCode ^ key;
            char decryptedChar = (char)decryptedCode;

            // Безопасный вывод: если символ непечатаемый, покажем его код явно
            string encryptedDisplay = char.IsControl(encryptedChar)
                ? $"<непечатаемый, код {encryptedCode}>"
                : $"'{encryptedChar}'";

            string decryptedDisplay = char.IsControl(decryptedChar)
                ? $"<непечатаемый, код {decryptedCode}>"
                : $"'{decryptedChar}'";

            Console.WriteLine($"Исходный символ:  '{originalChar}' (код {originalCode})");
            Console.WriteLine($"Зашифрованный:    {encryptedDisplay} (код {encryptedCode})");
            Console.WriteLine($"Расшифрованный:   {decryptedDisplay} (код {decryptedCode})");
            Console.WriteLine($"Совпадает с исходным: {originalChar == decryptedChar}\n");
        }

        #region Вспомогательные методы для безопасного ввода
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine()?.Trim(), out int value))
                    return value;
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }

        static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine()?.Trim(), out int value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное целое число.");
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine()?.Trim(), out double value))
                    return value;
                Console.WriteLine("Ошибка: введите число (например, 4.5).");
            }
        }

        static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine()?.Trim(), out double value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное число (например, 250.5).");
            }
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine()?.Trim(), out decimal value))
                    return value;
                Console.WriteLine("Ошибка: введите число (например, 10.5).");
            }
        }

        static decimal ReadPositiveDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine()?.Trim(), out decimal value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное число (например, 5000.00).");
            }
        }
        #endregion
    }
}
