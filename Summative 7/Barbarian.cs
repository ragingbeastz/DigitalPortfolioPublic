using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    /// <summary>
    /// Barbarian character class
    /// </summary>
    internal class Barbarian : Character
    {
        /// <summary>
        /// Instantiates Character variable for the instance
        /// </summary>
        private Character self;

        /// <summary>
        /// Constructor method to set default values for health and energy
        /// </summary>
        /// <param name="name">The desired name of the character</param>
        public Barbarian(string name) : base(name) 
        {
            MaxHealthPoints = 18;
            MaxEnergyPoints = 12;

            self = this;
            ChangeCharacterEnergy(self, MaxEnergyPoints);
            ChangeCharacterHealth(self, MaxHealthPoints);
            
        }

        /// <summary>
        /// Swing Axe move for Barbarian Class
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void SwingAxe(Character target) 
        {
            if (isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action, they were knocked out!");
            }

            else if (EnergyPoints >= 3)
            {
                Console.WriteLine($"{Name} the barbarian swung his mighty axe at {target.Name}.");
                ChangeCharacterEnergy(self,-3);
                ChangeCharacterHealth(target, -3);
            }

            else
            {
                Console.WriteLine($"{Name} the barbarian does not have enough energy.");
            }
        }
    }
}
