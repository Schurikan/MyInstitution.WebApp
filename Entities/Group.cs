using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? GroupLeaderEmployeeId { get; set; }
        public string Image { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
