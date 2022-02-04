using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Models
{
    public class ProfessorListItem
    {
        [Key]
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant")]
        public int Professor_Id { get; set; }
        [DisplayName("Nom de famille")]
        public string Professor_Name { get; set; }
        [DisplayName("Prénom")]
        public string Professor_Surname { get; set; }
        [DisplayName("Identifiant de Section")]
        public int Section_Id { get; set; }
    }
}
