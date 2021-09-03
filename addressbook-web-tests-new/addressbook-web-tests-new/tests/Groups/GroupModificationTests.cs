using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

    {
    [TestFixture]

    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
    {
            GroupData newData = new GroupData("This is THE new group");
            newData.Header = null;
            newData.Footer = null;

            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            //List<GroupData> newGroups = app.Groups.GetGroupList();

            //oldGroups[0].Name = newData.Name;
            //oldGroups.Sort();
            //newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);

        }
    }

}
