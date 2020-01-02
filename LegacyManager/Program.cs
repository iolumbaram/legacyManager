using LegacyManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messaging.AMQP;

namespace LegacyManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LegacyUI());

            //var host = new Startup();
            //host.Configure();

            var AMQPConnecInstance = new Messaging.AMQP.ConnectAMQPBroker.Instance("guest","guest","localhost");
            //Messaging.AMQP.ConnectAMQPBroker.Instance.AMQPInstance;
            Console.WriteLine(Messaging.AMQP.ConnectAMQPBroker.Instance.TestInstance);

            //var AMQPPublisher = new Messaging.AMQP.CreatePublisher.Publisher();
            //AMQPPublisher.CreateQueue("MOM", "simulation").Populate("somedata");
        }
    }
}
