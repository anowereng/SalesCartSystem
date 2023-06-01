using System;
using Azure.Storage.Queues;

namespace SaleCartFunction
{
    public class QuueueClient
    {
        //-------------------------------------------------
        // Create a message queue
        //-------------------------------------------------
        public bool CreateQueue(string queueName)
        {
            try
            {
                // Get the connection string from app settings
                string connectionString = "UseDevelopmentStorage=true";//ConfigurationManager.AppSettings["StorageConnectionString"];

                // Instantiate a QueueClient which will be used to create and manipulate the queue
                QueueClient queueClient = new QueueClient(connectionString, queueName);

                // Create the queue
                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    Console.WriteLine($"Queue created: '{queueClient.Name}'");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n\n");
                Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }
        //-------------------------------------------------
        // Insert a message into a queue
        //-------------------------------------------------
        public void InsertMessage(string queueName, string message)
        {
            // Get the connection string from app settings
            string connectionString = "UseDevelopmentStorage=true";//ConfigurationManager.AppSettings["StorageConnectionString"];

            // Instantiate a QueueClient which will be used to create and manipulate the queue   
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                // Send a message to the queue
                queueClient.SendMessage(message);
            }

            Console.WriteLine($"Inserted: {message}");
        }


    }

}
