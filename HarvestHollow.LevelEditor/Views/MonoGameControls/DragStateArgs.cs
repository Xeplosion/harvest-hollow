﻿using System.Windows;
using Microsoft.Xna.Framework;

namespace HarvestHollow.LevelEditor.Views.MonoGameControls;

public class DragStateArgs
{
    private readonly IInputElement _element;
    private readonly DragEventArgs _args;

    public DragStateArgs(IInputElement element, DragEventArgs args)
    {
        _element = element;
        _args = args;
    }

    public Vector2 Position => _args.GetPosition(_element).s_ToVector2();
    public T? GetData<T>() where T : class => _args?.Data?.GetData(typeof(T)) as T;
}