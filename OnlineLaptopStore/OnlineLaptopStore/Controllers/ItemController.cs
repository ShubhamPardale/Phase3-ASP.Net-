using OnlineLaptopStore.LaptopView;
using OnlineLaptopStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLaptopStore.Controllers
{
    public class ItemController : Controller
    {
        private LaptopStoreEntities obj;
        public ItemController()
        { 
            obj = new LaptopStoreEntities(); 
        }

        // GET: Item
        public ActionResult Index()
        {
            ItemView objitem = new ItemView();
            objitem.CategorySelectListItem = (from objCat in obj.Categories
               select new SelectListItem()
                 {
                   Text = objCat.Category_name,
                   Value = objCat.Category_id.ToString(),
                   Selected = true
                 });
            return View(objitem);
        }

        [HttpPost]
        public JsonResult Index(ItemView objitem)
        {
            string NewImg = Guid.NewGuid() + Path.GetExtension(objitem.Image_path.FileName);
            objitem.Image_path.SaveAs(Server.MapPath("~/Images/" + NewImg));

            Item ObjItem = new Item();
            ObjItem.Image_path = "~/Images/" + NewImg;
            ObjItem.Category_id = objitem.Category_id;  
            ObjItem.Description = objitem.Description;
            ObjItem.Item_id = Guid.NewGuid();
            ObjItem.Item_name = objitem.Item_name;
            ObjItem.Item_price = objitem.Item_price;
            ObjItem.Item_code = objitem.Item_code;
            obj.Items.Add(ObjItem);
            obj.SaveChanges();
             
            return Json(new {Success= true,Message="Laptop added successfully!"},JsonRequestBehavior.AllowGet);
        }
    }
}