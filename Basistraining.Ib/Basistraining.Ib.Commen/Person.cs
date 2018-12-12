using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basistraining.Ib.DataAcess;

namespace Basistraining.Ib.Commen
{
    public class Person
    {
        public int personId { get; set; }
        public String fullName { get; set; }
        public String lastname { get; set; }
        public String firstname { get; set; }

        public List<Person> GetPerson()
        {
            List<Person> personen = new List<Person>();
            using(var contex= new SchoolEntities())
            {
                foreach(var p in contex.Person.ToList())
                {
                    personen.Add(MapperToCommen(p));
                }
            }
            return personen;
        }

        public Person GetOnePerson(int id)
        {
            Person person = new Person();
            using (var contex = new SchoolEntities())
            {
               person= MapperToCommen(contex.Person.Find(id));
            }
            return person;
        }
        public Person Save()
        {
            Person person;
            using (var context = new SchoolEntities())
            {       
                DataAcess.Person p = MapperToDataAcess(this);
                context.Person.AddOrUpdate(p);
                var id = context.SaveChanges();
                person = MapperToCommen(context.Person.Find(id));

            }
            return person;
            
        }

        public void Remove(int id)
        {
            using (var contex = new SchoolEntities())
            {
                contex.Person.Remove(contex.Person.Find(id));
                contex.SaveChanges();

            }
        }
        private Person MapperToCommen(Basistraining.Ib.DataAcess.Person p)
        {
            return new Person()
            { 
               personId = p.PersonID,
                fullName = p.LastName + " " + p.FirstName,
                lastname = p.LastName,
                firstname = p.FirstName,

            };

        }
        private DataAcess.Person MapperToDataAcess(Person p)
        {
            return new DataAcess.Person() {
                PersonID = p.personId,
                FirstName = p.firstname,
                LastName = p.lastname
            };
        }
                   

    }
}
