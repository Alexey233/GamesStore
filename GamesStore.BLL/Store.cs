using System;
using GamesStore.DI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection.Metadata;

namespace GamesStore.BLL
{
    public class Store : IStore
    {
        private readonly IData<ICheck> _checkData;
        private readonly IData<IGame> _gameData;
        public Store(IData<ICheck> check, IData<IGame> game)
        {
            _checkData = check ?? throw new ArgumentNullException(nameof(_checkData));
            _gameData = game ?? throw new ArgumentNullException(nameof(_gameData)); ;
        }

        public string Name { get; set; }
        public string Url { get; set; }

        public void Add(IGame game)
        {
            _gameData.Add(game);
        }

        public IEnumerable<IGame> GetAllGames()
        {
            return _gameData.ReadAll();
        }

        public ICheck Sell(IGame game)
        {
            _gameData.Remove(game);

            var check = new Check()
            {
                Game = game,
                Store = this,
                DateTime = DateTime.Now
            };
            _checkData.Add(check);
            return check;
        }
    }
}
