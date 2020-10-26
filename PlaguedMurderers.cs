using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("Plagued Murderers", "DarkAz", "1.0.2")]
    [Description("Spawn murderers with customised clothing skin permutations")]
    class PlaguedMurderers : RustPlugin
    {

        #region Configuration

        private static Configuration _config;

        private class Configuration
        {
            [JsonProperty(PropertyName = "Glowing Eyes")]
            public bool GlowingEyes = true;

            [JsonProperty(PropertyName = "Randomly Use Headwrap")]
            public bool RandomHeadwrap = true;

            [JsonProperty(PropertyName = "Wear Headwrap")]
            public bool WearHeadwrap = true;

            [JsonProperty(PropertyName = "Wear Tshirt")]
            public bool WearTshirt = true;

            [JsonProperty(PropertyName = "Wear Gloves")]
            public bool WearGloves = true;

            [JsonProperty(PropertyName = "Wear Trousers")]
            public bool WearTrousers = true;

            [JsonProperty(PropertyName = "Wear Boots")]
            public bool WearBoots = true;

            [JsonProperty(PropertyName = "Headwrap Skins", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<ulong> HeadwrapSkins = new List<ulong>() { 84948907, 1076584212, 811534810 };

            [JsonProperty(PropertyName = "Tshirt Skins", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<ulong> TshirtSkins = new List<ulong>() { 811616832, 1572147878, 1120538508 };

            [JsonProperty(PropertyName = "Glove Skins", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<ulong> GloveSkins = new List<ulong>() { 971740441, 1475175531 };

            [JsonProperty(PropertyName = "Trouser Skins", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<ulong> TrouserSkins = new List<ulong>() { 1177788927, 823281717, 855123887 };

            [JsonProperty(PropertyName = "Boot Skins", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<ulong> BootSkins = new List<ulong>() { 1427198029, 1428936568, 1291665415 };

        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                _config = Config.ReadObject<Configuration>();
                if (_config == null) throw new Exception();
                SaveConfig();
            }
            catch
            {
                PrintError("Your configuration file contains an error. Using default configuration values.");
                LoadDefaultConfig();
            }
        }

        private void Unload()
        {
            _config = null;
        }

        protected override void SaveConfig() => Config.WriteObject(_config);

        protected override void LoadDefaultConfig() => _config = new Configuration();

        #endregion

        #region Hooks

        void OnEntitySpawned(NPCMurderer murderer)
        {       
            var inv_wear = murderer.inventory.containerWear;

            int headwrapRandom = Core.Random.Range(0, 3);

            Item burlap_headwrap = ItemManager.CreateByName("burlap.headwrap", 1, GetSkinId(_config.HeadwrapSkins));
            Item gloweyes = ItemManager.CreateByName("gloweyes");
            Item tshirt = ItemManager.CreateByName("tshirt", 1, GetSkinId(_config.TshirtSkins));
            Item burlap_gloves = ItemManager.CreateByName("burlap.gloves", 1, GetSkinId(_config.GloveSkins));
            Item burlap_trousers = ItemManager.CreateByName("burlap.trousers", 1, GetSkinId(_config.TrouserSkins));
            Item boots = ItemManager.CreateByName("shoes.boots", 1, GetSkinId(_config.BootSkins));

            inv_wear.Clear();
            if (_config.GlowingEyes) gloweyes.MoveToContainer(inv_wear);
            if (tshirt != null && _config.WearTshirt == true) tshirt.MoveToContainer(inv_wear);
            if (burlap_gloves != null && _config.WearGloves == true) burlap_gloves.MoveToContainer(inv_wear);
            if (burlap_trousers != null && _config.WearTrousers == true) burlap_trousers.MoveToContainer(inv_wear);
            if (boots != null && _config.WearBoots == true) boots.MoveToContainer(inv_wear);
            if(_config.RandomHeadwrap == false || headwrapRandom > 0) {
              if (burlap_headwrap != null && _config.WearHeadwrap == true) burlap_headwrap.MoveToContainer(inv_wear);
            }
        }

        #endregion

        #region Helpers

        private ulong GetSkinId(List<ulong> Skins) {

          int index = Core.Random.Range(0, Skins.Count - 1);
          ulong skinId = (ulong) Skins[index];
          return skinId;
        }

        #endregion

    }
}
