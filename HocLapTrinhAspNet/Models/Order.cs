using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int UserId { get; set; } // foreign key
        public int CourseId { get; set; } // foreign key
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; } // navigation property
        public Course Course { get; set; } // navigation property
    }
}