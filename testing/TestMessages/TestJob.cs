using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMessages
{
    public class TestJob : IEquatable<TestJob>
    {
        public TestJob(string job)
        {
            Job = job;
        }

        public string Job { get; private set; }


        public bool Equals(TestJob other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
