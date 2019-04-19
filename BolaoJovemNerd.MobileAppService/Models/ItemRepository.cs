using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace BolaoJovemNerd.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<string, Item> items =
            new ConcurrentDictionary<string, Item>();

        public ItemRepository()
        {
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Jovem Nerd", Description = "19", CharactersList = "Varys, Jon Snow,Briene, Cão, Euron, Cersei, Jaime ", Avatar = "jovemnerd.jpeg", Position = "1" });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "JP", Description = "13", CharactersList = "", Avatar = "JP.jpeg", Position = "2" });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Marcelo", Description = "12", CharactersList = "", Avatar = "marcelo.jpg", Position = "3" });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Tucano", Description = "11", CharactersList = "", Avatar = "tucano.jpg", Position = "4" });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Katiucha", Description = "10", CharactersList = "", Avatar = "Katiucha.jpg", Position = "5" });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Azaghal", Description = "9", CharactersList = "", Avatar = "azaghal.jpg", Position = "6" });
        }

        public Item Get(string id)
        {
            return items[id];
        }

        public IEnumerable<Item> GetAll()
        {
            return items.Values.OrderBy(i => i.Position);
        }

        public void Add(Item item)
        {
            item.Id = Guid.NewGuid().ToString();
            items[item.Id] = item;
        }

        public Item Find(string id)
        {
            Item item;
            items.TryGetValue(id, out item);

            return item;
        }

        public Item Remove(string id)
        {
            Item item;
            items.TryRemove(id, out item);

            return item;
        }

        public void Update(Item item)
        {
            items[item.Id] = item;
        }
    }
}
