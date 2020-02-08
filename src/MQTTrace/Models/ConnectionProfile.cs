using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet.Client.Options;

namespace MQTTrace.Models
{
    public class ConnectionProfile
    {
        public int ConnectionProfileId { get; set; }
        public string ProfileName { get; set; }
        public IMqttClientOptions ClientOptions { get; set; }
    }
}
