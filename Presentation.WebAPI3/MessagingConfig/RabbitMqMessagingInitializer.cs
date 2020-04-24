namespace Presentation.WebAPI3.MessagingConfig
{
    using System;
    using System.Threading;
    using MassTransit;
    using Unity;

    public class RabbitMqMessagingInitializer : IMessagingInitializer
    {
        private readonly IUnityContainer container;

        private BusHandle busHandle;

        private IBusControl bus;

        public RabbitMqMessagingInitializer(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            try
            {
                var busUrl = new Uri("rabbitmq://localhost/");
                var userName = "guest";
                var password = "admin";

                var defaultQueueName = "WishList.ConsumerQueue";
                var consumerQueueName = "WishList.DefaultQueue";


                this.bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(
                        busUrl,
                        hostConfig =>
                        {
                            hostConfig.Username(userName);
                            hostConfig.Password(password);
                        });

                    cfg.OverrideDefaultBusEndpointQueueName(defaultQueueName);

                    cfg.ReceiveEndpoint(
                        host,
                        consumerQueueName,
                        endPoint =>
                        {
                            endPoint.LoadFrom(this.container);
                        });

                });

                this.container.RegisterInstance(bus);
                this.container.RegisterInstance<IBus>(bus);

                var cancelSource = new CancellationTokenSource();
                cancelSource.CancelAfter(10000);

                var tStart = bus.StartAsync(cancelSource.Token);
                tStart.Wait(cancelSource.Token);
                this.busHandle = tStart.Result;
            }
            catch (Exception ex)
            {
                // log
                throw;
            }
        }
    }
}