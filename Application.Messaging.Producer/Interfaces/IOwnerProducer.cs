namespace Producer
{
    using System.Threading.Tasks;
    using Application.DTO;
    public interface IOwnerProducer
    {
        Task SendMessageAsync(OwnerDTO owner);
    }
}
