using System;
using DependancyInjectionExample.Interfaces;
using DependancyInjectionExample.Models;

namespace DependancyInjectionExample.Controllers
{
    /// <summary>
    /// The Potion class is the injector.
    /// The respective XPotion classes beneath are the implementations Potion will provide.
    ///
    /// Potion could also be given a GetPotion() function which accepts a string and returns a potion via a case statement.
    /// </summary>
    public class Potion
    {
        public IDrinkable BluePotion() => new BluePotion();

        public IDrinkable EmptyPotion() => new EmptyPotion();

        public IDrinkable GetRandomPotion()
        {
            while (true)
            {
                var rng = new Random().Next(1, 100);

                if (rng % 7 == 0) return new RedPotion();
                if (rng % 6 == 0) return new WhitePotion();
                if (rng % 5 == 0) return new YggPotion();
                if (rng % 3 == 0) return new BluePotion();
                if (rng % 2 == 0) return new EmptyPotion();
            }
        }

        public IDrinkable RedPotion() => new RedPotion();

        public IDrinkable WhitePotion() => new WhitePotion();

        public IDrinkable YggPotion() => new YggPotion();
    }

    internal class BluePotion : IDrinkable
    {
        public string ItemName { get; set; } = "Blue Potion";

        public void Drink(PlayerEntity player)
        {
            player.Mana += (int)(120 * player.ManaRecoveryMultiplier);
        }
    }

    internal class EmptyPotion : IDrinkable
    {
        public string ItemName { get; set; } = "Empty Potion";

        public void Drink(PlayerEntity player)
        {
            Console.WriteLine("Did you just try to drink air? Boy, you crazy.");
        }
    }

    internal class RedPotion : IDrinkable
    {
        public string ItemName { get; set; } = "Red Potion";

        public void Drink(PlayerEntity player)
        {
            player.Health += 50;
        }
    }

    internal class WhitePotion : IDrinkable
    {
        public string ItemName { get; set; } = "White Potion";

        public void Drink(PlayerEntity player)
        {
            player.Health += (int)(1000 * player.HealthRecoveryMultiplier);
        }
    }

    internal class YggPotion : IDrinkable
    {
        public string ItemName { get; set; } = "Yggdrasil Potion";

        public void Drink(PlayerEntity player)
        {
            player.Health += player.MaximumHealth / 2;
            player.Mana += player.MaximumMana / 2;
        }
    }
}