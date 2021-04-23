using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbcTutorial_SMS.DAO
{
    public class CourseDAO
    {

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string SectionName { get; set; }
        public string BatchName { get; set; }
        public string SL { get; set; }
        public int BatchId { get; set; }
        public int SectionId { get; set; }
       
    }
}