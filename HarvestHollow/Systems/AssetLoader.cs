using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using HarvestHollow.Utilities;
using HarvestHollow.GameCore;

namespace HarvestHollow.Systems;

/// <summary> 
/// Abstract class for managing and loading game assets. 
/// </summary>
internal abstract class AssetLoader : AssetDictionary
{
    private static ContentManager? _contentManager
    {
        get; set;
    }

    protected AssetLoader(ContentManager contentManager)
    {
        // Initialize content manager for loading assets.
        _contentManager = contentManager;
        s_InitializeAssetCounts();
        SoundEffect.Initialize(); // Required for multi-threaded asset loading.
    }

    // Variables to track asset loading progress.
    private static Dictionary<AssetSection, int>? _totalAssetsPerSection;
    private static Dictionary<AssetSection, int>? _currentSectionProgress;
    private static int _totalAssets;
    private static float _progress;

    /// <summary> Initializes the asset counts for each section.</summary>
    protected static void s_InitializeAssetCounts()
    {
        _totalAssetsPerSection = new Dictionary<AssetSection, int>();
        _currentSectionProgress = new Dictionary<AssetSection, int>();
        foreach (var section in AssetPaths.Keys)
        {
            _totalAssetsPerSection[section] = AssetPaths[section].Count;
            _totalAssets += AssetPaths[section].Count;
            _currentSectionProgress[section] = 0;
        }
    }

    // Asset loading functions separated by return types.

    /// <summary>
    /// Loads sound effects from the given section.
    /// </summary>
    /// <param name="section">The symbol "section" is a variable of type "AssetSection" within the "AssetDictionary" class in the "HarvestHollow.Utilities" namespace.</param>
    /// <returns>Returns a Dictionary with the name of the assets as keys and their file paths as values.</returns>
    /// <exception cref="InvalidOperationException">Throws when a needed field is not initialized.</exception>
    protected static Dictionary<string, SoundEffect> s_GetSoundEffects(AssetSection section)
    {
        var assets = new Dictionary<string, SoundEffect>();
        foreach (var (assetName, assetPath) in AssetPaths[section])
        {
            if (_contentManager == null)
            {
                throw new InvalidOperationException("Content manager not initialized.");
            }
            else if (_currentSectionProgress == null)
            {
                throw new InvalidOperationException("Current section progress not initialized.");
            }
            try
            {
                var asset = _contentManager.Load<SoundEffect>(assetPath);
                assets.Add(assetName, asset);
            }
            catch (FileNotFoundException fnfe)
            {
                Debug.WriteLine($"File {assetName} not found at '{assetPath}': {fnfe.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading file {assetName}: {ex.Message}");
            }
            finally
            {
                s_NotifyProgress(section);
                _currentSectionProgress[section]++;
                _progress++;
            }
        }
        return assets;
    }

    /// <summary> 
    /// Loads music tracks from the given section. 
    /// </summary>
    /// /// <param name="section">The symbol "section" is a variable of type "AssetSection" within the "AssetDictionary" class in the "HarvestHollow.Utilities" namespace.</param>
    /// <returns>Returns a Dictionary with the name of the assets as keys and their file paths as values.</returns>
    /// <exception cref="InvalidOperationException">Throws when a needed field is not initialized.</exception>
    protected static Dictionary<string, Song> s_GetSongs(AssetSection section)
    {
        var assets = new Dictionary<string, Song>();
        foreach (var (assetName, assetPath) in AssetPaths[section])
        {
            if (_contentManager == null)
            {
                throw new InvalidOperationException("Content manager not initialized.");
            }
            else if (_currentSectionProgress == null)
            {
                throw new InvalidOperationException("Current section progress not initialized.");
            }
            try
            {
                var asset = _contentManager.Load<Song>(assetPath);
                assets.Add(assetName, asset);
            }
            catch (FileNotFoundException fnfe)
            {
                Debug.WriteLine($"File {assetName} not found at '{assetPath}': {fnfe.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading file {assetName}: {ex.Message}");
            }
            finally
            {
                s_NotifyProgress(section);
                _currentSectionProgress[section]++;
                _progress++;
            }
        }
        return assets;
    }

    /// <summary> 
    /// Loads texture assets from the given section.
    /// </summary>
    /// <param name="section">The symbol "section" is a variable of type "AssetSection" within the "AssetDictionary" class in the "HarvestHollow.Utilities" namespace.</param>
    /// <returns>Returns a Dictionary with the name of the assets as keys and their file paths as values.</returns>
    /// <exception cref="InvalidOperationException">Throws when a needed field is not initialized.</exception>
    protected static Dictionary<string, Texture2D> s_GetTextures(AssetSection section)
    {
        var assets = new Dictionary<string, Texture2D>();
        foreach (var (assetName, assetPath) in AssetPaths[section])
        {
            if (_contentManager == null)
            {
                throw new InvalidOperationException("Content manager not initialized.");
            }
            else if (_currentSectionProgress == null)
            {
                throw new InvalidOperationException("Current section progress not initialized.");
            }
            try
            {
                var asset = _contentManager.Load<Texture2D>(assetPath);
                assets.Add(assetName, asset);
            }
            catch (FileNotFoundException fnfe)
            {
                Debug.WriteLine($"File {assetName} not found at '{assetPath}': {fnfe.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading file {assetName}: {ex.Message}");
            }
            finally
            {
                s_NotifyProgress(section);
                _currentSectionProgress[section]++;
                _progress++;
            }
        }
        return assets;
    }

