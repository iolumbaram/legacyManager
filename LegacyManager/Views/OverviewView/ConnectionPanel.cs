using LegacyManager.Models.Overview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManager.Views.OverviewView
{
    public class ConnectionPanel
    {
        public ConnectionPanel()
        {
            //public ModelType modelType = new ModelType();
        }

        public enum ModelType { C2,Broker };

        public ConnectionModel obj = new ConnectionModel();

        //public bool IsConnected
        //{
        //    get { return obj.C2.IsConnected; }
        //}

        //public string LastCheck;

        //public string lblC2StatusLastCheck
        //{
        //    //this.Obj.C2.IsConnected = 
        //}
    }
}
