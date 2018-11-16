using DependancyInjectionExample.Views;
using System;
using DependancyInjectionExample.Controllers;
using DependancyInjectionExample.Models;

namespace DependancyInjectionExample
{
    public class Program
    {
        /// <summary>
        /// This is a simple implementation of Dependancy Injection showing how a "Potion" is "drunken" by a "Player"
        /// just using general information any RPG would have, as its easy to visualize.
        ///
        /// Using the Potion injector we choose a Potion object to consume.
        /// Usually more logic would be implemented to decide which bit of logic to choose from.
        /// Dependacy Injection can even be used to implement a factory to provide additional functionality.
        /// But, after we choose our object to consume we pass it to PlayerEntity to be constructed with.
        /// When we run Drink, it has YggPotion's functionality and will recover half of the players health and mana.
        ///
        /// This also includes a small example of implementing Lazy loading using the Lazy keyword.
        /// In this implementation it offers little to no performance enhancements. If we were using more complex objects
        /// we could Lazy load the areas that are either not accessed frequently or that are quiet large, and this would
        /// give us the performance increase we'd be looking for.
        /// </summary>
        public static void Main()
        {
            var potion = new Lazy<Potion>();
            var potionToConsume = potion.Value.GetRandomPotion();

            var player = new Lazy<PlayerEntity>(() => new PlayerEntity(potionToConsume)
            {
                PlayerName = "Maximillion",

                MaximumHealth = 500,
                MaximumMana = 400,

                Health = 52,
                Mana = 333,

                HealthRecoveryMultiplier = 1.33,
                ManaRecoveryMultiplier = 1.1
            });

            Console.WriteLine($"Player: Maximillion \t [{player.Value.Health}/{player.Value.MaximumHealth}]HP \t [{player.Value.Mana}/{player.Value.MaximumMana}]MP");

            Console.WriteLine(player.Value.UsedItem());
            player.Value.Drink();

            Console.WriteLine($"Player: {player.Value.PlayerName} \t {player.CurrentHealth()} \t {player.CurrentMana()}");
            Console.ReadLine();
        }
    }
}