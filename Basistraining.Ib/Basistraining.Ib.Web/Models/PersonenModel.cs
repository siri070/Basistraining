using System.Collections.Generic;
using Basistraining.Ib.Commen;
using System.ComponentModel.DataAnnotations;

namespace Basistraining.Ib.Web.Models
{
    public class PersonenModel
    {
        public List<Person> personen { get; set; }
        public Person person;
        public PersonenModel()
        {
            person = new Person();
            personen = person.GetPerson();
        }

        public void Save()
        {
            person.Save();
        }
        public void Remove(int id)
        {
            person.Remove(id);
        }

    }
}
