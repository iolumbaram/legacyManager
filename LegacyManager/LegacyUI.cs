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
        }

        private void LegacyUI_Load(object sender, EventArgs e)
        {
            //amqpIntance.Send();
            //amqpIntance.ReadFile();

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
    }
}
