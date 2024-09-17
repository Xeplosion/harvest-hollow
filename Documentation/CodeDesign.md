# *Harvest Hollow* Code Design

## About

The purpose of this document is to provide a comprehensive guide to the codebase of *Harvest Hollow*. It serves as both a reference for how existing code functions and a roadmap for future development. This document outlines coding conventions, structural patterns, and best practices to ensure consistency and maintainability across the entire project.

In addition to covering general principles like naming conventions and file organization, it also contains detailed explanations on how to use specific tools such as the level editor, ensuring that all contributors have a clear understanding of the workflow. Whether you're reviewing current systems or developing new features, this document provides the necessary guidance to write code that integrates seamlessly into the larger project. It will evolve alongside the game, growing as new systems are introduced and existing ones are refined.

## Table of Contents

[Tech Stack](#tech-stack)
[Asset Loading](#asset-loader)
[Level Editor](#level-editor)
[Character AI](#character-ai)

## Tech Stack

Harvest Hollow is built using a combination of modern and robust technologies tailored for 2D game development, ensuring high performance and ease of development. The core technologies driving the game are MonoGame and the XNA framework.

    [MonoGame](https://docs.monogame.net/): MonoGame is a versatile and open-source framework designed for creating cross-platform games. It serves as the backbone of *Harvest Hollow*, providing the flexibility to deploy the game across various platforms including Windows, macOS, Linux, and potentially consoles and mobile devices. Its strong support for 2D graphics, audio, and input handling makes it an ideal choice for the game's pixel-art aesthetic and retro feel. MonoGame is also highly performant, enabling smooth gameplay and quick iteration during development.

    [XNA Framework](https://docs.monogame.net/api/Microsoft.Xna.Framework.html): Originally developed by Microsoft, the XNA framework is a set of tools and runtime libraries that MonoGame builds upon. While XNA itself is no longer supported by Microsoft, its simplicity and efficiency in game development have made it a foundational technology. The framework simplifies many aspects of game development, from content management to rendering, and serves as the model for MonoGame's API. By using XNA through MonoGame, *Harvest Hollow* benefits from the reliability and familiarity of XNA while still utilizing modern development tools.

This tech stack ensures that *Harvest Hollow* remains accessible for future updates, supports rapid prototyping, and offers solid performance across a range of devices. The combination of MonoGame and XNA allows the team to focus more on game design and mechanics, while relying on a proven, stable development environment.

## Asset Loader

The asset loader is created using a hierarchical inheritnace structure. The code for loading assets is split into three different files:

1. [`AssetPaths.cs`](../HarvestHollow/Content/AssetPaths.cs) is a data structure that maps asset names (keys) to their corresponding file paths (values):

        ```csharp 
        Dictionary<AssetSection, List<(string, string)>> AssetPaths = new Dictionary<AssetSection, List<(string, string)>>
        ```

When the game needs to load an asset, it will refer to the dictionary using the asset's name. For example:

        ```csharp
        string _playerSpritePath = AssetPaths[AssetSection.SpriteSheets]["playerSprite32x32"];
        Texture2D _playerTexture = content.Load<Texture2D>(_playerSpritePath);
        ```

2. [`AssetLoader.cs`](../HarvestHollow/Content/AssetLoader.cs)  efficiently manages the loading of game assets by distributing different asset sections across available CPU cores, significantly decreasing loading times. By taking advantage of multi-core processors, the loader can handle multiple asset types (such as textures, audio files, and level data) in parallel, ensuring that resources are loaded as quickly as possible.

        ```csharp
        // First we create an array with all AssetSection sizes.
        (AssetSection, int)[] unsortedAssetSection = new (AssetSection, int)[Enum.GetNames(typeof(AssetSection)).Length];
        int sortIndex = 0;
        foreach (AssetSection section in AssetPaths.Keys)
        {
            unsortedAssetSection[sortIndex] = (section, _totalAssetsPerSection[section]);
            sortIndex++;
        }

        // Next we sort that array and use it to assign asset loaders a thread.
        (AssetSection, int)[] sortedAssetSection = unsortedAssetSection.OrderByDescending(item =>   item.Item2).ToArray();
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
        ```

It also contains the code for loading individual assets section using the MonoGame content pipeline. The asset loader also handles writing debug information helping to diagnos issues related to missing files, corrupted data, and  other loading issues.
3. [`Assets.cs`](../HarvestHollow/Content/Assets.cs) is what actually creates the threads used to load the assets sorted by the asset loader.

        ```csharp
        _sortedThreads = GetThreadDistribution(_loaderThreads.Length);
        for (int thread = 0; thread < _loaderThreads.Length; thread++) {
            _loaderThreads[thread] = new Thread(LoadThreadAssets);
            _loaderThreads[thread].Name = $"AssetLoader{thread}";
            _loaderThreads[thread].Start(thread);
        }
        ```

The loaded assets can be accessed anywhwere in the HarvestHollow namespace like so:

        ```csharp
        player Texture2D = Assest["playerSprite32x32"]
        ```
Meaning that if you know the name of an asset, you can access the proccessed file in a single line of code.

## Level Editor

The level editor used in Harvest Hollow was inspired by the free level editor [LDtk](https://ldtk.io/docs/) (Level Designer Toolkit). LDtk provided a solid foundation for creating and managing levels; however, it presented a limitation that necessitated the development of a custom level editor to meet the specific needs of the project.

LDtk allows for the creation of levels using various layers and grids. However, it has a limitation where only one IntGrid layer can influence the rules when selecting tiles to paint. This constraint restricted the flexibility required for our game’s level design, where multiple IntGrid layers needed to interact with tile selection rules simultaneously.

These are the main benifits the custom level editor has ovet LDtk:

1. An advanced rule system that provides more granular control over tile placement based on multiple IntGrid layers. This flexibility allows for more dynamic and intricate level design.
2. The editor's interface has been tailored to facilitate easy manipulation of multiple grid layers and rules. It includes intuitive tools for defining and managing tile rules and visual feedback to assist designers in creating and testing levels.
3. The custom level editor seamlessly integrates with the Harvest Hollow game engine, ensuring that levels designed with the editor are fully compatible and functional within the game environment.

## Character AI
