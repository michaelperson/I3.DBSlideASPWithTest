using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Models
{
    public class StudentCreateForm
    {
        //Utilisé lors de la récupération du formulaire
        [Required(ErrorMessage ="Ce champs est obligatoire.")]
        [StringLength(maximumLength : 16, MinimumLength = 2, ErrorMessage ="La taille doit être comprise entre 2 et 16")]
        //[RegularExpression(@"(\D)")]
        [DisplayName("Nom : ")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Ce champs est obligatoire.")]
        [MinLength(2, ErrorMessage ="La taille minimum est de 2.")]
        [MaxLength(16, ErrorMessage = "La taille maximum est de 16.")]
        [DisplayName("Prénom : ")]
        public string Prenom { get; set; }
        [Required(ErrorMessage ="Ce champs est obligatoire.")]
        [DisplayName("Date de naissance : ")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Required(ErrorMessage ="Ce champs est obligatoire.")]
        [Range(0,20, ErrorMessage ="Le résultat annuel doit être compris entre 0 et 20.")]
        [DisplayName("Résultat annuel : ")]
        public ushort ResultatAnnuel { get; set; }
        [Required(ErrorMessage ="Ce champs est obligatoire.")]
        [DisplayName("Section : ")]
        public int Section_id { get; set; }
        [Required(ErrorMessage = "Ce champs est obligatoire.")]
        [DisplayName("Cours : ")]
        public string Course_id { get; set; }

        //Utilisé lors de l'affichage
        public IEnumerable<int> Section_ids { get; set; }
        public IEnumerable<string> Course_ids { get; set; }

        //Utilisé pour le mapper
        public string Identifiant { get
            {
                if (string.IsNullOrWhiteSpace(this.Nom) || string.IsNullOrWhiteSpace(this.Prenom)) throw new FormatException();
                return this.Prenom[0] + this.Nom.Substring(0, 5).Replace(' ', '.');
            } 
        }
    }
}
