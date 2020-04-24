namespace Infrastructure.CrossCutting
{
    public interface IKafkaConfiguration
    {
        string Address { get; set; }

        string OwnerTopicName { get; set; }
    }
}
