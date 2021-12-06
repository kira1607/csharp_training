using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Graph;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase

    {
        public bool acceptNextAlert = true;


        public ContactHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        
        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToHomePage();

            AddContact();
            AddContactData(contact);
            SubmitNewContact();
            Return();

            return this;

        }

       

        public ContactHelper ModifyContact(ContactData newContactData)
        {
            manager.Navigator.GoToHomePage();

            //ChooseContact(p);
            EditContact();
            AddNewContactData(newContactData);
            UpdateModification();
            Return();

            return this;
        }


        public ContactHelper RemoveContact(int p)
        {
            manager.Navigator.GoToHomePage();

            ChooseContact(p);
            DeleteContact();

            return this;
        }
        
        
        private List<ContactData> contactCache = null;


        public List<ContactData> GetContactList()
        {

            if (contactCache == null)

            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement element in elements)
                {

                    IWebElement contactLN = element.FindElement(By.CssSelector("td:nth-of-type(2)"));
                    IWebElement contactFN = element.FindElement(By.CssSelector("td:nth-of-type(3)"));


                    contactCache.Add(new ContactData(contactLN.Text, contactFN.Text));

                }
            }
            return new List<ContactData>(contactCache);
        }


        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper AddNewContactIfNotExists()
        {
            
             if (IsElementPresent(By.XPath("//input[starts-with(@title, 'Select')]"))==false)
             {
                ContactData contact = new ContactData("Test-new", "User-new");
                CreateContact(contact);
                return this;

             }
            return null;
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            contactCache = null;
            return this;    
        }                             

        public ContactHelper DeleteContact()
        
            {
            acceptNextAlert = true;
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCache = null;
            
            return this;
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
            contactCache = null;
            return this;
        }

        public ContactHelper ChooseContact(int index)
        {
          
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (index+1) + "]/td/input[@type='checkbox']")).Click();

            ////tr/td/input[@name='selected[]'][" + (index+1) + "

            //tr[@name='entry'][[index+1]]/td/input[@type='checkbox']

            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper AddContactData (ContactData contact)
        {
           
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            
            return this;
        }

        public ContactHelper AddNewContactData(ContactData NewContactData)
        {

            Type(By.Name("firstname"), NewContactData.FirstName);
            Type(By.Name("lastname"), NewContactData.LastName);

            return this;
        }

        public ContactHelper AddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Return()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones

            };

           }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone

            };
            
        }

       public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
               }

        //public ContactData GetContactInfoFromTable(int index)
        //{
        //    ContactData GetContactInformationFromTable(0);

        //    return new ContactData(lastname, firstname);


        
        public ContactData GetContactInfoFromDetails(int index)
        {
            throw new NotImplementedException();
        }

        public void InitContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }
    }
    }

   
