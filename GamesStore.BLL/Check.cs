using GamesStore.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.BLL
{
    public class Check : ICheck
    { 
        public IGame Game { get; set; }
        public IStore Store { get; set; }
        public DateTime DateTime { get; set; }

        public string Print()
        {
            return $"Новая продажа в магазине {Store.Name}\r\n" +
                   $"по адресу {Store.Url}\r\n" +
                   $"{DateTime}\r\n\r\n" +
                   $"Наименование товара: {Game.Name}\r\n" +
                   $"Стоимость: {Game.Price}₽\r\n";
        }
    }
}
