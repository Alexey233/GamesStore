using GamesStore.DI;
using GamesStore.BLL;
using GamesStore.Data.Memory;
using System.Text;

namespace GamesStore.Cmd
{
    partial class Program
    {
        private static IGame CreateGame(string name, string company, string description, int price, int size)
        {
            var game = new Game(name, description, company, price, size);
            return game;
        }

        private static ICheck CreateCheck(IStore store, IGame game)
        {
            var check = new Check(store, game);
            return check;
        }

        private static IStore CreateStore(string name, string url)
        {
            var gameData = new GameMemoryData();
            var checkData = new CheckMemoryData();

            var shop = new Store(name, url, checkData, gameData);

            return shop;
        }



        static void Main(string[] args)
        {
            try
            {
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
                            AddGame(store);
                            break;
                        case HelpEnums.getAllGames:
                            ShowAllGames(store);
                            break;
                        case HelpEnums.sellGame:
                            SellGame(store);
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


        private static IGame AddGame(IStore store)
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
                    store.Add(game);
                    Console.WriteLine("Игра успешно добавлена");
                    Console.WriteLine();
                    return game;
                }
            }
            

            throw new Exception("Ошибка при добавлении игры");
        }

        

        private static void ShowAllGames(IStore store)
        {
            Console.WriteLine("Список всех доступных в магазине игр:");

            var games = store.GetAllGames();
            foreach (var game in games)
            {
                Console.WriteLine($"\t{game.Name}");
            }
            Console.WriteLine();
        }
        private static void SellGame(IStore store)
        {
            Console.WriteLine("Продажа игры");

            IGame game;
            while (true)
            {
                var name = ReadNotEmptyLine("название игры");
                var games = store.GetAllGames();
                var result = games.FirstOrDefault(b => b.Name.Equals(name));

                if (result != null)
                {
                    game = result;
                    break;
                }

                WriteErrorMessage("Данная игра не найдена");
            }

            var check = CreateCheck(store, game);
            check.Print();
            Console.WriteLine();
        }
    }
}