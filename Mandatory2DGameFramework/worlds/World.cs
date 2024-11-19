using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.Cretures.Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }


        // world objects
        private List<WorldObject> _worldObjects;
        // world creatures
        private List<Creature> _creatures;

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        /// <summary>
        /// Checks if the specified location (x, y) is free in the world.
        /// A location is considered free if no creatures or world objects are occupying that spot.
        /// </summary>
        /// <param name="x">The x-coordinate of the location to check.</param>
        /// <param name="y">The y-coordinate of the location to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the location is free (i.e., not occupied by any creatures or world objects);
        /// otherwise, returns <c>false</c> if either a creature or a world object is occupying the location.
        /// </returns>
        public bool LocationFree (int x, int y)
        {
            return !_creatures.Any(creature => creature.LocationX == x && creature.LocationY == y) &&
                !_worldObjects.Any(worldObject =>  worldObject.LocationX == x && worldObject.LocationY == y);
        }

        //public bool LocationFree (int x, int y)
        //{
        //    foreach (var creature in _creatures)
        //    {
        //        if (creature.LocationX == x && creature.LocationY == y)
        //        {
        //            return false;
        //        }
              
        //    }
        //    foreach (var worldObject in _worldObjects)
        //    {
        //        if (worldObject.LocationX == x && worldObject.LocationY == y)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}



        public void InsertCreature(int x, int y, Creature creature)
        {
            if (LocationFree(x, y))
            {
                creature.LocationX = x;
                creature.LocationY = y;
                _creatures.Add(creature);
                MyLogger.TraceInformation($"{creature.Name} was successfully inserted");
            }
            else
            {
                MyLogger.TraceError($"Location {x}, {y} was not free. {creature.Name} was not inserted into world");

            }
            
        }

        public void InsertWorldObject(int x, int y, WorldObject worldObject)
        {
            if (LocationFree(x,y))
            {
                worldObject.LocationX = x;
                worldObject.LocationY = y;
                _worldObjects.Add(worldObject);
            }
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            _worldObjects.Remove(worldObject);
            worldObject.LocationX = 0;
            worldObject.LocationY = 0;

        }


        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }

        /// <summary>
        /// Retrieves a list of creatures located at the specified (x, y) coordinates in the world.
        /// </summary>
        /// <param name="x">The x-coordinate of the location to check for creatures.</param>
        /// <param name="y">The y-coordinate of the location to check for creatures.</param>
        /// <returns>
        /// A list of <see cref="Creature"/> objects that are located at the given (x, y) coordinates.
        /// If no creatures are found at the location, an empty list is returned.
        /// </returns>
        public List<Creature> GetCreatureLocation(int x, int y)
        {
            return _creatures.Where(creature => creature.LocationX == x && creature.LocationY == y).ToList();
        }
    }
}
