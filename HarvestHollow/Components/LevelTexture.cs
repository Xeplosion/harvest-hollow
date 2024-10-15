using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

using HarvestHollow.Entities.LevelData;

namespace HarvestHollow.Components
{
    public class LevelTexture
    {
        private LevelStruct _level;
        private bool _isLevelRendered = false;
        private Stack<string> _texturesList;
        public LevelTexture(LevelStruct level, GraphicsDevice levelTexture)
        {
            // Create a new texture
            _level = level;
            _texturesList = getTextures();

        }
        private Stack<string> getTextures()
        {
            Stack<string> textures = new Stack<string>();
            foreach (LayerInstance layer in _level.LayerInstances)
            {
                int? tilesetUID = layer.TilesetUID;
                if (layer.TilesetLayerDefUID == null)
                {
                    throw new InvalidOperationException("TilesetLayerDefUID is null");
                }
                
            }
            return textures;
        }
    }

}
