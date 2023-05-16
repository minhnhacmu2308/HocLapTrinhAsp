using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
            return myDb.Courses.Include(x => x.CourseType).Include(x => x.CourseVideos).FirstOrDefault(x =>x.CourseId == courseId);
        }

        //customer 

        public List<Course> GetCourseByType(int courseTypeId,int page, int pagesize)
        {
            return myDb.Courses.Include(x => x.CourseType).Include(x => x.CourseVideos).Where(x => x.CourseTypeId == courseTypeId).OrderByDescending(u => u.CourseId).ToList().
               Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }

        public int getNumberByType(int courseTypeId)
        {
            int total = myDb.Courses.Where(p => p.CourseTypeId  == courseTypeId).ToList().Count;
            int count = 0;
            count = total / 6;
            if (total % 6 != 0)
            {
                count++;
            }
            return count;
        }

        public List<Course> GetCourseByIsFree(bool isFree, int page, int pagesize)
        {
            return myDb.Courses.Include(x => x.CourseType).Include(x => x.CourseVideos).Where(x => x.IsFree == isFree).OrderByDescending(u => u.CourseId).ToList().
                Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }

        public int getNumber()
        {
            int total = myDb.Courses.ToList().Count;
            int count = 0;
            count = total / 6;
            if (total % 6 != 0)
            {
                count++;
            }
            return count;
        }
        public List<Course> Gets(int page ,int pagesize)
        {
            return myDb.Courses.Include(x => x.CourseType).Include(x => x.CourseVideos).OrderByDescending(u => u.CourseId).ToList().
                Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }

        public List<Course> GetTops()
        {
            return myDb.Courses.Include(x => x.CourseType).Include(x => x.CourseVideos).OrderByDescending(u => u.CourseId).Take(9).ToList();
        }

        public int getNumberByIsFree(bool isFree)
        {
            int total = myDb.Courses.Where(p => p.IsFree == isFree).ToList().Count;
            int count = 0;
            count = total / 6;
            if (total % 6 != 0)
            {
                count++;
            }
            return count;
        }

    }
}