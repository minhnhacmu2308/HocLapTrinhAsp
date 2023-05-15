using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsFree { get; set; }
        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }
        public ICollection<Order> Orders { get; set; } // navigation property
        public ICollection<CourseVideo> CourseVideos { get; set; }
    }
}