using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
    {

    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.NewContact.AddNewContactIfNotExists();

            app.NewContact.RemoveContact(1);
            
        }

       
    }
}
