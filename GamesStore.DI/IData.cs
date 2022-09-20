using System;


namespace GamesStore.DI
{
    public interface IData<T>
    {
        IEnumerable<T> ReadAll();

        void Add(T item);
        void Remove(T item);
    }
}
