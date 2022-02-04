using DBSlideDataContext.DTO;
using I3.DBSlideASP.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Handlers
{
    public static class Mapper
    {
        public static StudentListItem ToListItem(this Student student)
        {
            if (student is null) return null;
            return new StudentListItem
            {
                Id = student.Student_ID,
                Nom = student.Last_Name,
                Prenom = student.First_Name,
                Section_id = student.Section_ID
            };
        }
        public static StudentNames ToNames(this Student student)
        {
            if (student is null) return null;
            return new StudentNames
            {
                Nom = student.Last_Name,
                Prenom = student.First_Name
            };
        }

        public static StudentDetails ToDetails(this Student student)
        {
            if (student is null) return null;
            return new StudentDetails
            {
                Id = student.Student_ID,
                Nom = student.Last_Name,
                Prenom = student.First_Name,
                Section_id = student.Section_ID,
                DateNaissance = student.BirthDate,
                Identifiant = student.Login,
                ResultatAnnuel = student.Year_Result,
                Course_id = student.Course_ID
            };
        }

        public static Student ToDTO(this StudentCreateForm form)
        {
            if (form is null) return null;
            return new Student
            {
                First_Name = form.Prenom,
                Last_Name = form.Nom,
                BirthDate = form.DateNaissance,
                Section_ID = form.Section_id,
                Course_ID = form.Course_id,
                Year_Result = form.ResultatAnnuel,
                Login = form.Identifiant
            };
        }

        public static ProfessorListItem ToListItem(this Professor entity)
        {
            if (entity is null) return null;
            return new ProfessorListItem
            {
                Professor_Id = entity.Professor_ID,
                Professor_Name = entity.Professor_Name,
                Professor_Surname = entity.Professor_Surname,
                Section_Id = entity.Section_ID
            };
        }

        public static ProfessorDetails ToDetails(this Professor entity)
        {
            if (entity is null) return null;
            return new ProfessorDetails
            {
                Professor_Id = entity.Professor_ID,
                Professor_Name = entity.Professor_Name,
                Professor_Surname = entity.Professor_Surname,
                Section_ID = entity.Section_ID,
                Professor_Email = entity.Professor_Email,
                Professor_HireDate = entity.Professor_HireDate,
                Professor_Office = entity.Professor_Office,
                Professor_Wage = entity.Professor_Wage
            };
        }

        public static ProfessorDeleteForm ToDeleteForm(this Professor entity)
        {
            if (entity is null) return null;
            return new ProfessorDeleteForm
            {
                Professor_Name = entity.Professor_Name,
                Professor_Surname = entity.Professor_Surname,
                Professor_Email = entity.Professor_Email
            };
        }

        public static ProfessorEditForm ToEditForm(this Professor entity)
        {
            if (entity is null) return null;
            return new ProfessorEditForm
            {
                Professor_Name = entity.Professor_Name,
                Professor_Surname = entity.Professor_Surname,
                Professor_Office = entity.Professor_Office,
                Professor_Wage = entity.Professor_Wage
            };
        }

        public static Professor ToDTO(this ProfessorDetails entity)
        {
            if (entity is null) return null;
            return new Professor
            {
                Professor_ID = entity.Professor_Id,
                Professor_Name = entity.Professor_Name,
                Professor_Surname = entity.Professor_Surname,
                Section_ID = entity.Section_ID,
                Professor_Email = entity.Professor_Email,
                Professor_HireDate = entity.Professor_HireDate,
                Professor_Office = entity.Professor_Office,
                Professor_Wage = entity.Professor_Wage
            };
        }
    }
}
