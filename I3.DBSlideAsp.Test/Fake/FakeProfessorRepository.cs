using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3.DBSlideAsp.Test.Fake
{
    public class FakeProfessorRepository : IRepository<Professor>
    {
        List<Professor> lp = new List<Professor>();
        public FakeProfessorRepository()
        {
            lp.Add(new Professor() { Professor_ID=1, 
                  Professor_Email="test@test.be"
                , Professor_Name="Mike",
             Professor_HireDate= new DateTime(1985,2,2),
             Professor_Office=1,
             Professor_Surname="LeFou",
             Professor_Wage=456,
            Section_ID=1});
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Professor Get(int id)
        {
            return lp.SingleOrDefault(p => p.Professor_ID == id);
        }

        public IEnumerable<Professor> Get()
        {
            throw new NotImplementedException();
        }

        public int Insert(Professor entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Professor entity)
        {
            throw new NotImplementedException();
        }
    }
}
