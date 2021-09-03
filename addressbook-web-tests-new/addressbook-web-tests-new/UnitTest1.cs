using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;


namespace addressbook_web_tests_new

{
    [TestClass]
    public class UnitTest1

    {
        [TestMethod]

        public void TestMethod()
        {
            string[] s = new string[] { "Say", "something" };

            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");

            }
        }
    }
}


