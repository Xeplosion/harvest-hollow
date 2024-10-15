using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using HarvestHollow.LevelEditor.Utilities;
using HarvestHollow.LevelEditor.ViewModels.MenuCommands;

namespace HarvestHollow.LevelEditor.ViewModels;

public class MenuControlViewModel : ViewModel
{
    //  File commands.
    public ICommand NewWorldCommand { get; }
    public ICommand NewLevelCommand { get; }
    public ICommand NewTilesetCommand { get; }
    public ICommand OpenLevelOrWorldCommand { get; }
    public ICommand OpenLevelInWorldCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand SaveAsCommand { get; }
    public ICommand SaveAllCommand { get; }
    public ICommand ExportCommand { get; }
    public ICommand ExportAsCommand { get; }
    public ICommand ExportAsImageCommand { get; }
    public ICommand ReloadCommand { get; }
    public ICommand EditCommandsCommand { get; }
    public ICommand RunCommandsCommand { get; }
    public ICommand CloseCommand { get; }
    public ICommand CloseAllCommand { get; }
    public ICommand CloseWorldCommand { get; }
    public ICommand QuitCommand { get; }

    // Edit commands.
    public ICommand UndoCommand { get; }
    public ICommand RedoCommand { get; }
    public ICommand CutCommand { get; }
    public ICommand CopyCommand { get; }
    public ICommand PasteCommand { get; }
    public ICommand PasteInPlaceCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand SelectAllCommand { get; }
    public ICommand InvertSelectionCommand { get; }
    public ICommand SelectNoneCommand { get; }
    public ICommand PreferencesCommand { get; }

    // View Commands.
    public bool IsProjectViewVisible { get; set; }
    public bool IsWorldViewVisible { get; set; }
    public bool IsLevelViewVisible { get; set; }
    public bool IsTilesetViewVisible { get; set; }
    public bool IsEntitiesViewVisible { get; set; }
    public bool IsEnumerationsViewVisible { get; set; }
    public bool IsLayerViewVisible { get; set; }
    public bool IsConsoleViewVisible { get; set; }
    public bool IsIssuesViewVisible { get; set; }
    public bool EnableGridView { get; set; }
    public bool EnableTileCoordinates { get; set; }
    public bool EnableEntitiesView { get; set; }
    public bool EnableTileAnimations { get; set; }
    public bool EnableTileCollisions { get; set; }
    public bool HighlightCurrentLayer { get; set; }
    public ICommand EnableProjectViewVisibleCommand { get; }
    public ICommand EnableWorldViewVisibleCommand { get; }
    public ICommand EnableLevelViewVisibleCommand { get; }
    public ICommand EnableTilesetViewVisibleCommand { get; }
    public ICommand EnableEntitiesViewVisibleCommand { get; }
    public ICommand EnableEnumerationsViewVisibleCommand { get; }
    public ICommand EnableLayerViewVisibleCommand { get; }
    public ICommand EnableConsoleViewVisibleCommand { get; }
    public ICommand EnableIssuesViewVisibleCommand { get; }
    public ICommand SearchActionsCommand { get; }
    public ICommand EnableGridViewCommand { get; }
    public ICommand EnableTileCoordinatesCommand { get; }
    public ICommand EnableEntitiesViewCommand { get; }
    public ICommand EnableTileAnimationsCommand { get; }
    public ICommand EnableTileCollisionsCommand { get; }
    public ICommand HighlightCurrentLayerViewCommand { get; }
    public ICommand ZoomInCommand { get; }
    public ICommand ZoomOutCommand { get; }
    public ICommand ResetZoomCommand { get; }
    public ICommand ZoomToFitCommand { get; }
    public ICommand FullscreenCommand { get; }
    public ICommand ClearViewCommand { get; }

    // Project menu.
    public ICommand AddWorldCommand { get; }
    public ICommand RefreshProjectCommand { get; }
    public ICommand EditWorldPropertiesCommand { get; }

    // Help menu.
    public ICommand OpenDocumentationCommand { get; }
    public ICommand OpenAboutCommand { get; }

