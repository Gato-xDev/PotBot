using Rocket.API;
using SDG.Framework.Devkit;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GatoZ.PotBot
{
    public class PotBotConfiguration : IRocketPluginConfiguration
    {
        public List<string> players { get; set; }
        public float damageMulti {  get; set; }
        public bool damageMultiActive { get; set; }
        public float damageResistance { get; set; }
        public bool damageResistanceActive { get; set; }
        public byte onHitHeal { get; set; }
        public bool onHitHealActive { get; set; }

        public void LoadDefaults()
        {
            damageResistance = 0.2F;
            damageResistanceActive = true;
            damageMulti = 1.2F;
            damageMultiActive = true;
            onHitHeal = (byte)1;
            onHitHealActive = true;
            players = new List<string>
            {
                "76561198970181914",
                "76561198143971531"
            };
        }
    }
}
