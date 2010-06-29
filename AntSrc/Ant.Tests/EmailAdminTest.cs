using Ant.Models.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ant.Tests
{
    
    
    /// <summary>
    ///This is a test class for EmailAdminTest and is intended
    ///to contain all EmailAdminTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmailAdminTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SendPassword
        ///</summary>
        [TestMethod()]
        public void SendPasswordTest()
        {
            string targetEmail = "ningliaoyuan@gmail.com"; // TODO: Initialize to an appropriate value
            string userName = "Lynn"; // TODO: Initialize to an appropriate value
            string password = "new password"; // TODO: Initialize to an appropriate value
            EmailAdmin.SendPassword(targetEmail, userName, password);
        }
    }
}
