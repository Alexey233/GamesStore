using GamesStore.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Data.Sql
{
    public class GameEntity : IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }

        public GameEntity() { }

        public GameEntity(IGame item)
        {
            Id = 0;
            Name = item.Name;
            Company = item.Company;
            Price = item.Price;
            Size = item.Size;
            Description = item.Description;
        }
    }
}
