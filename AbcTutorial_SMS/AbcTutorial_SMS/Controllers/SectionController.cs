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
    public class SectionController : Controller
    {

        SectionDAL aDal = new SectionDAL();
        //
        // GET: /Section/
        public ActionResult SectionList()
        {
            return View();
        }


        public ActionResult SectionEntry()
        {
            return View();
        }

        public JsonResult Update_Info(SectionDAO aDao)
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

        public JsonResult ddlLoadBatch()
        {

            DataSet ds = aDal.BatchDDLLoadDAL();
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




        public JsonResult Save_Info(SectionDAO aDao)
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


        public JsonResult LoadData()
        {

            DataSet ds = aDal.LoadAllDataDAL();
            List<SectionDAO> lists = new List<SectionDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new SectionDAO
                {
                    SectionId = Convert.ToInt32(dr["SectionId"]),
                    SL = (dr["SL"].ToString()),
                    SectionName = (dr["SectionName"].ToString()),
                    BatchName = (dr["BatchName"].ToString())


                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetMAsterDataByID(int MasterId)
        {

            DataSet ds = aDal.LoadDataByMasterIDDAL(MasterId);
            List<SectionDAO> lists = new List<SectionDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new SectionDAO
                {
                    SectionId = Convert.ToInt32(dr["SectionId"]),
                    SectionName = Convert.ToString(dr["SectionName"]),
                    BatchId = Convert.ToInt32(dr["BatchId"]),
 


                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReomveDataByMAsterId(int SectionId)
        {

            string result = string.Empty;

            try
            {
                aDal.DeleteInfoDAL(SectionId);
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