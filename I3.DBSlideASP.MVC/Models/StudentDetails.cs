using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Models
{
    public class StudentDetails : StudentListItem
    {
        public DateTime DateNaissance { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.DateNaissance.Year;
            }
        }
        public int ResultatAnnuel { get; set; }
        public int Pourcentage { get
            {
                return this.ResultatAnnuel * 5;
            } }
        public string Identifiant { get; set; }
        public string Course_id { get; set; }
    }
}
