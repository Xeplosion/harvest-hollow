using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestHollow.Tiles.Structures.Definitions
{
    internal struct TilesetDefStruct
    {
        public string Identifier { get; set; }
        public int Uid { get; set; }
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }
        public Dictionary<string, int> CustomData { get; set; }
        public Dictionary<string, int> EnumTags { get; set; }
        public int Padding { get; set; }
        public int pxWidth { get; set; }
        public int pxHeight { get; set; }
        public string RelPath { get; set; }
        public int Spacing { get; set; }
        public Stack<string> Tags { get; set; }
        public int TagSourceEnumUid { get; set; }
        public int TileGridSize { get; set; }
    }
}
