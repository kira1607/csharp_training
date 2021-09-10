using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.AddNewGroupIfNotExists();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

                app.Groups.Remove(0);

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);
            }
          
          }
               
        }
    
