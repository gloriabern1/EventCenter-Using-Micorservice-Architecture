using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GloriaEvent.web.Services;
using System.IO;

namespace EventComponentTest.EventEndpoints
{
    [TestClass]
    public class GetEventByIdTest : TestBase
    {
      
        private const string badFileName = @"C:\Users\Onyinye.okeke\source\repos\GloriaEvetCenter\EventComponent.proto";
      
        [ClassInitialize()]
       public static void ClassInitialize(TestContext tc)
        {
            //Method to run before all other test methods are run in the class
            tc.WriteLine("In ClassInitialize() method");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //Remove all test files or documents used in completing all method test in this class
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In testinitialize method");

            if (TestContext.TestName.StartsWith("FileDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating file: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some test");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In testcleanup method");

            if (TestContext.TestName.StartsWith("FileDoesExist"))
            {
            //DElete file
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }




        [TestMethod]
        public void FileDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine(@"Checking file "+ _GoodFileName);
            //Act
            fromCall = fp.FileExists(_GoodFileName);

            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;
            //Act
            fromCall = fp.FileExists(badFileName);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileisNUllorEmpty_UsingAttributes()
        {
            //Arrange
            FileProcess fp = new FileProcess();
           
            //Act
           fp.FileExists("");

            //Assert
            //Since we are expecting an exception
        
        }
        [TestMethod]
        public void FileisNUllorEmpty_UsingTryCatch()
        {
            //Arrange
            FileProcess fp = new FileProcess();
         
            //Act
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                return;
            }
            //Assert
            Assert.Fail("Call to fileExists() did not throw an argument null exception");
        }

     
    }
}
