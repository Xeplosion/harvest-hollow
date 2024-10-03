using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using HarvestHollow.Systems;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace HarvestHollow.GameCore;

/// <summary> 
/// Manages and loads game assets. 
/// </summary>
internal class Assets : AssetLoader
{
    private static Dictionary<string, SpriteFont>? _fonts;
    private static Dictionary<string, SoundEffect>? _soundEffects;
    private static Dictionary<string, Song>? _music;
    private static Dictionary<string, Texture2D>? _characters;
    private static Dictionary<string, Texture2D>? _characterEffects;
    private static Dictionary<string, Texture2D>? _nPCs;
    private static Dictionary<string, Texture2D>? _paletteSwap;
    private static Dictionary<string, Texture2D>? _spriteSheets;
    private static Dictionary<string, Texture2D>? _tileSheets;

    internal static Dictionary<string, SpriteFont> Fonts => _fonts ?? new Dictionary<string, SpriteFont>();
    internal static Dictionary<string, SoundEffect> SoundEffects => _soundEffects ?? new Dictionary<string, SoundEffect>();
    internal static Dictionary<string, Song> Music => _music ?? new Dictionary<string, Song>();
    internal static Dictionary<string, Texture2D> Characters => _characters ?? new Dictionary<string, Texture2D>();
    internal static Dictionary<string, Texture2D> CharacterEffects => _characterEffects ?? new Dictionary<string, Texture2D>();
    internal static Dictionary<string, Texture2D> NPCs => _nPCs ?? new Dictionary<string, Texture2D>();
    internal static Dictionary<string, Texture2D> PaletteSwap => _paletteSwap ?? new Dictionary<string, Texture2D>();
    internal static Dictionary<string, Texture2D> SpriteSheets => _spriteSheets ?? new Dictionary<string, Texture2D>();
    internal static Dictionary<string, Texture2D> TileSheets => _tileSheets ?? new Dictionary<string, Texture2D>();

    /// <summary> 
    /// Initializes the asset loader and starts loading all assets. 
    /// </summary>
    /// <param name="contentManager">The ContentManager instance to use for loading assets.</param>
    internal Assets(ContentManager contentManager) : base(contentManager)
    {
        s_LoadAllAssets();
    }

    /// <summary> 
    /// Loads a specific section of assets. 
    /// </summary>
    /// <param name="section">The section of assets to load.</param>
    private static void s_LoadAssetSection(AssetSection section)
    {
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
                _nPCs = s_GetTextures(section);
                break;
            case AssetSection.Textures:
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

    /// <summary> 
    /// Distributes asset loading tasks across threads. 
    /// </summary>
    /// <param name="thread">Dictionary of AssetSections as keys and their assigned thread for loading as values.</param>
    private static void s_LoadThreadAssets(object? thread)
    {
        if (_sortedThreads == null)
        {
            return;
        }

        foreach (var section in AssetPaths.Keys)
        {
            if (_sortedThreads[section] == (int?)thread)
            {
                s_LoadAssetSection(section);
            }
        }
    }

    private static readonly Thread[] _loaderThreads = new Thread[Environment.ProcessorCount - 1];
    internal static Thread[] LoaderThreads => _loaderThreads;
    private static Dictionary<AssetSection, int>? _sortedThreads;

    /// <summary> 
    /// Loads all game assets in separate threads. 
    /// </summary>
    internal static void s_LoadAllAssets()
    {
        Debug.WriteLine("\nLOADING ALL ASSETS:");
        _sortedThreads = s_GetThreadDistribution(_loaderThreads.Length);

        for (var thread = 0; thread < _loaderThreads.Length; thread++)
        {
            _loaderThreads[thread] = new Thread(s_LoadThreadAssets);
            _loaderThreads[thread].Name = $"AssetLoader{thread}";
            _loaderThreads[thread].Start(thread);
        }
    }

    /// <summary> 
    /// Reloads all game assets. 
    /// </summary>
    internal static void s_ReloadAllAssets()
    {
        s_LoadAllAssets();
    }

    /// <summary> 
    /// Renders the AssetLoader progress bar. 
    /// </summary>
    protected void NotifyProgress()
    {
        // TODO: create necessary GUI for progress bar.
    }
}