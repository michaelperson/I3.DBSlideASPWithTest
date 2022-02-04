using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Models
{
    public class ProfessorEditForm
    {
        [ScaffoldColumn(false)]
        [DisplayName("Nom de famille")]
        public string Professor_Name { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Prénom")]
        public string Professor_Surname { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0,int.MaxValue)]
        [DisplayName("Salaire mensuel")]
        public int Professor_Wage { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        [DisplayName("Identifiant de Bureau")]
        public int Professor_Office { get; set; }
    }
}
