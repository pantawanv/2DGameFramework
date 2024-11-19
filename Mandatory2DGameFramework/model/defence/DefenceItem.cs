using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem:WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }

        public DefenceItem(int reduceHit)
        {
            Name = string.Empty;
            ReduceHitPoint = Math.Abs(reduceHit);
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
