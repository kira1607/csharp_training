using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContacts : TestBase
    {
      
        [Test]
        public void AddNewContact()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            AddContact();
            ContactData contact = new ContactData("Test", "User");
            SubmitNewContact();
            Return();
        }
       
    }
}
