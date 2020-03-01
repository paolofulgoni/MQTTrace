using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;
using MQTTrace.Models;

namespace MQTTrace.Services
{
    public interface IUserSettingsService
    {
        List<ConnectionProfile> GetConnectionProfiles();
    }

    public class UserSettingsService : IUserSettingsService
    {
        public List<ConnectionProfile> GetConnectionProfiles()
        {
            var mosquittoTestUnencryptedV5 = new MqttClientOptionsBuilder()
                .WithTcpServer("test.mosquitto.org", 1883)
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithClientId("MQTTrace")
                .WithCleanSession()
                .Build();

            var hiveMqPublicUnencryptedV5 = new MqttClientOptionsBuilder()
                .WithTcpServer("broker.hivemq.com", 1883)
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithClientId("MQTTrace")
                .WithCleanSession()
                .Build();

            return new List<ConnectionProfile>
            {
                new ConnectionProfile
                {
                    ConnectionProfileId = 1,
                    ProfileName = "Mosquitto Test (unencrypted)",
                    ClientOptions = mosquittoTestUnencryptedV5,
                },
                new ConnectionProfile
                {
                    ConnectionProfileId = 2,
                    ProfileName = "HiveMQ Public (unencrypted)",
                    ClientOptions = hiveMqPublicUnencryptedV5,
                }
            };
        }
    }
}
