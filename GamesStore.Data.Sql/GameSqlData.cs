

using GamesStore.DI;

namespace GamesStore.Data.Sql
{
    public class GameSqlData : IData<IGame>
    {
        public void Add(IGame item)
        {
            using (var db = new GameStoreContext())
            {
                var book = new GameEntity(item);
                db.Games.Add(book);
                db.SaveChanges();
            }
        }

        public IEnumerable<IGame> ReadAll()
        {
            using (var db = new GameStoreContext())
            {
                return db.Games.ToList();
            }
        }

        public void Remove(IGame item)
        {
            using (var db = new GameStoreContext())
            {
                var game = db.Games.SingleOrDefault(b => b.Company.Equals(item.Company) &&
                    b.Name.Equals(item.Name) &&
                    b.Price.Equals(item.Price));
                db.Games.Remove(game);
                db.SaveChanges();
            }
        }
    }
}
