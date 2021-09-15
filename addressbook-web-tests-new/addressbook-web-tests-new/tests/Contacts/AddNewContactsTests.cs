using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContactsTests : AuthTestBase
    {
      
        [Test]
        public void AddNewContact()
        {
                                 
            ContactData contact = new ContactData("Zub", "Iryna");

            List<ContactData> oldListContacts = app.NewContact.GetContactList();

            app.NewContact.CreateContact(contact);

            List<ContactData> newListContacts = app.NewContact.GetContactList();
            
            Assert.AreEqual(oldListContacts.Count+1, newListContacts.Count);
            
            Console.WriteLine(newListContacts.Count);

        }
     }
}
