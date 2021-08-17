using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert;
       

        public ContactHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        

        public ContactHelper CreateContact(ContactData contact)
        {
            AddContact();
            AddContactData(contact);
            SubmitNewContact();
            Return();

            return this;

        }

        public ContactHelper ModifyContact(ContactData newContactData)
        {
            ChooseContact();
            AddContactData(newContactData);
            UpdateModification();
            Return();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            ChooseContact();
            DeleteContact();
            Return();

            return this;
        }

        public ContactHelper DeleteContact()
        
            {
                acceptNextAlert = true;
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));



            return this;
        }
    
    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }



    public ContactHelper UpdateModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ChooseContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.Id(11.ToString())).Click();
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();

            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper AddContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }

        public ContactHelper AddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper Return()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        
        
    }
}
   
