using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventComponentTest
{
    [TestClass]
    public class FileTestInitialization
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {

            //This is where you add test files or document eg, json files for test
            tc.WriteLine("In Assembly initialize method");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //cleanup after all test have been completed in the assembly
        }
    }
}
