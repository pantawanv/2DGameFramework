using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{

    /// <summary>
    /// Represents an item used for attacks in the game world.
    /// The AttackItem class inherits from WorldObject and includes properties for name, damage (hit), and range.
    /// </summary>
    public class AttackItem : WorldObject
    {
        /// <summary>
        /// Gets or sets the name of the attack item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the damage value of the attack item.
        /// The value is always positive to ensure consistent calculations.
        /// </summary>
        public int Hit { get; set; }

        /// <summary>
        /// Gets or sets the range of the attack item.
        /// Default value is set to 0, with plans for future implementation.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackItem"/> class with a specified name and damage value.
        /// Ensures the damage value is always positive.
        /// </summary>
        /// <param name="name">The name of the attack item.</param>
        /// <param name="hit">The damage value of the attack item.</param>
        public AttackItem(string name, int hit)
        {
            Name = name;
            /// Ensuring the hit value is always positive
            Hit = Math.Abs(hit);
            /// Placeholder for range functionality
            Range = 0;
        }

        /// <summary>
        /// Returns a string representation of the AttackItem object.
        /// Includes the name, damage value, and range in a formatted structure.
        /// </summary>
        /// <returns>A string representing the AttackItem object.</returns>
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }
    }
}
