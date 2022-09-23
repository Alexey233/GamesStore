using GamesStore.DI;
using GamesStore.Settings;
using System.Net;
using System.Text;

namespace GamesStore.Cmd
{
    partial class Program
    {
        private static Configuration _configuration;

        private static IGame CreateGame(string name, string company, string description, int price, int size)
        {
            var game = _configuration.Container.GetInstance<IGame>();
            game.Name = name;
            game.Company = company;
            game.Description = description;
            game.Price = price;
            game.Size = size;

            var store = _configuration.Container.GetInstance<IStore>();
            store.Add(game);


            return game;
        }

        private static ICheck CreateCheck(IGame game)
        {
            var store = _configuration.Container.GetInstance<IStore>();
            var check = store.Sell(game);

            return check;
        }

        private static IStore CreateStore(string name, string url)
        {
            var store = _configuration.Container.GetInstance<IStore>();
            store.Name = name;
            store.Url = url;

            return store;
        }

        private static IEnumerable<IGame> GetAllGames()
        {
            var store = _configuration.Container.GetInstance<IStore>();
            var books = store.GetAllGames();

            return books;
        }

        static void Main(string[] args)
        {
            try
            {
                _configuration = new Configuration();

                var store = CreateStore("Steam", "steam.com");

                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Добрый день. Добро пожаловать в панель управления магазином");
                Console.WriteLine("Пожалуйста, введите нужную команду или help для помощи");
                Console.WriteLine();

                while (true)
                {
                    switch (ReadCommand())
                    {
                        case HelpEnums.exit:
                            Environment.Exit(0);
                            break;
                        case HelpEnums.help:
                            HelpMessage();
                            break;
                        case HelpEnums.addGame:
                            AddGame();
                            break;
                        case HelpEnums.getAllGames:
                            ShowAllGames();
                            break;
                        case HelpEnums.sellGame:
                            SellGame();
                            break;
                        default:
                            WriteErrorMessage("Не обрабатываемая команда. Свяжитесь с разработчиком");
                            break;
                    }
                }
            }


            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }


        private static IGame AddGame()
        {
            Console.WriteLine("Добавляем новую игру в магазин");
           
            while (true)
            {
                var name = ReadNotEmptyLine("название игры");
                var description = ReadNotEmptyLine("описание игры");
                var company = ReadNotEmptyLine("компания, которая разработала");
                var price = ReadIntLine("цена игры");
                var size = ReadIntLine("размер игры в гб");

                var game = CreateGame(name, description, company, price, size);


                if (game != null)
                {
                    Console.WriteLine("Игра успешно добавлена");
                    Console.WriteLine();
                    return game;
                }
            }
            

            throw new Exception("Ошибка при добавлении игры");
        }

        

        private static void ShowAllGames()
        {
            Console.WriteLine("Список всех доступных в магазине игр:");

            var games = GetAllGames();
            foreach (var game in games)
            {
                Console.WriteLine($"\t{game.Name}");
            }
            Console.WriteLine();
        }
        private static void SellGame()
        {
            Console.WriteLine("Продажа игры");

            IGame game;
            while (true)
            {
                var name = ReadNotEmptyLine("название игры");
                var games = GetAllGames();
                var result = games.FirstOrDefault(b => b.Name.Equals(name));

                if (result != null)
                {
                    game = result;
                    break;
                }

                WriteErrorMessage("Данная игра не найдена");
            }

            var check = CreateCheck(game);
            Console.WriteLine($"Новая продажа в магазине {check.Store.Name}");
            Console.WriteLine($"по адресу {check.Store.Url}");
            Console.WriteLine($"{check.DateTime}");
            Console.WriteLine($"Наименование товара: {check.Game.Name}");
            Console.WriteLine($"Стоимость: {check.Game.Price}₽");
            Console.WriteLine();
        }
    }
}