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


    public class StudentController : Controller
    {

        StudentDAL aDal = new StudentDAL();
        //
        // GET: /Student/
        public ActionResult StudentList()
        {
            return View();
        }


        public ActionResult StudentEntry()
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



        public JsonResult Save_Info(StudentDAO aDao)
        {
            string Mes = "";

            try
            {
                aDal.AddNewInfoDAL(aDao);


                string IdNo = "";
                DataSet ds = aDal.GetStudentIdNODAL();
                List<StudentDAO> lists = new List<StudentDAO>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {


                    IdNo = (dr["StudentIdNO"].ToString());



                }

                Mes = "Operation Successful!! Student ID NO: " + IdNo;
            }
            catch (Exception e)
            {
                Mes = "Operation Faild!!";
            }

            return Json(Mes, JsonRequestBehavior.AllowGet);
        }


        public JsonResult StatusChangeStudentByMAsterId(int StudentId)
        {

            string result = string.Empty;

            try
            {
                aDal.DeleteInfoDAL(StudentId);
                result = "Operation Deleted";
            }
            catch (Exception)
            {
                result = "Operation Faild";

                //throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadData(int BatchId)
        {

            DataSet ds = aDal.LoadAllDataDAL(BatchId);
            List<StudentDAO> lists = new List<StudentDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new StudentDAO
                {
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    SL = (dr["SL"].ToString()),

                    StudentIdNO = (dr["StudentIdNO"].ToString()),
                    StudentName = (dr["StudentName"].ToString()),
                    BatchName = (dr["BatchName"].ToString()),
                    SectionName = (dr["SectionName"].ToString()),
                    Gender = (dr["Gender"].ToString())


                });

            }
            return Json(lists, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetMAsterDataByID(int MasterId)
        {

            DataSet ds = aDal.LoadDataByMasterIDDAL(MasterId);
            List<StudentDAO> lists = new List<StudentDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new StudentDAO
                {
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    StudentIdNO =  (dr["StudentIdNO"].ToString()),
                    StudentName =  (dr["StudentName"].ToString()),
                    BatchId = Convert.ToInt32(dr["BatchId"]),
                    SectionId = Convert.ToInt32(dr["SectionId"]),
                    DOB =  Convert.ToDateTime(dr["DOB"]),
                    Gender =  (dr["Gender"].ToString()),
                    Religion =  (dr["Religion"].ToString()),

                    FatherName = Convert.ToString(dr["FatherName"]),
                    MotherName = Convert.ToString(dr["MotherName"]),
                    PresentAddrees = Convert.ToString(dr["PresentAddrees"]),
                    PermanentAddress = Convert.ToString(dr["PermanentAddress"]),
                    AddmittedDate = Convert.ToDateTime(dr["AddmittedDate"]),
                    Status = Convert.ToBoolean(dr["Status"])




                });
                //ddlLoadSectonbyBatchID(Convert.ToInt32(dr["BatchId"]));
            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }
    }
}