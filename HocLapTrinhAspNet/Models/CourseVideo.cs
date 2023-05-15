using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Models
{
    public class CourseVideo
    {
        public int CourseVideoId { get; set; }
        public int CourseId { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }

        public Course Course { get; set; }
    }
}