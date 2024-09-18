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
        private static Dictionary<string, SpriteFont> _s_fonts;
        private static Dictionary<string, SoundEffect> _s_soundEffects;
        private static Dictionary<string, Song> _s_music;
        private static Dictionary<string, Texture2D> _s_characters;
        private static Dictionary<string, Texture2D> _s_characterEffects;
        private static Dictionary<string, Texture2D> _s_NPCs;
        private static Dictionary<string, Texture2D> _s_paletteSwap;
        private static Dictionary<string, Texture2D> _s_spriteSheets;
        private static Dictionary<string, Texture2D> _s_tileSheets;

        internal static Dictionary<string, SpriteFont> Fonts { get { return _s_fonts; } }
        internal static Dictionary<string, SoundEffect> SoundEffects { get { return _s_soundEffects; } }
        internal static Dictionary<string, Song> Music { get { return _s_music; } }
        internal static Dictionary<string, Texture2D> Characters { get { return _s_characters; } }
        internal static Dictionary<string, Texture2D> CharacterEffects { get { return _s_characterEffects; } }
        internal static Dictionary<string, Texture2D> NPCs { get { return _s_NPCs; } }
        internal static Dictionary<string, Texture2D> PaletteSwap { get { return _s_paletteSwap; } }
        internal static Dictionary<string, Texture2D> SpriteSheets { get { return _s_spriteSheets; } }
        internal static Dictionary<string, Texture2D> TileSheets { get { return _s_tileSheets; } }

        // Constructor required for superclass AssetLoader function.
        internal Assets(ContentManager contentManager) : base(contentManager) { LoadAllAssets(); }

        // Functions to load asset groups based off their assigned thread.
        private static void s_LoadAssetSection(AssetSection section)
        {
            // Loads all game assets.
            switch (section)
            {
                case AssetSection.SFX:
                    _s_soundEffects = s_GetSoundEffects(section);
                    break;
                case AssetSection.OST:
                    _s_music = s_GetSongs(section);
                    break;
                case AssetSection.CharacterSheets:
                    _s_characters = s_GetTextures(section);
                    break;
                case AssetSection.CharacterEffects:
                    _s_characterEffects = s_GetTextures(section);
                    break;
                case AssetSection.NPC:
                    _s_NPCs = s_GetTextures(section);
                    break;
                case AssetSection.PaletteSwap:
                    _s_paletteSwap = s_GetTextures(section);
                    break;
                case AssetSection.SpriteSheets:
                    _s_spriteSheets = s_GetTextures(section);
                    break;
                case AssetSection.TileSheets:
                    _s_tileSheets = s_GetTextures(section);
                    break;
                case AssetSection.Fonts:
                    _s_fonts = s_GetFonts();
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
                if (_s_sortedThreads[section] == (int)thread) { s_LoadAssetSection(section); }
            }
        }

        // Loads all game assets in separate threads.
        private static Thread[] _s_LoaderThreads = new Thread[Environment.ProcessorCount - 1];
        internal static Thread[] LoaderThreads { get { return _s_LoaderThreads; } }
        private static Dictionary<AssetSection, int> _s_sortedThreads;
        internal static void LoadAllAssets()
        {
            Debug.WriteLine("\nLOADING ALL ASSETS:");
            _s_sortedThreads = s_GetThreadDistribution(_s_LoaderThreads.Length);
            for (int thread = 0; thread < _s_LoaderThreads.Length; thread++) {
                _s_LoaderThreads[thread] = new Thread(s_LoadThreadAssets);
                _s_LoaderThreads[thread].Name = $"AssetLoader{thread}";
                _s_LoaderThreads[thread].Start(thread);
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
