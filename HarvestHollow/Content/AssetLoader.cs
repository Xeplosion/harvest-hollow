using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace HarvestHollow.Content
{
    internal abstract class AssetLoader : AssetDictionary
    {
        private static ContentManager _s_contentManager { get; set; }
        protected AssetLoader(ContentManager contentManager) 
        {
            // Initialize content manager for loading assets.
            _s_contentManager = contentManager;
            s_InitializeAssetCounts();
            SoundEffect.Initialize(); // Needed to make multi-threaded asset loading function.
        }
        // Variables to keep track of asset loading progress.
        private static Dictionary<AssetSection, int> _s_TotalAssetsPerSection;
        private static Dictionary<AssetSection, int> _s_CurrentSectionProgress;
        private static int _totalAssets;
        private static float _progress;
        protected static void s_InitializeAssetCounts()
        {
            // Computes the total number of assets. 
            _s_TotalAssetsPerSection = new Dictionary<AssetSection, int>();
            _s_CurrentSectionProgress = new Dictionary<AssetSection, int>();
            foreach (AssetSection section in AssetPaths.Keys)
            {
                _s_TotalAssetsPerSection[section] = AssetPaths[section].Count;
                _totalAssets += AssetPaths[section].Count;
                _s_CurrentSectionProgress[section] = 0;
            }
        }
        // Asset loading functions separated by return types.
        protected static Dictionary<string, SoundEffect> s_GetSoundEffects(AssetSection section)
        {
            Dictionary<string, SoundEffect> assets = new Dictionary<string, SoundEffect>();
            foreach (var (assetName, assetPath) in AssetPaths[section])
            {
                try
                {
                    // Attempt to load asset.
                    SoundEffect asset = _s_contentManager.Load<SoundEffect>(assetPath);
                    assets.Add(assetName, asset);
                }
                catch (FileNotFoundException fnfe)
                {
                    // Handles incorrect path exceptions.
                    Debug.WriteLine($"The file {assetName} could not be found at '{assetPath}': {fnfe.Message}");
                }
                catch (Exception ex)
                {
                    // Handles all other exceptions
                    Debug.WriteLine($"Error attempting to load file {assetName}: {ex.Message}");
                }
                finally
                {
                    //Increment section progress.
                    s_NotifyProgress(section);
                    _s_CurrentSectionProgress[section]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }
        protected static Dictionary<string, Song> s_GetSongs (AssetSection section)
        {
            Dictionary<string, Song> assets = new Dictionary<string, Song>();
            foreach (var (assetName, assetPath) in AssetPaths[section])
            {
                try
                {
                    // Attempt to load asset.
                    Song asset = _s_contentManager.Load<Song>(assetPath);
                    assets.Add(assetName, asset);
                }
                catch (FileNotFoundException fnfe)
                {
                    // Handles incorrect path exceptions.
                    Debug.WriteLine($"The file {assetName} could not be found at '{assetPath}': {fnfe.Message}");
                }
                catch (Exception ex)
                {
                    // Handles all other exceptions
                    Debug.WriteLine($"Error attempting to load file {assetName}: {ex.Message}");
                }
                finally
                {
                    //Increment section progress.
                    s_NotifyProgress(section);
                    _s_CurrentSectionProgress[section]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }
        protected static Dictionary<string, Texture2D> s_GetTextures(AssetSection section)
        {
            Dictionary<string, Texture2D> assets = new Dictionary<string, Texture2D>();
            foreach (var (assetName, assetPath) in AssetPaths[section])
            {
                try
                {
                    // Attempt to load asset.
                    Texture2D asset = _s_contentManager.Load<Texture2D>(assetPath);
                    assets.Add(assetName, asset);
                }
                catch (FileNotFoundException fnfe)
                {
                    // Handles incorrect path exceptions.
                    Debug.WriteLine($"The file {assetName} could not be found at '{assetPath}': {fnfe.Message}");
                }
                catch (Exception ex)
                {
                    // Handles all other exceptions
                    Debug.WriteLine($"Error attempting to load file {assetName}: {ex.Message}");
                }
                finally
                {
                    //Increment section progress.
                    s_NotifyProgress(section);
                    _s_CurrentSectionProgress[section]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }
        
        // TODO: add level loading.
        protected static Dictionary<string, SpriteFont> s_GetFonts()
        {
            Dictionary<string, SpriteFont> assets = new Dictionary<string, SpriteFont>();
            foreach (var (assetName, assetPath) in AssetPaths[AssetSection.Fonts])
            {
                try
                {
                    // Attempt to load asset.
                    SpriteFont asset = _s_contentManager.Load<SpriteFont>(assetPath);
                    assets.Add(assetName, asset);
                }
                catch (FileNotFoundException fnfe)
                {
                    // Handles incorrect path exceptions.
                    Debug.WriteLine($"The file {assetName} could not be found at '{assetPath}': {fnfe.Message}");
                }
                catch (Exception ex)
                {
                    // Handles all other exceptions
                    Debug.WriteLine($"Error attempting to load file {assetName}: {ex.Message}");
                }
                finally
                {
                    //Increment section progress.
                    s_NotifyProgress(AssetSection.Fonts);
                    _s_CurrentSectionProgress[AssetSection.Fonts]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }

        // Finds the optimal thread distribution for loading assets.
        protected static Dictionary<AssetSection, int> s_GetThreadDistribution(int coreCount)
        {
            // DEBUG MESSAGES:
            Debug.WriteLine($"\nSORTING THREADS INTO {coreCount} AVAILABLE CORES:\n");

            // First we create an array with all AssetSection sizes.
            (AssetSection, int)[] unsortedAssetSection = new (AssetSection, int)[Enum.GetNames(typeof(AssetSection)).Length];
            int sortIndex = 0;
            foreach (AssetSection section in AssetPaths.Keys)
            {
                unsortedAssetSection[sortIndex] = (section, _s_TotalAssetsPerSection[section]);
                sortIndex++;
            }

            // Next we sort that array and use it to assign asset loaders a thread.
            (AssetSection, int)[] sortedAssetSection = unsortedAssetSection.OrderByDescending(item => item.Item2).ToArray();
            Dictionary<AssetSection, int> sectionGroup = new Dictionary<AssetSection, int>(); // Return array. Couldn't think of a better name :0
            int targetSize = (int)Math.Ceiling((double)(_totalAssets / coreCount));
            bool[] sortedArrays = new bool[sortedAssetSection.Length];
            for (int thread = 0; thread < coreCount; thread++)
            {
                for (int checkSection = 0; checkSection < sortedAssetSection.Length; checkSection++)
                {
                    // First we check to see if the current section has already been sorted.
                    int threadSize = 0;
                    if (!sortedArrays[checkSection]) {
                        threadSize += sortedAssetSection[checkSection].Item2;
                        sectionGroup.Add(sortedAssetSection[checkSection].Item1, thread);
                        sortedArrays[checkSection] = true;
                        for (int section = 0; section < sortedAssetSection.Length; section++)
                        {
                            // Then we check if another unsorted section can add to the thread keeping it under the tagetSize
                            if (!sortedArrays[section] && (threadSize + sortedAssetSection[section].Item2) <= targetSize)
                            {
                                threadSize += sortedAssetSection[section].Item2;
                                sectionGroup.Add(sortedAssetSection[section].Item1, thread);
                                sortedArrays[section] = true;
                            }
                        }
                        break;
                    }
                }

            }

            // Calculate the existing thread load sizes.
            int[] threadSizes = new int[coreCount];
            for (int section = 0; section < sortedAssetSection.Length; section++)
            {
                threadSizes[sectionGroup[sortedAssetSection[section].Item1]] += sortedAssetSection[section].Item2;
            }

            // Next we assign the largest remaining group to the thread with the smallest load.
            while (sortedArrays.Contains(false))
            {
                Array.Sort(threadSizes);
                for (int section = 0; section < sortedAssetSection.Length; section++)
                {
                    if (!sortedArrays[section])
                    {
                        sectionGroup.Add(sortedAssetSection[section].Item1, 0);
                        threadSizes[section] += sortedAssetSection[section].Item2;
                        sortedArrays[section] = true;
                        break;
                    }
                }
            }

            // DEBUG MESSAGES:
            if (ProjectSettings.DEVELOPER)
            {
                for (int section = 0; section < sortedAssetSection.Length; section++)
                {
                    Debug.WriteLine($"Successfully sorted core {section} containing {threadSizes[section]} assets;");
                }
            }
            
            // Then we return the (hopefully) evenly distributed asset sections :)
            return sectionGroup;
        }

        // Updates the loading progress bar.
        private static float _s_progressBar;
        private static string _s_progressBarText;
        protected static float ProgressBar { get { return _s_progressBar; } }
        protected static string ProgressBarText { get { return _s_progressBarText; } }
        private static void s_NotifyProgress(AssetSection section)
        {
            // Update main progress bar
            _s_progressBar = _progress / _totalAssets;
            _s_progressBarText = $"Loaded {_progress} / {_totalAssets} total assets.";

            // DEBUG MESSAGES:
            if (!ProjectSettings.DEVELOPER) { return;  }
            Debug.WriteLine(
                $"Loaded asset '{AssetPaths[section][_s_CurrentSectionProgress[section]]}'; " +
                $"Current section progress {_s_CurrentSectionProgress[section]} / {_s_TotalAssetsPerSection[section]};"
            );
        }
    }
}
