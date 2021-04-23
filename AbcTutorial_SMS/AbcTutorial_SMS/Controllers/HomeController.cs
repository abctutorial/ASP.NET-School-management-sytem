using AbcTutorial_SMS.DAL;
using AbcTutorial_SMS.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbcTutorial_SMS.Controllers
{
    public class HomeController : Controller
    {

        private UserDAL aDal = new UserDAL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult LoginPage()
        {
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public JsonResult GetLoginInfo(UserDAO dao)
        {

            DataTable dt = aDal.LoadAllDataDAL(dao);

            string mes = "";

            if (dt.Rows.Count > 0)
            {
                Session["LoginName"] = dao.LoginName;
                mes = "Login Successfully";
            }
            else
            {
                mes = "Login Faild";

            }
            return Json(mes, JsonRequestBehavior.AllowGet);
        }
    }
}