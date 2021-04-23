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


    public class CourseController : Controller
    {

        private CourseDAL aDal = new CourseDAL();
        //
        // GET: /Course/
        public ActionResult CourseListView()
        {
            return View();
        }


        public ActionResult CourseEntry()
        {
            return View();
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


        public JsonResult ddlLoadSectonbyBatchID(int BatchId)
        {

            DataSet ds = aDal.SectionByBathIdDDLLoadDAL(BatchId);
            List<SectionDAO> lists = new List<SectionDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new SectionDAO
                {
                    SectionId = Convert.ToInt32(dr["SectionId"]),

                    SectionName = (dr["SectionName"].ToString())


                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }





        public JsonResult Save_Info(CourseDAO aDao)
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



        public JsonResult Update_Info(CourseDAO aDao)
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
            List<CourseDAO> lists = new List<CourseDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new CourseDAO
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    SL = (dr["SL"].ToString()),
                    CourseName = (dr["CourseName"].ToString()),
                    SectionName = (dr["SectionName"].ToString()),
                    BatchName = (dr["BatchName"].ToString())


                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }



        public JsonResult ReomveDataByMAsterId(int CourseId)
        {

            string result = string.Empty;

            try
            {
                aDal.DeleteInfoDAL(CourseId);
                result = "Operation Deleted";
            }
            catch (Exception)
            {
                result = "Operation Faild";

                //throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetMAsterDataByID(int MasterId)
        {

            DataSet ds = aDal.LoadDataByMasterIDDAL(MasterId);
            List<CourseDAO> lists = new List<CourseDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new CourseDAO
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    SectionId = Convert.ToInt32(dr["SectionId"]),

                    CourseName = Convert.ToString(dr["CourseName"]),
                    BatchId = Convert.ToInt32(dr["BatchId"])

                   

                });
                //ddlLoadSectonbyBatchID(Convert.ToInt32(dr["BatchId"]));
            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }

	}
}