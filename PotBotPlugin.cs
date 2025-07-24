using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Framework.Devkit;
using SDG.Unturned;
using Steamworks;
using System;
using System.Linq;
using static Rocket.Unturned.Events.UnturnedEvents;
using static SDG.Unturned.PlayerLife;

namespace GatoZ.PotBot
{
    public class PotBotPlugin : RocketPlugin<PotBotConfiguration>
    {   
        public static PotBotPlugin Instance { get; private set; }

        protected override void Load()
        {
            Logger.Log($"{Name} {Assembly.GetName().Version.ToString(3)} has been loaded!");

            DamageTool.damagePlayerRequested += OnPlayerDamaged;

        }
        protected override void Unload()
        {
            Logger.Log($"{Name} has been unloaded!");
            DamageTool.damagePlayerRequested -= OnPlayerDamaged;
        }



        private void OnPlayerDamaged(ref DamagePlayerParameters parameters, ref bool shouldAllow)
        {
            if (!parameters.killer.m_SteamID.ToString().StartsWith("765")) { return; }
            if (Configuration.Instance.players.Count == 0){ return; }

            var playas = Configuration.Instance.players;
            Player player = parameters.player;
            CSteamID killer = parameters.killer;
            UnturnedPlayer unp = UnturnedPlayer.FromPlayer(player);
            if (playas.Contains(unp.Id) || playas.Contains(killer.ToString()))
            {
                if (Configuration.Instance.damageResistanceActive)
                {
                    if (playas.Contains(unp.Id))
                    {
                        float multi_base = 1;
                        float deRes = Configuration.Instance.damageResistance;
                        multi_base -= deRes;
                        parameters.damage *= multi_base;
                    }
                }
                if (Configuration.Instance.damageMultiActive)
                {
                    if (playas.Contains(killer.m_SteamID.ToString()))
                    {
                        float dmgM = Configuration.Instance.damageMulti;
                        parameters.damage *= dmgM;
                    }
                }
                if (Configuration.Instance.onHitHealActive)
                {
                    if (playas.Contains(unp.Id))
                    {
                        byte healFactor = Configuration.Instance.onHitHeal;
                        unp.Heal(healFactor, false, false); // heal XYZ amt on damaged
                    }
                }
            }


            /*
            if (Configuration.Instance.damageResistanceActive)
            {
                
            }



            playerids players = Configuration.Instance.players;

            if (!killer.m_SteamID.ToString().StartsWith("765")) { return; } // zombies

            if (killer.m_SteamID.ToString().Contains("76561198970181914")) 
            {
                parameters.damage *= (float)1.2;
            } //gato extra damage

          

            
            if (unp.CSteamID.ToString().Contains("76561198970181914"))
            {
                // parameters.damage *= (float)0.7;
                unp.Heal(1, false, false); // heal XYZ amt on damaged
            }
            */
        }
    }
}