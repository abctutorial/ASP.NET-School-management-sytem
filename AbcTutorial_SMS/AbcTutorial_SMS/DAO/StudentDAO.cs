using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbcTutorial_SMS.DAO
{
    public class StudentDAO
    {

        public int StudentId { get; set; }
        public string SL { get; set; }
        public string SectionName { get; set; }
        public string BatchName { get; set; }
        public string StudentName { get; set; }

        public string StudentIdNO { get; set; }
        public int BatchId { get; set; }
        public int SectionId { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PresentAddrees { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime AddmittedDate { get; set; }
        public bool Status { get; set; }
    
    }
}