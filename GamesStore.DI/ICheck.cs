using System;

namespace GamesStore.DI
{
    public interface ICheck
    {
        IGame Game { get; set; }
        IStore Store { get; set; }
        DateTime DateTime { get; set; }

        void Print();
    }
}
