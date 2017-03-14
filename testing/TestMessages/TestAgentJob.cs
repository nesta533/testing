using Newtonsoft.Json;
using NLog;

namespace TestMessages
{
    class TestAgentJob
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static TestAgentJob TestJob2TestAgentJob(TestJob testjob)
        {
            string jobstring = testjob.Job;
            if (string.IsNullOrEmpty(jobstring))
            {
                logger.Error("The test Job content is null.");
                return null;
            }

            try
            {
                var testAgentJob = JsonConvert.DeserializeObject<TestAgentJob>(jobstring);
                return testAgentJob;

            }
            catch(JsonException ex)
            {
                logger.Error("Cannot deserialize the test job {0} to TestAgentJob with json exception {1}.", 
                    jobstring, ex.Message);
                return null;
            }
            
        }

        public string AgentName { get; set; }
        public string Arguments { get; set; }
    }
}
