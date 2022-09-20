using GamesStore.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.BLL
{
    public class Check : ICheck
    {
        public Check(IStore store, IGame game)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
            Game = game ?? throw new ArgumentNullException(nameof(game));

            DateTime = DateTime.Now;
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
        public IGame Game { get; set; }
        public IStore Store { get; set; }
        public DateTime DateTime { get; set; }
    }
}
