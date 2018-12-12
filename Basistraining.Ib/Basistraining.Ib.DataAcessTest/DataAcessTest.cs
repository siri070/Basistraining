using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basistraining.Ib.DataAcess;
using System.Linq;

namespace Basistraining.Ib.DataAcessTest
{
    [TestClass]
    public class DataAcessTest
    {
        [TestMethod]
        public void DataBaseConnetion()
        {
            using(var context = new SchoolEntities())
            {
               Assert.IsNotNull(context);

                var p = context.Person.ToList();

                Assert.IsNotNull(p.Count);
            }
        }
    }
}
