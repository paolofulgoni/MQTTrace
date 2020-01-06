using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet;

namespace MQTTrace.Models
{
    public class ReceivedMessage
    {
        public int MessageId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ClientId { get; set; }
        public MqttApplicationMessage Message { get; set; }
    }
}