    /// <summary> 
    /// Loads fonts from the Fonts section. 
    /// </summary>
    /// <param name="section">The symbol "section" is a variable of type "AssetSection" within the "AssetDictionary" class in the "HarvestHollow.Utilities" namespace.</param>
    /// <returns>Returns a Dictionary with the name of the assets as keys and their file paths as values.</returns>
    /// <exception cref="InvalidOperationException">Throws when a needed field is not initialized.</exception>
    protected static Dictionary<string, SpriteFont> s_GetFonts()
    {
        var assets = new Dictionary<string, SpriteFont>();
        foreach (var (assetName, assetPath) in AssetPaths[AssetSection.Fonts])
        {
            if (_contentManager == null)
            {
                throw new InvalidOperationException("Content manager not initialized.");
            }
            else if (_currentSectionProgress == null)
            {
                throw new InvalidOperationException("Current section progress not initialized.");
            }
            try
            {
                var asset = _contentManager.Load<SpriteFont>(assetPath);
                assets.Add(assetName, asset);
            }
            catch (FileNotFoundException fnfe)
            {
                Debug.WriteLine($"File {assetName} not found at '{assetPath}': {fnfe.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading file {assetName}: {ex.Message}");
            }
            finally
            {
                s_NotifyProgress(AssetSection.Fonts);
                _currentSectionProgress[AssetSection.Fonts]++;
                _progress++;
            }
        }
        return assets;
    }

    /// <summary> 
    /// Distributes asset sections evenly across available threads. 
    /// </summary>
    /// <param name="coreCount">The number of available CPU cores for asset loading.</param>
    /// <returns>Returns a Dictionary with the name of the AssetSection as keys and the thread number assigned to load them.</returns>
    protected static Dictionary<AssetSection, int> s_GetThreadDistribution(int coreCount)
    {
        if (_totalAssetsPerSection == null)
        {
            throw new InvalidOperationException("Total assets per section not initialized.");
        }

        Debug.WriteLine($"\nDistributing asset sections across {coreCount} cores:\n");

        var unsortedAssetSections = new (AssetSection, int)[Enum.GetNames(typeof(AssetSection)).Length];
        var sortIndex = 0;
        foreach (var section in AssetPaths.Keys)
        {
            unsortedAssetSections[sortIndex] = (section, _totalAssetsPerSection[section]);
            sortIndex++;
        }

        var sortedAssetSections = unsortedAssetSections.OrderByDescending(item => item.Item2).ToArray();
        var sectionGroup = new Dictionary<AssetSection, int>();
        var targetSize = (int)Math.Ceiling((double)(_totalAssets / coreCount));
        var sortedArrays = new bool[sortedAssetSections.Length];

        // Assign sections to threads based on target size.
        for (var thread = 0; thread < coreCount; thread++)
        {
            for (var checkSection = 0; checkSection < sortedAssetSections.Length; checkSection++)
            {
                var threadSize = 0;
                if (!sortedArrays[checkSection])
                {
                    threadSize += sortedAssetSections[checkSection].Item2;
                    sectionGroup.Add(sortedAssetSections[checkSection].Item1, thread);
                    sortedArrays[checkSection] = true;

                    // Add remaining unsorted sections to this thread, if possible.
                    for (var section = 0; section < sortedAssetSections.Length; section++)
                    {
                        if (!sortedArrays[section] && threadSize + sortedAssetSections[section].Item2 <= targetSize)
                        {
                            threadSize += sortedAssetSections[section].Item2;
                            sectionGroup.Add(sortedAssetSections[section].Item1, thread);
                            sortedArrays[section] = true;
                        }
                    }
                    break;
                }
            }
        }

        // DEBUG: Output thread load sizes.
        var threadSizes = new int[coreCount];
        for (var section = 0; section < sortedAssetSections.Length; section++)
        {
            threadSizes[sectionGroup[sortedAssetSections[section].Item1]] += sortedAssetSections[section].Item2;
        }

        while (sortedArrays.Contains(false))
        {
            Array.Sort(threadSizes);
            for (var section = 0; section < sortedAssetSections.Length; section++)
            {
                if (!sortedArrays[section])
                {
                    sectionGroup.Add(sortedAssetSections[section].Item1, 0);
                    threadSizes[section] += sortedAssetSections[section].Item2;
                    sortedArrays[section] = true;
                    break;
                }
            }
        }

        // DEBUG: Log final thread assignments.
        if (ProjectSettings.Developer)
        {
            for (var section = 0; section < sortedAssetSections.Length; section++)
            {
                Debug.WriteLine($"Core {section} contains {threadSizes[section]} assets;");
            }
        }

        return sectionGroup;
    }

    // Progress bar variables.
    private static float _progressBar;
    private static string? _progressBarText;
    protected static float ProgressBar => _progressBar;
    protected static string? ProgressBarText => _progressBarText;

    /// <summary> 
    /// Updates progress bar and logs detailed loading progress. 
    /// </summary>
    /// <param name="section">The symbol "section" is a variable of type "AssetSection" within the "AssetDictionary" class in the "HarvestHollow.Utilities" namespace.</param>
    private static void s_NotifyProgress(AssetSection section)
    {
        if (_currentSectionProgress == null)
        {
            throw new InvalidOperationException("Current section progress not initialized.");
        }
        else if (_totalAssetsPerSection == null)
        {
            throw new InvalidOperationException("Total assets per section not initialized.");
        }
        _progressBar = _progress / _totalAssets;
        _progressBarText = $"Loaded {_progress} / {_totalAssets} total assets.";

        // DEBUG: Detailed output of loading progress.
        if (!ProjectSettings.Developer || !ProjectSettings.DetailedOutput)
        {
            return;
        }

        Debug.WriteLine(
            $"Loaded asset '{AssetPaths[section][_currentSectionProgress[section]]}'; " +
            $"Section progress: {_currentSectionProgress[section]} / {_totalAssetsPerSection[section]};"
        );
    }
}