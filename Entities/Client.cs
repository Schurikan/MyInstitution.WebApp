using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Vorname")]
        [Required]
        [MaxLength(50)]
        public string Forename { get; set; }

        [Display(Name = "Nachname")]
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Gruppennummer")]
        public int? GroupId { get; set; }

        [Display(Name = "Geburtstag")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string Image { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
