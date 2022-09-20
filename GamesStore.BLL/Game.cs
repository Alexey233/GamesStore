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
        public Game(string name, string description, string company, int price, int size)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrWhiteSpace(company)) throw new ArgumentNullException(nameof(company));
            if (price < 0) throw new ArgumentNullException(nameof(price));
            if (size < 0) throw new ArgumentNullException(nameof(size));

            Name = name;
            Description = description;
            Company = company;
            Price = price;
            Size = size;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
    }
}
