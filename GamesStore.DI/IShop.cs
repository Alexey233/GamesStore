using System;

namespace GamesStore.DI
{
    public interface IShop
    {
        string Name { get; set; }
        string Url { get; set; }

        void Add(IGame game);
        IEnumerable<IGame> GetAllGames();
        void Sell(IGame game);
        
    }
}
