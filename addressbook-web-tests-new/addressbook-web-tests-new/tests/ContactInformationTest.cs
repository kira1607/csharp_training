using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest:AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
           ContactData fromTable = app.NewContact.GetContactInformationFromTable(0);
           ContactData fromForm = app.NewContact.GetContactInformationFromEditForm(0);

            // VERIFICATION

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}
