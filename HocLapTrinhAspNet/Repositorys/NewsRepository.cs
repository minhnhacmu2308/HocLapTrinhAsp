using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class NewsRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
          public void AddNews(News News)
        {
            myDb.News.Add(News);
            myDb.SaveChanges();
        }

        public void UpdateNews(News News)
        {
            var obj = myDb.News.FirstOrDefault(x => x.NewsId == News.NewsId);
            obj.Content = News.Content;
            obj.Image = News.Image;
            obj.Title = News.Title;
            myDb.SaveChanges();
        }

        public void DeleteNews(int NewsId)
        {
            var News = myDb.News.Find(NewsId);
            myDb.News.Remove(News);
            myDb.SaveChanges();
        }

        public News GetNewsById(int NewsId)
        {
            return myDb.News.Find(NewsId);
        }
    }
}