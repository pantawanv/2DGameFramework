using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    namespace Mandatory2DGameFramework.model.Creatures
    {
        /// <summary>
        /// The Creature class represents a living entity in the game world.
        /// It has attributes for health, location, and equipment (attack and defense items).
        /// The class provides methods to handle combat, determine its state (alive or dead),
        /// and interact with world objects through looting.
        /// </summary>
        public class Creature : ICreature 
        {
            /// <summary>
            /// Gets or sets the name of the creature.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the hit points (health) of the creature. 
            /// Positive values indicate the creature is alive, while zero or negative values indicate death.
            /// </summary>
            public int HitPoint { get; set; }

            /// <summary>
            /// Gets or sets the creature's X-coordinate location in the game world.
            /// </summary>
            public int LocationX { get; set; }

            /// <summary>
            /// Gets or sets the creature's Y-coordinate location in the game world.
            /// </summary>
            public int LocationY { get; set; }

            /// <summary>
            /// Indicates whether the creature is alive.
            /// This property is managed internally based on hit points.
            /// </summary>
            private bool _alive { get; set; }

            public int Armor {  get; set; }

            /// <summary>
            /// Checks if the creature is alive based on its hit points.
            /// </summary>
            /// <returns>True if the creature is alive; otherwise, false.</returns>
            public bool Alive()
            {
                if (HitPoint <= 0)
                {
                    _alive = false;
                }
                return _alive;
            }

            /// <summary>
            /// Gets or sets the attack item equipped by the creature. This is optional and can be null.
            /// </summary>
            public AttackItem? Attack { get; set; }

            /// <summary>
            /// Gets or sets the defense item equipped by the creature. This is optional and can be null.
            /// </summary>
            public DefenceItem? Defence { get; set; }

            /// <summary>
            /// Initializes a new instance of the Creature class with a given name and hit points.
            /// The creature is considered alive by default.
            /// </summary>
            /// <param name="name">The name of the creature.</param>
            /// <param name="hitpoint">The initial hit points of the creature.</param>
            public Creature(string name, int hitpoint)
            {
                Name = name;
                HitPoint = Math.Abs(hitpoint);
                _alive = true;
                Attack = null;
                Defence = null;
                Armor = 0;
            }

            /// <summary>
            /// Performs an attack on an enemy creature.
            /// The damage dealt is a random value modified by the equipped attack item, if any.
            /// </summary>
            /// <param name="enemy">The enemy creature to be attacked.</param>
            public virtual void Hit(Creature enemy, int hitPoint)
            {
                if (Alive())
                {
                    Random random = new Random();
                    int hit = random.Next(0, 20);

                    if (Attack != null)
                    {
                        hit += Attack.Hit;
                    }

                    enemy.ReceiveHit(hit);

                }
            }

            /// <summary>
            /// Handles receiving damage from an attack.
            /// Damage is reduced by the equipped defense item, if any, and cannot be less than zero.
            /// </summary>
            /// <param name="hit">The amount of damage received.</param>
            public virtual void ReceiveHit(int hit)
            {
                if (Alive())

                {
                    if (Defence != null)
                    {
                        hit -= Defence.ReduceHitPoint;
                        hit = Math.Max(hit, 0);
                    }
                    HitPoint -= hit;
                }
            }

            /// <summary>
            /// Loots a world object if it is lootable. Updates the creature's equipment accordingly.
            /// </summary>
            /// <param name="obj">The world object to loot.</param>
            /// <param name="world">The world from which the object is being looted.</param>
            public virtual void Loot(WorldObject obj, World world)
            {
                if (obj.Lootable)
                {
                    if (obj is AttackItem)
                    {
                        Attack = (AttackItem)obj;
                        world.RemoveWorldObject(obj);
                    }
                    else if (obj is DefenceItem)
                    {
                        Defence = (DefenceItem)obj;
                        world.RemoveWorldObject(obj);
                    }
                }
            }

            /// <summary>
            /// Returns a formatted string representation of the creature's state,
            /// including its name, hit points, location, and equipped items.
            /// </summary>
            /// <returns>A string representing the creature's current state.</returns>
            public override string ToString()
            {
                return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}," +
                    $" {nameof(LocationX)} = {LocationX}, {nameof(LocationY)} = {LocationY}}}";
            }
        }
    }

}
