using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    //public static class Role
    //{
    //    public const string Admin = "Admin";
    //    public const string User = "User";
    //}
    public class Role
    {

        public int RoleId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
