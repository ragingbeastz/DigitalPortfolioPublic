using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Summative_7
{
    /// <summary>
    /// Character Parent Class for creation of Characters in game
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Represents Character instance int energy points to alter instance HealthPoints
        /// </summary>
        private int _energyPoints;

        /// <summary>
        /// Represents private member Character instance health points to alter instance EnergyPoints
        /// </summary>
        private int _healthPoints;

        /// <summary>
        /// Represents the maximium int health points of the Character Class
        /// </summary>
        public int MaxHealthPoints { get; protected set; }

        /// <summary>
        /// Represents the maximium int Energy points of the Character Class
        /// </summary>
        public int MaxEnergyPoints { get; protected set; }

        /// <summary>
        /// Represents the string name of the Character
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Represents the current int health points of the Character
        /// </summary>
        public int HealthPoints { get { return _healthPoints; } private set { } }

        /// <summary>
        /// Represents the current int energy points of the Character
        /// </summary>
        public int EnergyPoints { get { return _energyPoints; } private set { } }

        /// <summary>
        /// Represents the current bool Knocked out status of the Character
        /// </summary>
        public bool isKnockedOut { get { return HealthPoints <= 0; } private set { } }


        


        /// <summary>
        /// Represents the Constructor Class of the Character
        /// </summary>
        /// <param name="name">The desired name of the character</param>
        public Character(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Method to allow manipulation of Character Instance Health points
        /// </summary>
        /// <param name="target">The target Character Instance</param>
        /// <param name="adjustment">The intended adjustment int value e.g. -4,30</param>
        protected void ChangeCharacterHealth(Character target, int adjustment)
        {
            int value = target.HealthPoints;
            value = value + adjustment;
            if (value < target.MaxHealthPoints) { target._healthPoints = value; }
            else { target._healthPoints = target.MaxHealthPoints; }
        }

        /// <summary>
        /// Method to allow manipulation of Character Instance Health points
        /// </summary>
        /// <param name="target">The target Character Instance</param>
        /// <param name="adjustment">The intended adjustment int value e.g. -4,30</param>
        protected void ChangeCharacterEnergy(Character target, int adjustment)
        {
            int value = target.EnergyPoints;
            value = value + adjustment;
            if (value < target.MaxEnergyPoints) { target._energyPoints = value; }
            else { target._energyPoints = target.MaxEnergyPoints; }
        }

        /// <summary>
        /// Method to allow manipulation of Character Instance Knock out Status
        /// </summary>
        /// <param name="target">The target Character Instance</param>
        /// <param name="status">The intended boolean value e.g. true, false</param>
        protected void ChangeKnockoutStatus(Character target, bool status)
        {
            target.isKnockedOut = status;
        }

        /// <summary>
        /// Method to implement Resting for Character. Replenishes energy and health.
        /// </summary>
        public void Rest()
        {
            if (!isKnockedOut)
            {
                EnergyPoints = MaxEnergyPoints;
                HealthPoints = MaxHealthPoints;
            }
        }
    }
}
