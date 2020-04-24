namespace Producer
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using Application.DTO;
    using Application.Messaging.Kafka.Contracts.V1.Owner;
    using Confluent.Kafka;
    using Infrastructure.CrossCutting;

    public class OwnerProducer : IOwnerProducer
    {
        private readonly IKafkaConfiguration kafkaConfiguration;

        public OwnerProducer(IKafkaConfiguration kafkaConfiguration)
        {
            this.kafkaConfiguration = kafkaConfiguration;
        }

        public async Task SendMessageAsync(OwnerDTO owner)
        {
            var ownerToSend = OwnerKafkaMapper.DTOToKafka(owner);
            if (ownerToSend == null)
            {
                Console.WriteLine("Failed to deliver message: Owner is null.");
            }

            var config = new ProducerConfig { BootstrapServers = this.kafkaConfiguration.Address };
            var topicName = this.kafkaConfiguration.OwnerTopicName;
            var json = new JavaScriptSerializer().Serialize(ownerToSend);

            using (var p = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var deliveryReport = await p.ProduceAsync(
                        topicName, new Message<string, string> { Key = ownerToSend.Id.ToString(), Value = json }).ConfigureAwait(false);
                }
                catch (ProduceException<string, string> e)
                {
                    Console.WriteLine($"failed to deliver message: {e.Message} [{e.Error.Code}]");
                }
            }
        }
    }
}
