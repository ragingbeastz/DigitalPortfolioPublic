using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    /// <summary>
    /// Warrior character class
    /// </summary>
    internal class Warrior : Character
    {
        /// <summary>
        /// Instantiates Character variable for the instance
        /// </summary>
        private Character self;

        /// <summary>
        /// Constructor method to set default values for health and energy
        /// </summary>
        /// <param name="name">The desired name of the character</param>
        public Warrior(string name) : base(name)
        {
            MaxHealthPoints = 15;
            MaxEnergyPoints = 10;

            self = this;
            ChangeCharacterEnergy(self, MaxEnergyPoints);
            ChangeCharacterHealth(self, MaxHealthPoints);

        }

        /// <summary>
        /// SwingSword method for Warrior class to attack Character Instance
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void SwingSword (Character target)
        {
            ChangeCharacterHealth(target, (target.HealthPoints/2)*-1);
            ChangeCharacterEnergy(self, -5);

            Console.WriteLine($"Warrior {Name} swung their sword at {target.Name}");
        }

        /// <summary>
        /// ShieldBlock method for Warrior class to heal self and deal damage to intended Character Instance
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void ShieldBlock(Character target)
        {
            ChangeCharacterHealth(self, 3);
            ChangeCharacterHealth(target, -2);
            ChangeCharacterEnergy(self, -2);

            Console.WriteLine($"Warrior {Name} blocked with their shield and hurt {target.Name}");
        }
    }
}
