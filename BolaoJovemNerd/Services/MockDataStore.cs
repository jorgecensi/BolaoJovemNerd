using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolaoJovemNerd.Models;

namespace BolaoJovemNerd.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Jovem Nerd", Description="19", CharactersList="Varys, Jon Snow,Briene, Cão, Euron, Cersei, Jaime ", Avatar="jovemnerd.jpeg", Position ="1" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "JP", Description="13", CharactersList="", Avatar="JP.jpeg", Position ="2" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Marcelo", Description="12", CharactersList="", Avatar="marcelo.jpg", Position ="3" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Tucano", Description="11", CharactersList="", Avatar="tucano.jpg", Position ="4" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Katiucha", Description="10", CharactersList="", Avatar="Katiucha.jpg", Position ="5" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Azaghal", Description="9", CharactersList="", Avatar="azaghal.jpg", Position ="6" }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}