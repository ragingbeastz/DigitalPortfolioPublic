using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    /// <summary>
    /// Mage Character class
    /// </summary>
    internal class Mage : Character
    {
        /// <summary>
        /// Instantiates Character variable for the instance
        /// </summary>
        private Character self;

        /// <summary>
        /// Constructor method to set default values for health and energy
        /// </summary>
        /// <param name="name">The desired name of the character</param>
        public Mage(string name) : base(name)
        {
            MaxHealthPoints = 8;
            MaxEnergyPoints = 8;

            self = this;
            ChangeCharacterEnergy(self, MaxEnergyPoints);
            ChangeCharacterHealth(self, MaxHealthPoints);

        }

        /// <summary>
        /// Throw Fireball method for Mage class to Attack other Character Instances
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void ThrowFireball(Character target)
        {
            if (isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action, they were knocked out!");
            }
            
            else if (EnergyPoints >= 2)
            {
                Console.WriteLine($"{Name} the mage threw a fireball at {target.Name}.");
                ChangeCharacterHealth(target, -2);
                ChangeCharacterEnergy(self, -2);
            }

            else
            {
                Console.WriteLine($"{Name} the mage does not have enough energy.");
            }
            
        }

        /// <summary>
        /// Heal method for Mage class to heal a Character Instance
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void Heal(Character target)
        {
            if (isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action, they were knocked out!");
            }

            else if (EnergyPoints >= 1)
            {
                ChangeCharacterEnergy(self,-1);
                ChangeCharacterHealth(target,5);
                Console.WriteLine($"{Name} the mage healed {target.Name}.");
            }
            else
            {
                Console.WriteLine($"{Name} the mage does not have enough energy.");
            }
        }

        /// <summary>
        /// Resurrect method for the Mage class to change status of isKnocked variable on Character Classes
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void Resurrect(Character target)
        {
            if (isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action, they were knocked out!");
            }

            else if (!target.isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action. {target.Name} is still alive!");
            }

            else if (EnergyPoints >= 5)
            {
                ChangeCharacterEnergy(self,-5);
                ChangeKnockoutStatus(target,false); 
                ChangeCharacterEnergy(target, target.MaxEnergyPoints);
                Console.WriteLine($"{Name} the mage resurrected {target.Name}.");
            }

            else
            {
                Console.WriteLine($"{Name} the mage does not have enough energy.");
            }
        }
    }
}
