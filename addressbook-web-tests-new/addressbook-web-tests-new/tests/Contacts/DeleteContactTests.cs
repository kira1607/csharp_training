﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 


namespace WebAddressbookTests
    {

    [TestFixture]
    public class DeleteContactTests : TestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            {
                app.NewContact.RemoveContact(1);

            }
        }
    }
}
