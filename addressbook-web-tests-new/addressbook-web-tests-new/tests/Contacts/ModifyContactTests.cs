using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModifyContactTests: AuthTestBase

    {
        [Test]

        public void ModifyContactTest()
        {
            ContactData newContactData = new ContactData("Something new", null);
            
            app.NewContact.AddNewContactIfNotExists();
            
            List<ContactData> oldListContacts = app.NewContact.GetContactList();

            app.NewContact.ModifyContact(newContactData);

            List<ContactData> newListContacts = app.NewContact.GetContactList();

            oldListContacts[0].LastName = newContactData.LastName;

            oldListContacts.Sort();
            newListContacts.Sort();

            Assert.AreEqual(oldListContacts, newListContacts);

            Console.WriteLine(oldListContacts.Count);
        }
    }
}
