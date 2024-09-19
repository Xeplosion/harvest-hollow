using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace HarvestHollow.Content
{
    internal class Assets : AssetLoader
    {
        // Asset variables containing references to all loaded assets.
        private static Dictionary<string, SpriteFont> _fonts;
        private static Dictionary<string, SoundEffect> _soundEffects;
        private static Dictionary<string, Song> _music;
        private static Dictionary<string, Texture2D> _characters;
        private static Dictionary<string, Texture2D> _characterEffects;
        private static Dictionary<string, Texture2D> _NPCs;
        private static Dictionary<string, Texture2D> _paletteSwap;
        private static Dictionary<string, Texture2D> _spriteSheets;
        private static Dictionary<string, Texture2D> _tileSheets;

        internal static Dictionary<string, SpriteFont> Fonts { get { return _fonts; } }
        internal static Dictionary<string, SoundEffect> SoundEffects { get { return _soundEffects; } }
        internal static Dictionary<string, Song> Music { get { return _music; } }
        internal static Dictionary<string, Texture2D> Characters { get { return _characters; } }
        internal static Dictionary<string, Texture2D> CharacterEffects { get { return _characterEffects; } }
        internal static Dictionary<string, Texture2D> NPCs { get { return _NPCs; } }
        internal static Dictionary<string, Texture2D> PaletteSwap { get { return _paletteSwap; } }
        internal static Dictionary<string, Texture2D> SpriteSheets { get { return _spriteSheets; } }
        internal static Dictionary<string, Texture2D> TileSheets { get { return _tileSheets; } }

        // Constructor required for superclass AssetLoader function.
        internal Assets(ContentManager contentManager) : base(contentManager) { LoadAllAssets(); }

        // Functions to load asset groups based off their assigned thread.
        private static void s_LoadAssetSection(AssetSection section)
        {
            // Loads all game assets.
            switch (section)
            {
                case AssetSection.SFX:
                    _soundEffects = s_GetSoundEffects(section);
                    break;
                case AssetSection.OST:
                    _music = s_GetSongs(section);
                    break;
                case AssetSection.CharacterSheets:
                    _characters = s_GetTextures(section);
                    break;
                case AssetSection.CharacterEffects:
                    _characterEffects = s_GetTextures(section);
                    break;
                case AssetSection.NPC:
                    _NPCs = s_GetTextures(section);
                    break;
                case AssetSection.PaletteSwap:
                    _paletteSwap = s_GetTextures(section);
                    break;
                case AssetSection.SpriteSheets:
                    _spriteSheets = s_GetTextures(section);
                    break;
                case AssetSection.TileSheets:
                    _tileSheets = s_GetTextures(section);
                    break;
                case AssetSection.Fonts:
                    _fonts = s_GetFonts();
                    break;
                default:
                    Debug.WriteLine("ERROR: Invalid AssetSection");
                    break;
            }
        }
        private static void s_LoadThreadAssets (object thread)
        {
            // Evenly distributes asset loads into threads.
            foreach (AssetSection section in AssetPaths.Keys)
            {
                if (_sortedThreads[section] == (int)thread) { s_LoadAssetSection(section); }
            }
        }

        // Loads all game assets in separate threads.
        private static Thread[] _LoaderThreads = new Thread[Environment.ProcessorCount - 1];
        internal static Thread[] LoaderThreads { get { return _LoaderThreads; } }
        private static Dictionary<AssetSection, int> _sortedThreads;
        internal static void LoadAllAssets()
        {
            Debug.WriteLine("\nLOADING ALL ASSETS:");
            _sortedThreads = s_GetThreadDistribution(_LoaderThreads.Length);
            for (int thread = 0; thread < _LoaderThreads.Length; thread++) {
                _LoaderThreads[thread] = new Thread(s_LoadThreadAssets);
                _LoaderThreads[thread].Name = $"AssetLoader{thread}";
                _LoaderThreads[thread].Start(thread);
            }
        }
        internal static void ReloadAllAssets() { LoadAllAssets(); }

        // Renders the AssetLoader progress bar.
        protected void NotifyProgress()
        {
            // TODO: create neccessary GUI for progress bar.
        }
    }
}
