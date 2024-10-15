using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Steamworks;

namespace HarvestHollow.Systems

{
    public class SteamworksIntegration
    {
        protected Callback<GameOverlayActivated_t> _gameOverlayActivated;
        private void onEnable()
        {
            _gameOverlayActivated = Callback<GameOverlayActivated_t>.Create(s_onGameOverlayActivated);
        }
        private static void s_onGameOverlayActivated(GameOverlayActivated_t pCallback)
        {
            if (pCallback.m_bActive != 0)
            {
                Console.WriteLine("Steam Overlay has been activated");
            }
            else
            {
                Console.WriteLine("Steam Overlay has been closed");
            }
        }
        public void Initialize()
        {
            if (SteamAPI.RestartAppIfNecessary(AppId_t.Invalid))
            {
                Environment.Exit(1);
            }

            if (!SteamAPI.Init())
            {
                Console.WriteLine("Steamworks failed to initialize.");
            }
        }

        public void Update()
        {
            SteamAPI.RunCallbacks();
        }

        public void Shutdown()
        {
            SteamAPI.Shutdown();
        }
    }
}