using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware_main
{
    internal class CartItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
