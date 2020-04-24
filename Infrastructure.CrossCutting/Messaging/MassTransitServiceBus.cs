namespace Infrastructure.CrossCutting.Messaging
{
    using System.Threading.Tasks;
    using MassTransit;
    using System;

    public class MassTransitServiceBus : IServiceBus
    {
        private readonly IBusControl bus;

        public MassTransitServiceBus(IBusControl busControl)
        {
            this.bus = busControl;
        }

        public async Task PublishAsync<T>(T message) where T : class
        {
            try
            {
                await this.bus.Publish(
                    message,
                    message.GetType()).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                // log
                throw;
            }
        }
    }
}