using AYellowpaper;
using Card;
using Controllers;
using Factories;
using Intarfaces;
using ScriptableObjects;
using Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public sealed class SceneLifeTimeScope: LifetimeScope
    {
        [RequireInterface(typeof(ICardsStyle))]
        public ScriptableObject CardsStyle;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(CardsStyle).AsImplementedInterfaces();
            builder.Register<StartCardInitializer>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardDataFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardAnimations>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<BankCardsController>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<GameFieldCardsController>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardGroupsFinder>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardsCombinationGenerator>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardsCombinationProvider>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardsDataProvider>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<OverlapCardsFinder>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<BankCardsInitializer>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<GameFieldCardsInitializer>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<CardsStyleProvider>(Lifetime.Scoped).AsImplementedInterfaces();
            
        }
    }
}