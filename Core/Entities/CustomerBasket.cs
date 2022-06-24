using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
        public List<BasketItem> Items { get; set; }= new List<BasketItem>();
    }
}