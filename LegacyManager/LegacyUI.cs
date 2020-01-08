using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegacyManager
{
    public partial class LegacyUI : Form
    {
        public LegacyUI()
        {
            InitializeComponent();
            changeText();
        }

        private void CheckConnectionWithBroker()
        {
            //let say done
            //when done, update UI 
            Views.OverviewView.ConnectionPanel brokerStatus = new Views.OverviewView.ConnectionPanel();
            brokerStatus.obj.C2.IsConnected = true;
            //brokerStatus.IsConnected = true;
            //brokerStatus.LastCheck = "currenttime";
        }

        private void LegacyUI_Load(object sender, EventArgs e)
        {
            //amqpIntance.Send();
            //amqpIntance.ReadFile();

            /* 
             * 1. check if amqp broker is up
             * 2. if list of required queues are not populated, create them 
             * 2a. pubs and subs 
             * 3. Heartbeat listener instance up
               
             */

            /* */
            Task.Run(() =>
            {
                try
                {
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    var connection = factory.CreateConnection();
                    var channel = connection.CreateModel();
                    channel.ExchangeDeclare(exchange: "test", type: ExchangeType.Topic);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName, exchange: "test", routingKey: "hello");

                    Console.WriteLine(" [*] Waiting for logs.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] {0}", message);
                    };
                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                }
                catch
                {
                    Console.WriteLine("Error Sub");
                }

            });
        }

        /* UI Binding Codes */
        public void changeText()
        {
            lblOverviewURAPubStatus.Text = ":?????????";
        }

        private void UpdateUI()
        {

        }
    }
}
