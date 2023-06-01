using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SaleCartFunction
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("my-queue-items", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        //public static void Run([QueueTrigger("my-queue-items")] string myQueueItem, TraceWriter log)

        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }

}
