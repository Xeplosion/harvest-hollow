using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestHollow.Tiles
{
    internal struct TileStruct
    {
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }
        public Stack<float> Opacity { get; set; }
        public Stack<int> Flip { get; set; }
        public Stack<string> IID { get; set; }
        public Stack<int> SourceX { get; set; }
        public Stack<int> SourceY { get; set; }
        public TileStruct(int x, int y)
        {
            // The tiles actual position on the screen.
            ScreenX = x;
            ScreenY = y;

            // Used for the draw stack.
            Opacity = new Stack<float>();
            Flip = new Stack<int>();
            IID = new Stack<string>();
            SourceX = new Stack<int>();
            SourceY = new Stack<int>();
        }
    }
}
