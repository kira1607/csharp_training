using System;
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
                                 
            ContactData contact = new ContactData("Test", "User");

            app.NewContact.CreateContact(contact);
        }
     }
}