    public MenuControlViewModel()
    {
        // File commands.
        NewWorldCommand = new RelayCommand(executeNewWorld);
        NewLevelCommand = new RelayCommand(executeNewLevel);
        NewTilesetCommand = new RelayCommand(executeNewTileset);
        OpenLevelOrWorldCommand = new RelayCommand(executeOpenLevelOrWorld);
        OpenLevelInWorldCommand = new RelayCommand(executeOpenLevelInWorld);
        SaveCommand = new RelayCommand(executeSave);
        SaveAsCommand = new RelayCommand(executeSaveAs);
        SaveAllCommand = new RelayCommand(executeSaveAll);
        ExportCommand = new RelayCommand(executeExport);
        ExportAsCommand = new RelayCommand(executeExportAs);
        ExportAsImageCommand = new RelayCommand(executeExportAsImage);
        ReloadCommand = new RelayCommand(executeReload);
        EditCommandsCommand = new RelayCommand(executeEditCommands);
        RunCommandsCommand = new RelayCommand(executeRunCommands);
        CloseCommand = new RelayCommand(executeClose);
        CloseAllCommand = new RelayCommand(executeCloseAll);
        CloseWorldCommand = new RelayCommand(executeCloseWorld);
        QuitCommand = new QuitApplication();

        // Edit commands.
        UndoCommand = new RelayCommand(executeUndo);
        RedoCommand = new RelayCommand(executeRedo);
        CutCommand = new RelayCommand(executeCut);
        CopyCommand = new RelayCommand(executeCopy);
        PasteCommand = new RelayCommand(executePaste);
        PasteInPlaceCommand = new RelayCommand(executePasteInPlace);
        DeleteCommand = new RelayCommand(executeDelete);
        SelectAllCommand = new RelayCommand(executeSelectAll);
        InvertSelectionCommand = new RelayCommand(executeInvertSelection);
        SelectNoneCommand = new RelayCommand(executeSelectNone);
        PreferencesCommand = new RelayCommand(executePreferences);

        // View commands.
        IsProjectViewVisible = true;
        IsWorldViewVisible = true;
        IsLevelViewVisible = true;
        IsTilesetViewVisible = true;
        IsEntitiesViewVisible = true;
        IsEnumerationsViewVisible = true;
        IsLayerViewVisible = true;
        IsConsoleViewVisible = true;
        IsIssuesViewVisible = true;
        EnableGridView = true;
        EnableTileCoordinates = true;
        EnableEntitiesView = true;
        EnableTileAnimations = true;
        EnableTileCollisions = true;
        HighlightCurrentLayer = true;
        EnableProjectViewVisibleCommand = new RelayCommand(executeEnableProjectViewVisible);
        EnableWorldViewVisibleCommand = new RelayCommand(executeEnableWorldViewVisible);
        EnableLevelViewVisibleCommand = new RelayCommand(executeEnableLevelViewVisible);
        EnableTilesetViewVisibleCommand = new RelayCommand(executeEnableTilesetViewVisible);
        EnableEntitiesViewVisibleCommand = new RelayCommand(executeEnableEntitiesViewVisible);
        EnableEnumerationsViewVisibleCommand = new RelayCommand(executeEnableEnumerationsViewVisible);
        EnableLayerViewVisibleCommand = new RelayCommand(executeEnableLayerViewVisible);
        EnableConsoleViewVisibleCommand = new RelayCommand(executeEnableConsoleViewVisible);
        EnableIssuesViewVisibleCommand = new RelayCommand(executeEnableIssuesViewVisible);
        SearchActionsCommand = new RelayCommand(executeSearchActions);
        EnableGridViewCommand = new RelayCommand(executeEnableGridView);
        EnableTileCoordinatesCommand = new RelayCommand(executeEnableTileCoordinates);
        EnableEntitiesViewCommand = new RelayCommand(executeEnableEntitiesView);
        EnableTileAnimationsCommand = new RelayCommand(executeEnableTileAnimations);
        EnableTileCollisionsCommand = new RelayCommand(executeEnableTileCollisions);
        HighlightCurrentLayerViewCommand = new RelayCommand(executeHighlightCurrentLayerView);
        ZoomInCommand = new RelayCommand(executeZoomIn);
        ZoomOutCommand = new RelayCommand(executeZoomOut);
        ResetZoomCommand = new RelayCommand(executeResetZoom);
        ZoomToFitCommand = new RelayCommand(executeZoomToFit);
        FullscreenCommand = new RelayCommand(executeFullscreen);
        ClearViewCommand = new RelayCommand(executeClearView);

        // Project commands.
        AddWorldCommand = new RelayCommand(executeAddWorld);
        RefreshProjectCommand = new RelayCommand(executeRefreshProject);
        EditWorldPropertiesCommand = new RelayCommand(executeEditWorldProperties);

        // Help commands.
        OpenDocumentationCommand = new RelayCommand(executeOpenDocumentation);
        OpenAboutCommand = new RelayCommand(executeOpenAbout);
    }

