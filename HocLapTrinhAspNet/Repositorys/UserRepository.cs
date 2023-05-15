using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class UserRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        public void AddUser(User user)
        {
            user.Password = md5(user.Password);
            myDb.Users.Add(user);
            myDb.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var obj = myDb.Users.FirstOrDefault(x => x.UserId == user.UserId);
            obj.PhoneNumber = user.PhoneNumber;
            obj.FullName = user.FullName;
            obj.Address = user.Address;
            myDb.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = myDb.Users.Find(userId);
            myDb.Users.Remove(user);
            myDb.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return myDb.Users.Find(userId);
        }

        public string md5(string password)
        {
            MD5 md = MD5.Create();
            byte[] inputString = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md.ComputeHash(inputString);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb.ToString();
        }

        public User CheckLogin(User user)
        {
            string md5Password = md5(user.Password);
            var obj = myDb.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == md5Password);
            if(obj != null)
            {
                return obj;
            }
            return null;
        }

        public User GetUserByEmail(string email)
        {
            return myDb.Users.Find(email);
        }
    }
}