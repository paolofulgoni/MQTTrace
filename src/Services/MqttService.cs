using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MQTTrace.Services
{
    public interface IMqttService
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        bool Connected { get; }
        Task SubscribeAsync(string topic);
        List<MqttApplicationMessage> ReceivedMessages { get; }
        event Action OnMessageReceived;
    }

    public class MqttService : IMqttService
    {
        private readonly IMqttClient mqttClient;

        public MqttService(IMqttClient mqttClient)
        {
            this.mqttClient = mqttClient;

            mqttClient.UseApplicationMessageReceivedHandler(HandleApplicationMessagereceived);
        }

        public async Task ConnectAsync()
        {
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithClientId("MQTTrace")
                .WithTcpServer("test.mosquitto.org")
                .WithCleanSession()
                .Build();

            await mqttClient.ConnectAsync(mqttClientOptions);
        }

        public async Task DisconnectAsync()
        {
            await mqttClient.DisconnectAsync();
        }

        public bool Connected => mqttClient.IsConnected;

        public async Task SubscribeAsync(string topic)
        {
            await mqttClient.SubscribeAsync(topic);
        }

        public List<MqttApplicationMessage> ReceivedMessages { get; } = new List<MqttApplicationMessage>();

        private void HandleApplicationMessagereceived(MqttApplicationMessageReceivedEventArgs args)
        {
            ReceivedMessages.Add(args.ApplicationMessage);
            OnMessageReceived?.Invoke();
        }

        public event Action OnMessageReceived;
    }
}
