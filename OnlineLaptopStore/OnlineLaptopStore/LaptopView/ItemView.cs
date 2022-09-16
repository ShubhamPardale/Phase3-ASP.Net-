using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLaptopStore.LaptopView
{
    public class ItemView
    {

        public Guid Item_id { get; set; }   

        public int Category_id { get; set; }    

        public string Item_code { get; set; }

        public string Item_name { get; set; }

        public string Description { get; set; }

        public decimal Item_price { get; set; }

        public HttpPostedFileBase Image_path { get; set; }  

        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; } 

    }
}