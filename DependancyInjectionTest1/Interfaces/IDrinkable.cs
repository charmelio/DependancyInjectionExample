using DependancyInjectionExample.Models;

namespace DependancyInjectionExample.Interfaces
{
    /// <summary>
    /// The interface says what functionality everything inheriting must have.
    /// </summary>
    public interface IDrinkable
    {
        string ItemName { get; set; }

        void Drink(PlayerEntity player);
    }
}