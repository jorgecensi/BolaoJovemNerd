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
            Add(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Jovem Nerd",
                Description = "11",
                CharactersList = "Varys, Jon Snow, Brienne, Cão, Euron, Cersei, Jaime ",
                Avatar = "jovemnerd.jpeg",
                Position = "2",
                Difference = "-"
            });
            Add(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "JP",
                Description = "12",
                CharactersList = "Varys, Jorah Mormont, Verme Cinzento, Daenerys, Gendry, Brienne, Sansa, Melisandre, Euron, Cersei",
                Avatar = "JP.jpeg",
                Position = "1",
                Difference = "-"

            });
            Add(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Marcelo",
                Description = "9",
                CharactersList = "Varys, Verme Cinzento, Brienne, Davos, Cao, Euron, Cersei, Jaime, Tyrion, Drogon, Rhaegal",
                Avatar = "marcelo.jpg",
                Position = "3",
                Difference = "+2"
            });
            Add(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Tucano",
                Description = "12",
                CharactersList = "Varys, Jorah Mormont, Missandei, Daenerys, Brienne, Melisandre, Cao, Euron, Cersei, Jaime, Montanha, Drogon",
                Avatar = "tucano.jpg",
                Position = "1",
                Difference = "+2"
            });
            Add(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Katiucha",
                Description = "11",
                CharactersList = "Varys, Verme Cinzento, Missandei, Daenerys, Brienne, Arya, Melisandre, Cao, Euron, Cersei, Jaime, Drogon, Rhaegal",
                Avatar = "Katiucha.jpg",
                Position = "2",
                Difference = "+3"
            });
            Add(new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Azaghal",
                Description = "12",
                CharactersList = "Jorah Mormont, Verme Cinzento, Missandei, Brienne, Sansa, Davos, Melisandre, Cao, Euron, Cersei, Jaime, Montanha, Drogon, Rhaegal",
                Avatar = "azaghal.jpg",
                Position = "1",
                Difference = "+3"
            });
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
