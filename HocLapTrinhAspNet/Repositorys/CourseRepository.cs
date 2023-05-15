using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class CourseRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        public void AddCourse(Course course)
        {
            myDb.Courses.Add(course);
            myDb.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            var obj = myDb.Courses.FirstOrDefault(x => x.CourseId == course.CourseId);
            obj.CourseName = course.CourseName;
            obj.CourseTypeId = course.CourseTypeId;
            obj.Image = course.Image;
            obj.IsFree = course.IsFree;
            obj.Price = course.Price;
            myDb.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            var course = myDb.Courses.Find(courseId);
            myDb.Courses.Remove(course);
            myDb.SaveChanges();
        }

        public Course GetCourseById(int courseId)
        {
            return myDb.Courses.Find(courseId);
        }
    }
}