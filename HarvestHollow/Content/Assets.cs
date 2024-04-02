using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Content;
using LDtk;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace HarvestHollow.Content
{
    internal class Assets : AssetLoader
    {
        // Asset variables containing references to all loaded assets.
        internal static LDtkFile Levels;
        internal static Dictionary<string, SpriteFont> Fonts;
        internal static Dictionary<string, SoundEffect> SoundEffects;
        internal static Dictionary<string, Song> Music;
        internal static Dictionary<string, Texture2D> Characters;
        internal static Dictionary<string, Texture2D> CharacterEffects;
        internal static Dictionary<string, Texture2D> NPCs;
        internal static Dictionary<string, Texture2D> PaletteSwap;
        internal static Dictionary<string, Texture2D> SpriteSheets;
        internal static Dictionary<string, Texture2D> TileSheets;

        // Constructor required for superclass AssetLoader function.
        internal Assets(ContentManager contentManager) : base(contentManager) { LoadAllAssets(); }

        // Functions to load asset groups based off their assigned thread.
        private static void LoadAssetGroup(AssetSection section)
        {
            // Loads all game assets.
            switch (section)
            {
                case AssetSection.SFX:
                    SoundEffects = GetSoundEffects(section);
                    break;
                case AssetSection.OST:
                    Music = GetSongs(section);
                    break;
                case AssetSection.CharacterSheets:
                    Characters = GetTextures(section);
                    break;
                case AssetSection.CharacterEffects:
                    CharacterEffects = GetTextures(section);
                    break;
                case AssetSection.NPC:
                    NPCs = GetTextures(section);
                    break;
                case AssetSection.PaletteSwap:
                    PaletteSwap = GetTextures(section);
                    break;
                case AssetSection.SpriteSheets:
                    SpriteSheets = GetTextures(section);
                    break;
                case AssetSection.TileSheets:
                    TileSheets = GetTextures(section);
                    break;

                // Non Xna.Framework asset types.
                case AssetSection.LDtk:
                    //Levels = GetLevels();
                    break;
                case AssetSection.Fonts:
                    Fonts = GetFonts();
                    break;
                default:
                    Debug.WriteLine("ERROR: Invalid AssetSection");
                    break;
            }
        }
        private static void LoadThreadAssets (object thread)
        {
            // Evenly distributes asset loads into threads.
            foreach (AssetSection section in AssetPaths.Keys)
            {
                if (_sortedThreads[section] == (int)thread) { LoadAssetGroup(section); }
            }
        }

        // Loads all game assets in separate threads.
        internal static Thread[] loaderThreads = new Thread[Environment.ProcessorCount - 1];
        private static Dictionary<AssetSection, int> _sortedThreads;
        internal static void LoadAllAssets()
        {
            Debug.WriteLine("\nLOADING ALL ASSETS:");
            _sortedThreads = GetThreadDistribution(loaderThreads.Length);
            for (int thread = 0; thread < loaderThreads.Length; thread++) {
                loaderThreads[thread] = new Thread(LoadThreadAssets);
                loaderThreads[thread].Name = $"AssetLoader{thread}";
                loaderThreads[thread].Start(thread);
            }
        }
        internal static void ReloadAllAssets() { LoadAllAssets(); }

        // Renders the AssetLoader progress bar.
        protected void NotifyProgress()
        {
            // TODO: make a asset loading progress bar.
        }
    }
}
