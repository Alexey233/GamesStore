using GamesStore.DI;

namespace GamesStore.Data.Sql
{
    public class CheckSqlData : IData<ICheck>
    {
        public void Add(ICheck item)
        {
            using (var db = new GameStoreContext())
            {
                var check = new CheckEntity(item);
                db.Checks.Add(check);
                db.SaveChanges();
            }
        }

        public IEnumerable<ICheck> ReadAll()
        {
            using (var db = new GameStoreContext())
            {
                return db.Checks.ToList();
            }
        }

        public void Remove(ICheck item)
        {
            using (var db = new GameStoreContext())
            {
                var check = new CheckEntity(item);
                db.Checks.Remove(check);
                db.SaveChanges();
            }
        }
    }
}
