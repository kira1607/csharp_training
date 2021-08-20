using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ModifyContactTests: TestBase
    
    {
        [Test]

        public void ModifyContactTest()
        {
            ContactData newContactData = new ContactData("Something new", null);

            app.NewContact.ModifyContact(1, newContactData);
        }
    }
}
