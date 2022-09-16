using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLaptopStore.LaptopView
{
    public class LaptopStoreView
    {
        public Guid Item_id { get; set; }   

        public string Item_name { get; set; }

        public decimal Item_price { get; set; } 

        public string Image_path { get; set; }  

        public string Description { get; set; } 

        public string Category { get; set; }
        
        public string Item_code { get; set; }


    }
}