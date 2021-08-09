using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper: HelperBase

    {

        public GroupHelper(IWebDriver driver):
            base(driver)
        
        {
        }
           
                
                public void RemoveGroup()
                {
                    driver.FindElement(By.Name("delete")).Click();
                }

                public void SelectGroup(int index)
                {
                    driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
                }


                public void Submit()
                {
                    driver.FindElement(By.Name("submit")).Click();
                }

                public void FillGroupForm(GroupData group)
                {
                    driver.FindElement(By.Name("group_name")).Clear();
                    driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
                    driver.FindElement(By.Name("group_name")).Clear();
                    driver.FindElement(By.Name("group_name")).SendKeys(group.Header);
                    driver.FindElement(By.Name("group_name")).Clear();
                    driver.FindElement(By.Name("group_name")).SendKeys(group.Footer);
                }

                public void InitGroupCreation()
                {
                    driver.FindElement(By.Name("new")).Click();
                }

                public void Return()
                {
                    driver.FindElement(By.LinkText("Logout")).Click();
                }

                public void SubmitNewContact()
                {
                    driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
                }

                public void ContactData(ContactData contact)
                {
                    driver.FindElement(By.Name("firstname")).Click();
                    driver.FindElement(By.Name("firstname")).Clear();
                    driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
                    driver.FindElement(By.Name("lastname")).Clear();
                    driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
                }

                public void AddContact()
                {
                    driver.FindElement(By.LinkText("add new")).Click();
                }
            }
        }
   
