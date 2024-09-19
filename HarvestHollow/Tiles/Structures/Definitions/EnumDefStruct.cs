using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestHollow.Tiles.Structures.Definitions
{
    internal struct EnumDefStruct
    {
        public string Identifier { get; set; }
        public int Uid { get; set; }
        public Stack<string> Tags { get; set; }
        public Stack<EnumValueDefStruct> Values { get; set; }
        public int IconTilesetUid { get; set; }
        public string ExternalRelPath { get; set; }

    }
}
