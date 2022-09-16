using OnlineLaptopStore.LaptopView;
using OnlineLaptopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLaptopStore.Controllers
{
    public class LaptopStoreController : Controller
    {
        private LaptopStoreEntities obj;
        private List<CartView> listofCartView;
        public  LaptopStoreController()
        {
            obj = new LaptopStoreEntities();
            listofCartView = new List<CartView>();
        }
        // GET: LaptopStore
        public ActionResult Index()
        {
            IEnumerable<LaptopStoreView> listofLaptopStoreView = (from OBJitem in obj.Items
                    join
                    objcat in obj.Categories
                    on OBJitem.Category_id equals objcat.Category_id
                    select new LaptopStoreView()
                    {
                        Image_path = OBJitem.Image_path,
                        Item_name = OBJitem.Item_name,
                        Description = OBJitem.Description,
                        Item_price = OBJitem.Item_price,
                        Item_id = OBJitem.Item_id,
                        Category = objcat.Category_name,
                        Item_code = OBJitem.Item_code,
                    }).ToList();
            return View(listofLaptopStoreView);
        }

        [HttpPost]
        public JsonResult Index(string Item_id) 
        {

            CartView objcartview = new CartView();
            Item objitem = obj.Items.Single(model => model.Item_id.ToString() == Item_id) ;
            if (Session["CartCounter"]!= null)
            {
                listofCartView = Session["CartItems"] as List<CartView>;
            }
            if(listofCartView.Any(model => model.Item_id == Item_id))
            {
                objcartview = listofCartView.Single(model => model.Item_id == Item_id);
                objcartview.Quantity = objcartview.Quantity + 1;
                objcartview.Total = objcartview.Quantity * objcartview.Unit_price;
            }
            else 
            { 
                objcartview.Item_id = Item_id;
                objcartview.Item_name = objitem.Item_name;
                objcartview.Image_path = objitem.Image_path;
                objcartview.Quantity = 1;
                objcartview.Total = objitem.Item_price;
                objcartview.Unit_price = objitem.Item_price;
                listofCartView.Add(objcartview);
            }

            Session["CartCounter"] = listofCartView.Count;
            Session["CartItems"] = listofCartView;
            return Json(new {Success = true, Counter = listofCartView.Count},JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cart()
        {
            listofCartView = Session["CartItems"] as List<CartView>;
            return View(listofCartView);
        }

    }
}