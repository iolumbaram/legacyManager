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
            LegacyManagerService.Class1 hello = new LegacyManagerService.Class1();
            hello.printHello();

            LegacyManagerService.Connections.AMQP.ConnectAMQPBroker amqpIntance = new LegacyManagerService.Connections.AMQP.ConnectAMQPBroker();
            
            //amqpIntance.Send();
            amqpIntance.ReadFile();
        }
    }
}
