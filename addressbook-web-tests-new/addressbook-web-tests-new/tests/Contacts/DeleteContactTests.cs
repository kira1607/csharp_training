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

            List<ContactData> oldListContacts = app.NewContact.GetContactList();

            app.NewContact.RemoveContact(0);

            Assert.AreEqual(oldListContacts.Count - 1, app.NewContact.GetContactCount());


            List<ContactData> newListContacts = app.NewContact.GetContactList();
            oldListContacts.RemoveAt(0);
            Assert.AreEqual(oldListContacts, newListContacts);
          
            
            Console.WriteLine(oldListContacts.Count);

        }

       
    }
}
