using System;

namespace TestMessages
{
    public class TestJob : IEquatable<TestJob>
    {
        public TestJob(string job)
        {
            Job = job;
        }

        public string Job { get; private set; }
        #region Equality
        public bool Equals(TestJob other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Job == other.Job;

        }

        public override bool Equals(object obj)
        {
            //return base.Equals(obj);
            if (ReferenceEquals(null, obj) || this.GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals((TestJob)obj);
        }

        public override int GetHashCode()
        {
            return Job.GetHashCode();
        }
        #endregion

        public override string ToString()
        {
            return Job;
        }
    }
}
