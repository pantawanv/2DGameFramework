using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.model.Cretures.Mandatory2DGameFramework.model.Creatures
{
    public interface ICreature
    {
        AttackItem? Attack { get; set; }
        DefenceItem? Defence { get; set; }
        int HitPoint { get; set; }
        int LocationX { get; set; }
        int LocationY { get; set; }
        string Name { get; set; }

        bool Alive();
        void Hit(Creature enemy, int hitPoint);
        void Loot(WorldObject obj, World world);
        void ReceiveHit(int hit);
        string ToString();
    }
}