using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.AMQP.ConnectAMQPBroker
{
    public class Instance
    {
        //public static Instance getInstance()
        //{
        //    return AMQPInstance;
        //}

        public Instance(string userID, string userPasswords, string hostname)
        {
            UserID = userID;
            UserPasswords = userPasswords;
            HostName = hostname;

            try
            {
                using (var connection = ConnectBroker())
                using (var channel = connection.CreateModel())
                {
                    AMQPInstance = channel;
                    System.Diagnostics.Debug.Print("AMQP Instance Created");
                }
            }
            catch
            {
                Console.WriteLine("[error] AMQP Broker Conneciton Instantiation Failed");
                TestInstance = "heyyy";
            }
        }

        private string UserID;
        private string UserPasswords;
        private string HostName;

        public static IModel AMQPInstance = null;
        public static string TestInstance = "null";

        private IConnection ConnectBroker()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" , UserName = UserID, Password = UserPasswords};
            IConnection conn = factory.CreateConnection();
            return conn;
            //https://www.rabbitmq.com/dotnet-api-guide.html
        }
    }
}