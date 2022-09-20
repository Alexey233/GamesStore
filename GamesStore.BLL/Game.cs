using GamesStore.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.BLL
{
    public class Game : IGame
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
    }
}
