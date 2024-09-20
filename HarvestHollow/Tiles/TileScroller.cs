using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarvestHollow.Tiles;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestHollow.Tiles
{
    internal class TileScroller
    {
        private static int _screenWidth;
        private static int _screenHeight;

        private int _worldX;
        private int _worldY;
        private int _cameraX;
        private int _cameraY;
        private int _worldDepth;

        private static readonly int _tileSize = 32;
        private static readonly int _scalingFactor = 4;
        private static readonly int _tileScreenSize = _tileSize * _scalingFactor;
        private static readonly int _defaultResolutionX = 1280;
        private static readonly int _defaultResolutionY = 720;
        private static readonly int _tileCountX = (int)Math.Ceiling(_defaultResolutionX / (double)_tileScreenSize) + 4;
        private static readonly int _tileCountY = (int)Math.Ceiling(_defaultResolutionY / (double)_tileScreenSize) + 4;
        private static readonly int _tileCount = _tileCountX * _tileCountY;
        private Stack<TileStruct> _tiles = new Stack<TileStruct>();
        internal TileScroller(int width, int height)
        {
            // Display information.
            _screenWidth = width;
            _screenHeight = height;

            // Create the tiles.
            int tileX = -_tileSize / 2 - _tileSize * _tileCountX / 2;
            for (int x = 0; x < _tileCountX; x++)
            {
                int tileY = -_tileSize / 2 - _tileSize * _tileCountY / 2;
                for (int y = 0; y < _tileCountY; y++)
                {
                    // tiles.Push(new TileStruct(tileX, tileY));
                    tileY += _tileSize;
                }
                tileX += _tileSize;
            }
        }
        internal void Update()
        {
            // TODO: add code to update the tile scroller.
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            // TODO: add draw code here.
        }

        private void GetTiles()
        {

        }
        private void GetTile()
        {

        }

        private void UpdateTiles()
        {
            // _tiles[1] = new TileStruct(0, 0);
        }
    }
}