    private void executeNewWorld() { /* Implementation */ }
    private void executeNewLevel() { /* Implementation */ }
    private void executeNewTileset() { /* Implementation */ }
    private void executeOpenLevelOrWorld() { /* Implementation */ }
    private void executeOpenLevelInWorld() { /* Implementation */ }
    private void executeSave() { /* Implementation */ }
    private void executeSaveAs() { /* Implementation */ }
    private void executeSaveAll() { /* Implementation */ }
    private void executeExport() { /* Implementation */ }
    private void executeExportAs() { /* Implementation */ }
    private void executeExportAsImage() { /* Implementation */ }
    private void executeReload() { /* Implementation */ }
    private void executeEditCommands() { /* Implementation */ }
    private void executeRunCommands() { /* Implementation */ }
    private void executeClose() { /* Implementation */ }
    private void executeCloseAll() { /* Implementation */ }
    private void executeCloseWorld() { /* Implementation */ }
    private void executeUndo() { /* Implementation */ }
    private void executeRedo() { /* Implementation */ }
    private void executeCut() { /* Implementation */ }
    private void executeCopy() { /* Implementation */ }
    private void executePaste() { /* Implementation */ }
    private void executePasteInPlace() { /* Implementation */ }
    private void executeDelete() { /* Implementation */ }
    private void executeSelectAll() { /* Implementation */ }
    private void executeInvertSelection() { /* Implementation */ }
    private void executeSelectNone() { /* Implementation */ }
    private void executePreferences() { /* Implementation */ }
    private void executeEnableProjectViewVisible() { /* Implementation */ }
    private void executeEnableWorldViewVisible() { /* Implementation */ }
    private void executeEnableLevelViewVisible() { /* Implementation */ }
    private void executeEnableTilesetViewVisible() { /* Implementation */ }
    private void executeEnableEntitiesViewVisible() { /* Implementation */ }
    private void executeEnableEnumerationsViewVisible() { /* Implementation */ }
    private void executeEnableLayerViewVisible() { /* Implementation */ }
    private void executeEnableConsoleViewVisible() { /* Implementation */ }
    private void executeEnableIssuesViewVisible() { /* Implementation */ }
    private void executeSearchActions() { /* Implementation */ }
    private void executeEnableGridView() { /* Implementation */ }
    private void executeEnableTileCoordinates() { /* Implementation */ }
    private void executeEnableEntitiesView() { /* Implementation */ }
    private void executeEnableTileAnimations() { /* Implementation */ }
    private void executeEnableTileCollisions() { /* Implementation */ }
    private void executeHighlightCurrentLayerView() { /* Implementation */ }
    private void executeZoomIn() { /* Implementation */ }
    private void executeZoomOut() { /* Implementation */ }
    private void executeResetZoom() { /* Implementation */ }
    private void executeZoomToFit() { /* Implementation */ }
    private void executeFullscreen() { /* Implementation */ }
    private void executeClearView() { /* Implementation */ }
    private void executeAddWorld() { /* Implementation */ }
    private void executeRefreshProject() { /* Implementation */ }
    private void executeEditWorldProperties() { /* Implementation */ }
    private void executeOpenDocumentation() { /* Implementation */ }
    private void executeOpenAbout() { /* Implementation */ }
}
