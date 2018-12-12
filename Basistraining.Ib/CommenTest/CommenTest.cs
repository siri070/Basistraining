using System;
using Basistraining.Ib.DataAcess;
using Basistraining.Ib.Commen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CommenTest
{
    [TestClass]
    public class CommenTest
    {   
        public Basistraining.Ib.Commen.Person person = new Basistraining.Ib.Commen.Person();
        [TestInitialize]
        public void BeforeTest()
        {
            person.firstname = "Muster";
            person.lastname = "Muster";
            
        }
        [TestMethod]
        public void Save()
        {
           
            var personAdd = new Basistraining.Ib.Commen.Person();
            using (var context = new SchoolEntities())
            {
                Assert.IsNotNull(context);

               var p = context.Person.ToList();
               int maxId = p.Count() +1;
               person.personId = maxId;
               personAdd= person.Save();
               Assert.IsNotNull(personAdd);
            }
            
        }
        //Update objekt laden Namen->ändern überprüfen ob geändert
        [TestMethod]
        public void Update()
        {
            using (var context = new SchoolEntities())
            {
                Assert.IsNotNull(context);

                var p = context.Person.ToList();
                String firstnameBefore = person.firstname;
                person.firstname = "Anna";
                Basistraining.Ib.Commen.Person changedPerson = person.Save();

                Assert.AreEqual(changedPerson.firstname, "Anna");
                

            }

        }
        [TestMethod]
        //hinzufügen und wieder löschen, prüfen ob id noch vorhanden
        public void Remove()
        {
            using (var context = new SchoolEntities())
            {
                Assert.IsNotNull(context);

                var p = context.Person.ToList();
                
                int maxId = p.Count();
                person.Remove(maxId);
                Assert.AreEqual(maxId, p.Count());


            }
        }
        //liste --> länge 
    }
}
