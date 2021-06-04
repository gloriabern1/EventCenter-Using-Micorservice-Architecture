using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventComponentTest
{
   public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string _GoodFileName;
        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["Goodfilename"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
