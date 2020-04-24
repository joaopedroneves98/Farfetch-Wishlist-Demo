namespace Infrastructure.CrossCutting.Messaging
{
    using System.Threading.Tasks;

    public interface IServiceBus
    {
        Task PublishAsync<T>(T message) where T : class;
    }
}