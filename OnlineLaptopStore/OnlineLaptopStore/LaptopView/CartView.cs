using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLaptopStore.LaptopView
{
    public class CartView
    {
        public string Item_id { get; set; }
        
        public decimal Quantity { get; set; }   

        public decimal Unit_price { get; set; }

        public decimal Total { get; set; }

        public string Image_path { get; set; }    

        public string Item_name { get; set; }

    }
}