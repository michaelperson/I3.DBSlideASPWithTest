using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Models
{
    public class StudentListItem : StudentNames
    {
        public int Id { get; set; }
        public int Section_id { get; set; }
    }

    //Nous préférons utiliser l'héritage de StudentNames pour nous simplifier la création de l'objet StudentListItem
    /*
     public class StudentListItem
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Section_id { get; set; }
    }
     */
}
