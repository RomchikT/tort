using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    public class CakeData
    {
        public string Shape { get; set; } = null;
        public string Size { get; set; } = null;
        public string Taste { get; set; } = null;
        public string Glaze { get; set; } = null;
        public string Design { get; set; } = null;

        public CakeData()
        {

        }
    }

    public class ItemData
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public ItemData(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
