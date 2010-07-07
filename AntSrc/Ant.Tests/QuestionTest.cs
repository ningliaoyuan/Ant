using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ant.DB;
using Ant.Models.Questions;

namespace Ant.Tests
{
    /// <summary>
    /// Summary description for QuestionTest
    /// </summary>
    [TestClass]
    public class QuestionTest
    {
        public QuestionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAddQuestion()
        {
            using (var s = new MongoSession())
            {
                Question q = new Question();
                q.Content = "ContentTest123";
                q.Ask = "Ask";
                q.Number = 100;
                q.Rate = 3;
                q.Source = "GWD";
                
                s.Add(q);
            }

            using (var s = new MongoSession())
            {
                var q2 = s.Query<Question>().FirstOrDefault(q=> q.Number==100);
                Assert.IsNotNull(q2);
                Assert.AreEqual(q2.Content, "ContentTest123");
            }
            using (var s = new MongoSession())
            {
                s.GetCollection<Question>().Delete(new { Number = 100 });
            }
            using (var s = new MongoSession())
            {
                var q2 = s.Query<Question>().FirstOrDefault(q => q.Number == 100);
                Assert.IsNull(q2);
            }
        }
    }
}
