using System;
using System.Collections.Generic;
using System.Text;
using DependancyInjectionExample.Library;
using DependancyInjectionExample.Models;

namespace DependancyInjectionExample.Views
{
    public static class DisplayStatus
    {
        public static string CurrentHealth(this PlayerEntity player)
        {
            return $"[{player.Health}/{player.MaximumHealth}]HP";
        }

        public static string CurrentHealth(this Lazy<PlayerEntity> player)
        {
            return $"[{player.Value.Health}/{player.Value.MaximumHealth}]HP";
        }

        public static string CurrentMana(this PlayerEntity player)
        {
            return $"[{player.Mana}/{player.MaximumMana}]MP";
        }

        public static string CurrentMana(this Lazy<PlayerEntity> player)
        {
            return $"[{player.Value.Mana}/{player.Value.MaximumMana}]MP";
        }

        public static string UsedItem(this PlayerEntity player)
        {
            var text = new StringBuilder();

            text.Append(player.PotionType.StartsWithAny(new List<string>() { "A", "E", "I", "O", "U" })
                ? " has drank from an "
                : " has drank from a ");

            return $"[{player.PlayerName}]" + text.ToString() + $"[{player.PotionType}].";
        }
    }
}