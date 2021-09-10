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


        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
                                 
                SelectGroup(p);
                RemoveGroup();
                ReturntoGroupPage();
                return this;
           
        }
              

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            
            SelectGroup(p);
            InitGroupModification();
            FillGroupFormNew(newData);
            SubmitGroupModification();
            ReturntoGroupPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groups.Add(new GroupData(element.Text));
                }
                return groups;
          }



        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
                {
                    driver.FindElement(By.Name("delete")).Click();
                    return this;
                }

        public GroupHelper SelectGroup(int index)
                { 
                driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
                    return this;
                }

        public GroupHelper AddNewGroupIfNotExists()
        {
            if (IsElementPresent(By.TagName("span"))==false)
            {
                GroupData group = new GroupData("test1");
                group.Header = "test2";
                group.Footer = "test3";
                Create(group);
                return this;

            }
            return null;
        }

        public GroupHelper Submit()
                {
                    driver.FindElement(By.Name("submit")).Click();
                    return this;
                }

        public GroupHelper FillGroupForm(GroupData group)
                 
                {
                Type(By.Name("group_name"), group.Name);
                Type(By.Name("group_header"), group.Header);
                Type(By.Name("group_footer"), group.Footer);

            
                return this;
                }


        public GroupHelper FillGroupFormNew(GroupData newData)

        {
            Type(By.Name("group_name"), newData.Name);
            Type(By.Name("group_header"), newData.Header);
            Type(By.Name("group_footer"), newData.Footer);


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
   
