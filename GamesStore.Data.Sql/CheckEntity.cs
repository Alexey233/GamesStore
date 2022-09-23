using GamesStore.DI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Data.Sql
{
    public class CheckEntity : ICheck
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string GameName { get; set; }

        [NotMapped]
        public IGame Game { get; set; }
        [NotMapped]
        public IStore Store { get; set; }
        public DateTime DateTime { get; set; }

        public CheckEntity(ICheck item)
        {
            Id = 0;
            Store = item.Store;
            StoreName = item.Store.Name;
            Game = item.Game;
            GameName = item.Game.Name;
            DateTime = item.DateTime;
        }

        public CheckEntity() { }

    }
}
