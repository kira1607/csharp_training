using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContacts : TestBase
    {
      
        [Test]
        public void AddNewContact()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.AddContact();
            ContactData contact = new ContactData("Test", "User");
            app.Groups.SubmitNewContact();
            app.Groups.Return();
        }
       
    }
}
