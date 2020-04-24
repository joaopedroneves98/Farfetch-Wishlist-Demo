namespace Infrastructure.CrossCutting
{
    public class KafkaConfiguration : IKafkaConfiguration
    {
        public string Address { get; set; }
        public string OwnerTopicName { get; set; }
    }
}
