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

        public List<News> GetAll()
        {
            return myDb.News.OrderByDescending(x => x.NewsId).ToList();
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
        public List<News> Gets(int page, int pagesize)
        {
            return myDb.News.OrderByDescending(u => u.NewsId).ToList().
                Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}