using Ant.Models.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ant.Tests
{
    /// <summary>
    ///This is a test class for EncryptorTest and is intended
    ///to contain all EncryptorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EncryptorTest
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
        ///A test for Encrypt
        ///</summary>
        [TestMethod()]
        public void EncryptTest()
        {
            string encryptString = "FooString|2010-07-01";
            string actual;
            actual = Encryptor.Encrypt(encryptString);
            Assert.AreNotEqual(encryptString, actual);
        }

        /// <summary>
        ///A test for Decrypt
        ///</summary>
        [TestMethod()]
        public void DecryptTest()
        {
            string encryptString = "FooString|2010-07-01";

            string decryptString = Encryptor.Encrypt(encryptString);
            string actual;
            actual = Encryptor.Decrypt(decryptString);
            Assert.AreEqual(encryptString, actual);
        }
    }
}
