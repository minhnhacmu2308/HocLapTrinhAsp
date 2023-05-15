using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Models
{
    public class CourseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseTypeId { get; set; }
        public string TypeName { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}