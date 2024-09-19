using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestHollow.Tiles.Structures.Definitions
{
    internal interface ILayerDefStruct
    {
        protected string Type { get; set; }
        protected float DisplayOpacity { get; set }
        protected string Identifier { get; set; }
        protected float ParralaxFactorX { get; set; }
        protected float ParralaxFactorY { get; set; }
        protected bool PrallaxScaling { get; set; }
        protected int pxOffsetX { get; set; }
        protected int pxOffsetY { get; set; }
        protected int Uid { get; set; }
    }
}
