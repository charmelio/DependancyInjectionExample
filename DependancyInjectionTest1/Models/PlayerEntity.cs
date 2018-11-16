using DependancyInjectionExample.Interfaces;

namespace DependancyInjectionExample.Models
{
    public class PlayerEntity
    {
        public double HealthRecoveryMultiplier;
        public double ManaRecoveryMultiplier;
        public int MaximumHealth;
        public int MaximumMana;
        public string PlayerName;
        public string PotionType;
        private readonly IDrinkable _drinkService;
        private int _health;
        private int _mana;

        public int Health
        {
            get => _health;
            set => _health = value > MaximumHealth ? MaximumHealth : value;
        }

        public int Mana
        {
            get => _mana;
            set => _mana = value > MaximumMana ? MaximumMana : value;
        }

        /// <summary>
        /// The PlayerEntity consumes whatever Potion object is given to it as it implements Drink()
        /// </summary>
        /// <param name="drink"></param>
        public PlayerEntity(IDrinkable drink)
        {
            _drinkService = drink;
            PotionType = _drinkService.ItemName;
        }

        public void Drink()
        {
            _drinkService.Drink(this);
        }
    }
}