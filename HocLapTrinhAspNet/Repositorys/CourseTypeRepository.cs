using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class CourseTypeRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        public List<CourseType> GetAll()
        {
            return myDb.CourseTypes.OrderByDescending(x => x.CourseTypeId).ToList();
        }
        public List<Course> GetCourseByType(int id)
        {
            return myDb.Courses.Where(x => x.CourseTypeId == id).ToList();
        }
        public void AddCourseType(CourseType courseType)
        {
            myDb.CourseTypes.Add(courseType);
            myDb.SaveChanges();
        }

        public void UpdateCourseType(CourseType courseType)
        {
            var obj = myDb.CourseTypes.FirstOrDefault(x => x.CourseTypeId == courseType.CourseTypeId);
            obj.TypeName = courseType.TypeName;
            myDb.SaveChanges();
        }

        public void DeleteCourseType(int courseTypeId)
        {
            var courseType = myDb.CourseTypes.Find(courseTypeId);
            myDb.CourseTypes.Remove(courseType);
            myDb.SaveChanges();
        }

        public CourseType GetCourseTypeById(int courseTypeId)
        {
            return myDb.CourseTypes.FirstOrDefault(x => x.CourseTypeId == courseTypeId);
        }

        //customer 
        public List<CourseType> Gets()
        {
            return myDb.CourseTypes.ToList();
        }
    }
}