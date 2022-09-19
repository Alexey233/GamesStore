using System;

namespace GamesStore.DI
{
    public interface IGame
    {
        string Name { get; set; }
        string Description { get; set; }
        string Company { get; set; }
        int Price { get; set; }
        int Size { get; set; }

    }
}
