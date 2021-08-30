using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests

    {
    [TestFixture]

    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
    {
            GroupData newData = new GroupData("This is new group");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);

        }
    }

}
