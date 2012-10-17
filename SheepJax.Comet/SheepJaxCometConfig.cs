using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SheepJax.Comet.Buses;

namespace SheepJax.Comet
{
    public static class SheepJaxCometConfig
    {
        public static ICommandBus PollingCommandBus { get; set; }

        static SheepJaxCometConfig()
        {
            PollingCommandBus = new InProcCommandBus();
        }
    }
}
