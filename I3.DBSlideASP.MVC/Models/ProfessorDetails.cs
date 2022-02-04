using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Models
{
    public class ProfessorDetails
    {
        [DisplayName("Identifiant")]
        [Key]
        [ScaffoldColumn(false)]
        public int Professor_Id { get; set; }
        [DisplayName("Nom de famille")]
        public string Professor_Name { get; set; }
        [DisplayName("Prénom")]
        public string Professor_Surname { get; set; }
        [DisplayName("Identifiant de Section")]
        public int Section_ID { get; set; }
        [DisplayName("Identifiant Bureau")]
        public int Professor_Office { get; set; }
        [DisplayName("Courrier électronique")]
        [EmailAddress]
        public string Professor_Email { get; set; }
        [DisplayName("Date d'engagement")]
        [DataType(DataType.Date)]
        public DateTime Professor_HireDate { get; set; }
        [DisplayName("Salaire mensuel")]
        public int Professor_Wage { get; set; }
    }
}
