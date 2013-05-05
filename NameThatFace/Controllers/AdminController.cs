//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace NameThatFace.Controllers
//{
//    public class AdminController : Controller
//    {
//        //
//        // GET: /Admin/

//        public ActionResult Index()
//        {
//            return View();
//        }

//        public class AdminAddRequest
//        {
//            [Required]
//            public string Username { get; set; }

//            [Required]
//            public string FullName { get; set; }

//            [Required]
//            public HttpPostedFileBase Picture { get; set; }
//        }

//        public class AdminAddViewModel
//        {
//            public string Username { get; set; }
//            public string FullName { get; set; }
//        }

//        [HttpGet]
//        public ActionResult Add()
//        {
//            var model = new AdminAddViewModel();
//            return View(model);
//        }

//        [HttpPost]
//        public ActionResult Add(AdminAddRequest requestModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                var model = new AdminAddViewModel { FullName = requestModel.FullName, Username = requestModel.Username };
//                return View(model);
//            }

//            // do add
//            return null;
//        }

//        public class AdminDeleteRequest
//        {
//            [Required]
//            public string Username { get; set; }
//        }

//        public ActionResult Delete(AdminDeleteRequest requestModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return null;
//            }
//            return null;

//            // do delete
//        }

//    }
//}
