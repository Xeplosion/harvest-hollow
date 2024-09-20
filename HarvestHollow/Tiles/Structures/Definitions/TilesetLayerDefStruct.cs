using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestHollow.Tiles.Structures.Definitions
{
    internal struct TilesetLayerDefStruct : ILayerDefStruct
    {
        public string Type { get; set; }
        public float DisplayOpacity { get; set; }
        public string Identifier { get; set; }
        public float ParralaxFactorX { get; set; }
        public float ParralaxFactorY { get; set; }
        public bool PrallaxScaling { get; set; }
        public int pxOffsetX { get; set; }
        public int pxOffsetY { get; set; }
        public int Uid { get; set; }
    }
}
