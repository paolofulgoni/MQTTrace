using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MQTTrace.Services
{
    public interface IMqttService
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        bool Connected { get; }
    }

    public class MqttService : IMqttService
    {
        private readonly IMqttClient mqttClient;
        private readonly IMqttClientOptions mqttClientOptions;

        public MqttService(IMqttClient mqttClient)
        {
            this.mqttClient = mqttClient;

            mqttClientOptions = new MqttClientOptionsBuilder()
                .WithClientId("MQTTrace")
                .WithTcpServer("test.mosquitto.org")
                .WithCleanSession()
                .Build();
        }

        public async Task ConnectAsync()
        {
            await mqttClient.ConnectAsync(mqttClientOptions);
        }

        public async Task DisconnectAsync()
        {
            await mqttClient.DisconnectAsync();
        }

        public bool Connected => mqttClient.IsConnected;
    }
}
