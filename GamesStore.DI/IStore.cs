using System;

namespace GamesStore.DI
{
    public interface IStore
    {
        string Name { get; set; }
        string Url { get; set; }

        void Add(IGame game);
        IEnumerable<IGame> GetAllGames();
        ICheck Sell(IGame game);
        
    }
}
