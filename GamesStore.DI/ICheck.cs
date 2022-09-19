using System;

namespace GamesStore.DI
{
    public interface ICheck
    {
        IGame Game { get; set; }
        IShop Shop { get; set; }

        DateTime DateTime { get; set; }
    }
}
