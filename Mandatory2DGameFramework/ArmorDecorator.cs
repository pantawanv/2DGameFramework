using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures.Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework
{
    public class ArmorDecorator : ICreature
    {
        private readonly ICreature _decoratedCreature;
        private readonly int _armorPoints;

        public ArmorDecorator(ICreature creature, int armorPoints)
        {
            _decoratedCreature = creature;
            _armorPoints = armorPoints;
        }

        public string Name
        {
            get => _decoratedCreature.Name;
            set => _decoratedCreature.Name = value;
        }

        public int HitPoint
        {
            get => _decoratedCreature.HitPoint;
            set => _decoratedCreature.HitPoint = value;
        }

        public int LocationX
        {
            get => _decoratedCreature.LocationX;
            set => _decoratedCreature.LocationX = value;
        }

        public int LocationY
        {
            get => _decoratedCreature.LocationY;
            set => _decoratedCreature.LocationY = value;
        }
        public AttackItem? Attack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DefenceItem? Defence { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Alive() => _decoratedCreature.Alive();

        public void Hit(Creature enemy, int hitPoint) => _decoratedCreature.Hit(enemy, hitPoint);

        public void ReceiveHit(int hit)
        {
            int reducedHit = Math.Max(0, hit - _armorPoints);
            _decoratedCreature.ReceiveHit(reducedHit);
        }

        public void Loot(WorldObject obj, World world) => _decoratedCreature.Loot(obj, world);

        public override string ToString()
        {
            return $"{_decoratedCreature.ToString()}, Armor: {_armorPoints}";
        }

    }
}
