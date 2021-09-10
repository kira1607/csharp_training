﻿using System;
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

        //public List<ContactData> GetContactList()
        //{

        //    List<ContactData> contacts = new List<ContactData>();

        //    manager.Navigator.GoToHomePage();

        //    ICollection<IWebElement> elementsFN = driver.FindElements(By.XPath("//td/input[(@name='selected[]')]/td"));
        //    ICollection<IWebElement> elementsLN = driver.FindElements(By.XPath("//td/input[(@name='selected[]')]/td/td"));

        //    //for (var i = 1; i < elementsFname.Count; i++)
        //    //{
        //    //    contacts.Add(new ContactData(elementsFname[i].Text, elementsLname[i].Text));
        //    //}

        //    //foreach (var elementFname in elementsFname)
        //    //{
        //    //    var index = elementsFname.IndexOf(elementFname);

        //    //    contacts.Add(new ContactData(elementsFname[index].Text, elementsLname[index].Text));
        //    //}

            
            
        //        //var index = elementsFN.IndexOf(elementFN);

        //        //contacts.Add(new ContactData(elementFN.Text, elementsLN[index].Text));
        //    }

        //    return contacts;
        //}
    


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
             return this;    
        }                             

        public ContactHelper DeleteContact()
        
            {
            acceptNextAlert = true;
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            
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
            return this;
        }

        public ContactHelper ChooseContact(int index)
        {
          
            driver.FindElement(By.XPath("//div/form/table/tbody/tr/td[" + index + "]/input")).Click(); 

            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper AddContactData(ContactData contact)
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
            return this;
        }

        public ContactHelper Return()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        

    }
}
   
