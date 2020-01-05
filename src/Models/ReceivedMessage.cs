using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet;

namespace MQTTrace.Models
{
    public class ReceivedMessage
    {
        public int ReceptionIndex { get; set; }
        public DateTime ReceptionTimestamp { get; set; }
        public MqttApplicationMessage Message { get; set; }
        public string ClientId { get; set; }
    }
}
