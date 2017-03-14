using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMessages
{
    public class TestJobResult
    {
        public TestJobResult(TestJob job)
        {
            Job = job;
        }

        public TestJob Job { get; private set; }

        public UInt32? NumberofTestCases { get; set; }

    }
}
