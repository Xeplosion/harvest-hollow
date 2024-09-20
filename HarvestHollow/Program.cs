using System;

namespace HarvestHollow
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using HarvestHollow game = new HarvestHollow();
            game.Run();
        }
    }
}


