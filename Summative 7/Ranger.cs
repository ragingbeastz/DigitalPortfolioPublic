using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    /// <summary>
    /// Ranger Character class
    /// </summary>
    internal class Ranger : Character
    {
        /// <summary>
        /// Instantiates Character variable for the instance
        /// </summary>
        private Character self;
        /// <summary>
        /// Integer variable for the amount of arrows the Ranger Class initially carries.
        /// </summary>
        public int NumberOfArrows { get; private set; }
        /// <summary>
        /// Integer variable for the amount of arrows the Ranger Class has currently fired.
        /// </summary>
        public int FiredArrows { get; private set; }

        /// <summary>
        /// Constructor method to set default values for health and energy
        /// </summary>
        /// <param name="name">The desired name of the character</param>
        public Ranger(string name) : base(name)
        {
            MaxHealthPoints = 10;
            MaxEnergyPoints = 8;

            self = this;
            ChangeCharacterEnergy(self, MaxEnergyPoints);
            ChangeCharacterHealth(self, MaxHealthPoints);
            this.NumberOfArrows = 10;
        }

        /// <summary>
        /// Arrow collection method for Ranger class to Replenish arrows
        /// </summary>
        public void CollectArrows()
        {
            if (isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action, they were knocked out!");
                return;
            }
            else
            {
                Console.WriteLine($"{Name} Collected their arrows.");
                NumberOfArrows += FiredArrows;
                FiredArrows = 0;
            }
            
            
        }

        /// <summary>
        /// Fire Arrow Method for Ranger Class to attack other Character Class
        /// </summary>
        /// <param name="target">The intended Character Instance</param>
        public void FireArrows(Character target)
        {
            if (isKnockedOut)
            {
                Console.WriteLine($"{Name} cannot perform action, they were knocked out!");
                return;
            }

            else if (NumberOfArrows > 0)
            {
                if (EnergyPoints >= 1)
                {
                    ChangeCharacterEnergy(self, -1);
                    NumberOfArrows--;
                    FiredArrows++;
                    Console.WriteLine($"{Name} the ranger shot an arrow at {target.Name}.");
                    ChangeCharacterHealth(target,-1);
                }

                else
                {
                    Console.WriteLine($"{Name} the ranger does not have enough energy.");
                }

            }

            else
            {
                Console.WriteLine($"{Name} the ranger does not have enough arrows.");
            }

            
        }
    }
}
