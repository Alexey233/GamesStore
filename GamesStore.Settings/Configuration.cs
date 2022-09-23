using GamesStore.BLL;
using GamesStore.Data.Memory;
using GamesStore.DI;
using SimpleInjector;
using GamesStore.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Settings
{
    public class Configuration
    {
        public Container Container { get; }

        public Configuration()
        {
            Container = new Container();

            Setup();
          
        }

        public virtual void Setup()
        {
            Container.Register<IGame,Game>(Lifestyle.Transient);
            Container.Register<ICheck, Check>(Lifestyle.Transient);
            Container.Register<IStore, Store>(Lifestyle.Singleton);
            /*Container.Register<IData<IGame>, GameMemoryData>(Lifestyle.Singleton);
            Container.Register<IData<ICheck>, CheckMemoryData>(Lifestyle.Singleton);*/
            Container.Register<IData<IGame>, GameSqlData>(Lifestyle.Singleton);
            Container.Register<IData<ICheck>, CheckSqlData>(Lifestyle.Singleton);
        }

    }
}
