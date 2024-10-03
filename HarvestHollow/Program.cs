using System;

namespace HarvestHollow;

public static class Program
{
    [STAThread]
    private static void Main()
    {
        using GameCore.HarvestHollow game = new();
        game.Run();
    }
}