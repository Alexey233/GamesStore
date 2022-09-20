using GamesStore.DI;

namespace GamesStore.Data.Memory
{
    public class CheckMemoryData : IData<ICheck>
    {
        private readonly List<ICheck> _check;

        public CheckMemoryData()
        {
            _check = new List<ICheck>();
        }
        public void Add(ICheck item)
        {
            _check.Add(item);
        }

        public IEnumerable<ICheck> ReadAll()
        {
            return _check;
        }

        public void Remove(ICheck item)
        {
            _check.Remove(item);
        }
    }
}
