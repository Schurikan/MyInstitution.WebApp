using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
