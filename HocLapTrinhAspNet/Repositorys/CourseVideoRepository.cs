﻿using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class CourseVideoRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        public void AddCourseVideo(CourseVideo courseVideo)
        {
            myDb.CourseVideos.Add(courseVideo);
            myDb.SaveChanges();
        }

        public void UpdateCourseVideo(CourseVideo courseVideo)
        {
            var obj = myDb.CourseVideos.FirstOrDefault(x => x.CourseVideoId == courseVideo.CourseVideoId);
            obj.VideoName = courseVideo.VideoName;
            obj.VideoUrl = courseVideo.VideoUrl;
            obj.CourseId = courseVideo.CourseId;
            myDb.SaveChanges();
        }

        public void DeleteCourseVideo(int courseVideoId)
        {
            var courseVideo = myDb.CourseVideos.Find(courseVideoId);
            myDb.CourseVideos.Remove(courseVideo);
            myDb.SaveChanges();
        }

        public CourseVideo GetCourseVideoById(int courseVideoId)
        {
            return myDb.CourseVideos.Find(courseVideoId);
        }
    }
}