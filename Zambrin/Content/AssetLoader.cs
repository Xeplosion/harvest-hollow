using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Zambrin.Content
{
    internal abstract class AssetLoader : AssetDictionary
    {
        private static ContentManager _contentManager;
        protected AssetLoader(ContentManager contentManager) 
        {
            // Initialize content manager for loading assets.
            _contentManager = contentManager;
            InitializeAssetCounts();
            SoundEffect.Initialize(); // Needed to make multi-threaded asset loading function.
        }

        // Variables to keep track of asset loading progress.
        private static Dictionary<AssetSection, int> _totalAssetsPerSection;
        private static Dictionary<AssetSection, int> _currentSectionProgress;
        private static int _totalAssets;
        private static float _progress;
        protected static void InitializeAssetCounts()
        {
            // Computes the total number of assets. 
            _totalAssetsPerSection = new Dictionary<AssetSection, int>();
            _currentSectionProgress = new Dictionary<AssetSection, int>();
            foreach (AssetSection section in AssetPaths.Keys)
            {
                _totalAssetsPerSection[section] = AssetPaths[section].Count;
                _totalAssets += AssetPaths[section].Count;
                _currentSectionProgress[section] = 0;
            }
        }
        // Asset loading functions separated by return types.
        protected static Dictionary<string, SoundEffect> GetSoundEffects(AssetSection section)
        {
            Dictionary<string, SoundEffect> assets = new Dictionary<string, SoundEffect>();
            foreach (var (assetName, assetPath) in AssetPaths[section])
            {
                try
                {
                    // Attempt to load asset.
                    SoundEffect asset = _contentManager.Load<SoundEffect>(assetPath);
                    assets.Add(assetName, asset);

                    // TODO: add code for debug output.
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
                    NotifyProgress(section);
                    _currentSectionProgress[section]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }
        protected static Dictionary<string, Song> GetSongs (AssetSection section)
        {
            Dictionary<string, Song> assets = new Dictionary<string, Song>();
            foreach (var (assetName, assetPath) in AssetPaths[section])
            {
                try
                {
                    // Attempt to load asset.
                    Song asset = _contentManager.Load<Song>(assetPath);
                    assets.Add(assetName, asset);

                    // TODO: add code for debug output.
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
                    NotifyProgress(section);
                    _currentSectionProgress[section]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }
        protected static Dictionary<string, Texture2D> GetTextures(AssetSection section)
        {
            Dictionary<string, Texture2D> assets = new Dictionary<string, Texture2D>();
            foreach (var (assetName, assetPath) in AssetPaths[section])
            {
                try
                {
                    // Attempt to load asset.
                    Texture2D asset = _contentManager.Load<Texture2D>(assetPath);
                    assets.Add(assetName, asset);

                    // TODO: add code for debug output.
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
                    NotifyProgress(section);
                    _currentSectionProgress[section]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }
        
        // TODO: add level loading.
        protected static Dictionary<string, SpriteFont> GetFonts()
        {
            Dictionary<string, SpriteFont> assets = new Dictionary<string, SpriteFont>();
            foreach (var (assetName, assetPath) in AssetPaths[AssetSection.Fonts])
            {
                try
                {
                    // Attempt to load asset.
                    SpriteFont asset = _contentManager.Load<SpriteFont>(assetPath);
                    assets.Add(assetName, asset);

                    // TODO: add code for debug output.
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
                    NotifyProgress(AssetSection.Fonts);
                    _currentSectionProgress[AssetSection.Fonts]++;
                    _progress++;
                }
            }
            // Return the Dictionary of assets.
            return assets;
        }

        // Finds the optimal thread distribution for loading assets.
        protected static Dictionary<AssetSection, int> GetThreadDistribution(int coreCount)
        {
            // DEBUG MESSAGES:
            Debug.WriteLine($"\nSORTING THREADS INTO {coreCount} AVAILABLE CORES:\n");

            // First we create an array with all AssetSection sizes.
            (AssetSection, int)[] unsortedAssetSection = new (AssetSection, int)[Enum.GetNames(typeof(AssetSection)).Length];
            int sortIndex = 0;
            foreach (AssetSection section in AssetPaths.Keys)
            {
                unsortedAssetSection[sortIndex] = (section, _totalAssetsPerSection[section]);
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
        private static float _progressBar;
        private static string _progressBarText;
        protected static float ProgressBar { get { return _progressBar; } }
        protected static string ProgressBarText { get { return _progressBarText; } }
        private static void NotifyProgress(AssetSection section)
        {
            // Update main progress bar
            _progressBar = _progress / _totalAssets;
            _progressBarText = $"Loaded {_progress} / {_totalAssets} total assets.";

            // DEBUG MESSAGES:
            if (!ProjectSettings.DEVELOPER) { return;  }
            Debug.WriteLine(
                $"Loaded asset '{AssetPaths[section][_currentSectionProgress[section]]}'; " +
                $"Current section progress {_currentSectionProgress[section]} / {_totalAssetsPerSection[section]};"
            );
        }
    }
}
