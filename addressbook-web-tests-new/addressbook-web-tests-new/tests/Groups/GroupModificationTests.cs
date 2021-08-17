using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests

    {
    [TestFixture]

    public class GroupModificationTests: TestBase
    {
        [Test]
        public void GroupModificationTest()
    {
            GroupData newData = new GroupData("test11");
            newData.Header = "test22";
            newData.Footer = "test33";

            app.Groups.Modify(1, newData);

        }
    }

}
