using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbcTutorial_SMS.DAL;
using AbcTutorial_SMS.DAO;

namespace AbcTutorial_SMS.Controllers
{
    public class BatchController : Controller
    {

        BatchDAL aDal= new BatchDAL();
        //
        // GET: /Batch/
        public ActionResult ListView()
        {
            return View();
        }


        public ActionResult AddNewInfo ()
        {
            return View();
        }

        public JsonResult Save_Info(BatchDAO aDao)
        {
            string Mes = "";

            try
            {
                aDal.AddNewInfoDAL(aDao);
                Mes = "Operation Successful!!";
            }
            catch (Exception e)
            {
                Mes = "Operation Faild!!";
            }

            return Json(Mes, JsonRequestBehavior.AllowGet);
        }




        public JsonResult Update_Info(BatchDAO aDao)
        {
            string Mes = "";

            try
            {
                aDal.UpdateInfoDAL(aDao);
                Mes = "Operation Successful!!";
            }
            catch (Exception e)
            {
                Mes = "Operation Faild!!";
            }

            return Json(Mes, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadData()
        {

            DataSet ds = aDal.LoadAllDataDAL();
            List<BatchDAO> lists = new List<BatchDAO>();
            foreach ( DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new BatchDAO
                {
                    BatchId = Convert.ToInt32(dr["BatchId"]),
                    SL = (dr["SL"].ToString()),
                    BatchName = (dr["BatchName"].ToString())
                    

                });
                
            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }



        
        public JsonResult GetMAsterDataByID(int MasterId)
        {

            DataSet ds = aDal.LoadDataByMasterIDDAL(MasterId);
            List<BatchDAO> lists = new List<BatchDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new BatchDAO
                {
                    BatchId = Convert.ToInt32(dr["BatchId"]),
                   
                    BatchName = (dr["BatchName"].ToString())


                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReomveDataByMAsterId(int BatchId)
        {

            string result = string.Empty;

            try
            {
                aDal.DeleteInfoDAL(BatchId);
                result = "Operation Deleted";
            }
            catch (Exception)
            {
                result = "Operation Faild";
                
                //throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

	}
}