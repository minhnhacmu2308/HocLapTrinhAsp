using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class RoleRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        public void AddRole(Role role)
        {
            myDb.Roles.Add(role);
            myDb.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            var obj = myDb.Roles.FirstOrDefault(x => x.RoleId == role.RoleId);
            obj.Name = role.Name;
            myDb.SaveChanges();
        }

        public void DeleteRole(int roleId)
        {
            var role = myDb.Roles.Find(roleId);
            myDb.Roles.Remove(role);
            myDb.SaveChanges();
        }

        public Role GetRoleById(int roleId)
        {
            return myDb.Roles.Find(roleId);
        }
    }
}