using GamesStore.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Data.Memory
{
    public class GameMemoryData : IData<IGame>
    {
        private readonly List<IGame> _games;

        public GameMemoryData()
        {
            _games = new List<IGame>();
        }

        public IEnumerable<IGame> ReadAll()
        { 
            return _games;
        }

        public void Add(IGame item)
        {
            _games.Add(item);
        }

        public void Remove(IGame item)
        {
            _games.Remove(item);
        }
    }
}
