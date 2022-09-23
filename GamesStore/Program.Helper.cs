using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Cmd
{
    partial class Program
    {
        private static string ReadNotEmptyLine(string command)
        {
            while (true)
            {
                Console.WriteLine($"Введите {command}");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(command))
                {
                    return input;
                }

                WriteErrorMessage($"Значение {command} не должно быть пустым");
            }

        }

        private static int ReadIntLine(string command)
        {
            while (true)
            {
                var input = ReadNotEmptyLine(command);

                if (int.TryParse(input, out int res))
                {
                    return res;
                }

                WriteErrorMessage("Введите целое число");
            }
        }
        
        private static HelpEnums ReadCommand()
        {
            while (true)
            {
                var input = ReadNotEmptyLine("команду");
                if (Enum.TryParse(input, out HelpEnums result))
                {
                    return result;
                }
                WriteErrorMessage("Неизвестная комманд. Введите help для подсказки");
            }
        }

        private static void WriteErrorMessage(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        private static void HelpMessage()
        {
            Console.WriteLine($"{HelpEnums.addGame} - Добавить игру");
            Console.WriteLine($"{HelpEnums.getAllGames} - Вывести все игры");
            Console.WriteLine($"{HelpEnums.sellGame} - Удалить игру");
            Console.WriteLine($"{HelpEnums.exit} - Выйти из приложения");
            Console.WriteLine($"{HelpEnums.help} - Помощь");
        }
    }
}
