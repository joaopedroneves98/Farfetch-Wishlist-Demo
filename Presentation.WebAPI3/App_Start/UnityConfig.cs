namespace Presentation.WebAPI3
{
    using Application.Services.Implementations;
    using Application.Services.Interfaces;
    using Data.Repository.Interfaces.Repositories;
    using Data.Repository.Models;
    using Data.Repository.Repositories;
    using Infrastructure.CrossCutting;
    using Infrastructure.CrossCutting.Messaging;
    using Presentation.WebAPI3.MessagingConfig;
    using Producer;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using Unity;
    using Unity.Lifetime;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            var kafkaConfig = new KafkaConfiguration
            {
                Address = "localhost:9092",
                OwnerTopicName = "wishlist_owner"
            };

            container.RegisterInstance<IKafkaConfiguration>(kafkaConfig);
            container.RegisterType<DbContext, WishlistContext>();
            container.RegisterType<IOwnerRepository, OwnerRepository>();
            container.RegisterType<IOwnerService, OwnerService>();
            container.RegisterType<IWishlistRepository, WishlistRepository>();
            container.RegisterType<IWishlistService, WishlistService>();
            container.RegisterType<IServiceBus, MassTransitServiceBus>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMessagingInitializer, RabbitMqMessagingInitializer>(new ContainerControlledLifetimeManager());
            container.RegisterType<IOwnerProducer, OwnerProducer>();
        }
    }
}