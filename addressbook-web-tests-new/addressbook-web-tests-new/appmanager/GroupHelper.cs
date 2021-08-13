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

        public GroupHelper(ApplicationManager manager):
            base(manager)
        
        {
        }

                public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            Submit();
            ReturntoGroupPage();
            return this;

        }
        public GroupHelper Remove(int v)
        {
           manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturntoGroupPage();
            return this;
        }
        public GroupHelper RemoveGroup()
                {
                    driver.FindElement(By.Name("delete")).Click();
                    return this;
                }

                public GroupHelper SelectGroup(int index)
                {
                    driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
                    return this;
                }


                public GroupHelper Submit()
                {
                    driver.FindElement(By.Name("submit")).Click();
                    return this;
                }

                public GroupHelper FillGroupForm(GroupData group)
                {
                    driver.FindElement(By.Name("group_name")).Clear();
                    driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
                    driver.FindElement(By.Name("group_name")).Clear();
                    driver.FindElement(By.Name("group_name")).SendKeys(group.Header);
                    driver.FindElement(By.Name("group_name")).Clear();
                    driver.FindElement(By.Name("group_name")).SendKeys(group.Footer);
                    return this;
                }

                public GroupHelper InitGroupCreation()
                {
                    driver.FindElement(By.Name("new")).Click();
            return this;
                }

                public GroupHelper ReturntoGroupPage()
                {
                driver.FindElement(By.LinkText("group page")).Click();
                return this;
                
                }
                public GroupHelper Return()
                {
                    driver.FindElement(By.LinkText("Logout")).Click();
            return this;
                }

               
        

    }
}
   
