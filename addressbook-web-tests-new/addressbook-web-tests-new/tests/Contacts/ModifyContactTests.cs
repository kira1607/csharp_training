using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
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

            app.NewContact.ModifyContact(newContactData);
        }
    }
}
