using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("Plagued Murderers", "DarkAz", "2.4.1")]
    [Description("Allows murderers and scarecrows to be customised with health, attire, skins and melee weapons.")]
    class PlaguedMurderers : RustPlugin
    {

        #region Configuration

        private static Configuration _config;

        private class Configuration
        {
            // begin general config
            [JsonProperty(PropertyName = "Use Kits", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public bool useKits = false;

            // end general config
            // begin murderers config
            [JsonProperty(PropertyName = "Glowing Eyes")]
            public bool GlowingEyes = true;

            [JsonProperty(PropertyName = "Murderer Health", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public int murdererHealth = 100;

            [JsonProperty(PropertyName = "Attire Headwear", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> Headwear = new List<string>() { "bucket.helmet", "burlap.headwrap", "none" };

            [JsonProperty(PropertyName = "Attire Torso", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> Torso = new List<string>() { "tshirt", "jacket", "tshirt.long", "none" };

            [JsonProperty(PropertyName = "Attire Legs", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> Legs = new List<string>() { "burlap.trousers", "pants.shorts" };

            [JsonProperty(PropertyName = "Attire Feet", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> Feet = new List<string>() { "shoes.boots", "none" };

            [JsonProperty(PropertyName = "Attire Hands", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> Hands = new List<string>() { "burlap.gloves", "none" };

            [JsonProperty(PropertyName = "Skins")]
            public Dictionary<string, List<ulong>> Skins = new Dictionary<string, List<ulong>>() {
                ["bucket.helmet"] = new List<ulong>() { 747281863, 816503044, 818863931 },
                ["burlap.headwrap"] = new List<ulong>() { 84948907, 1076584212, 811534810 },
                ["tshirt"] = new List<ulong>() { 811616832, 1572147878, 1120538508 },
                ["tshirt.long"] = new List<ulong>() { 1161735516, 1537333543, 810504871 },
                ["burlap.trousers"] = new List<ulong>() { 1177788927, 823281717, 855123887 },
                ["pants.shorts"] = new List<ulong>() { 885479497, 841150520, 793362671 },
                ["shoes.boots"] = new List<ulong>() { 1427198029, 1428936568, 1291665415 },
                ["burlap.gloves"] = new List<ulong>() { 971740441, 1475175531 },
            };

            [JsonProperty(PropertyName = "Melee Weapon", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> MeleeWeapon = new List<string>() { "hatchet", "knife.bone", "knife.butcher", "knife.combat", "longsword", "machete", "paddle", "salvaged.cleaver", "salvaged.sword" };

            [JsonProperty(PropertyName = "Murderer Kits", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> MurdererKits = new List<string>() { "murderer-kit1", "murderer-kit2" };

            // end murderers config
            // begin scarecrows config

            [JsonProperty(PropertyName = "Glowing Eyes (Scarecrow)")]
            public bool GlowingScarecrowEyes = true;

            [JsonProperty(PropertyName = "Scarecrow Health", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public int scarecrowHealth = 500;

            [JsonProperty(PropertyName = "Attire Headwear (Scarecrow)", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowHeadwear = new List<string>() { };

            [JsonProperty(PropertyName = "Attire Torso (Scarecrow)", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowTorso = new List<string>() { "scarecrow.suit" };

            [JsonProperty(PropertyName = "Attire Legs (Scarecrow)", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowLegs = new List<string>() { };

            [JsonProperty(PropertyName = "Attire Feet (Scarecrow)", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowFeet = new List<string>() { };

            [JsonProperty(PropertyName = "Attire Hands (Scarecrow)", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowHands = new List<string>() { };

            [JsonProperty(PropertyName = "Melee Weapon (Scarecrow)", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowMeleeWeapon = new List<string>() { };

            [JsonProperty(PropertyName = "Scarecrow Kits", ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<string> ScarecrowKits = new List<string>() { "scarecrow-kit1", "scarecrow-kit2" };

            // end scarecrows config

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
            var combatEntity = murderer as BaseCombatEntity;
            combatEntity._maxHealth = _config.murdererHealth;
            combatEntity.health = _config.murdererHealth;

            if(_config.useKits)
            {
                GiveKitMurderer(murderer, GetKitName(_config.MurdererKits));
            } else {
                ClotheMurderer(murderer);
            }

        }


        void OnEntitySpawned(HTNPlayer scarecrow)
        {
            
            var combatEntity = scarecrow as BaseCombatEntity;
            if(combatEntity.ShortPrefabName != "scarecrow") {
                return;
            }
            combatEntity._maxHealth = _config.scarecrowHealth;
            combatEntity.health = _config.scarecrowHealth;

            if(_config.useKits)
            {
                GiveKitScarecrow(scarecrow, GetKitName(_config.ScarecrowKits));
            } else {
                ClotheScarecrow(scarecrow);
            }

        }

        #endregion

        #region Helpers

        private ulong GetSkinId(List<ulong> Skins) {
          int index = Core.Random.Range(0, Skins.Count - 1);
          ulong skinId = (ulong) Skins[index];
          return skinId;
        }

        private string GetKitName(List<string> Kits) {
          if(Kits.Count < 1){
              Puts("Error in config - Kits not defined or empty");
              return null;
          }
          int index = Core.Random.Range(0, Kits.Count);
          string kit = (string) Kits[index];
          return kit;
        }

        private Item GetItem(List<string> ClothingItems) {
          if(ClothingItems.Count < 1){
              return null;
          }
          int index = Core.Random.Range(0, ClothingItems.Count - 1);
          if(ClothingItems[index] == "none") {
              return null;
          }

          var chosenItem = ClothingItems[index];

          List<ulong> skinList;
          Item SelectedItem;

          bool skinsDefined = _config.Skins.TryGetValue(chosenItem, out skinList);

          if(skinsDefined && skinList.Count > 0) {
              SelectedItem = ItemManager.CreateByName(chosenItem, 1, GetSkinId(skinList));
          } else {
              SelectedItem = ItemManager.CreateByName(chosenItem, 1);
          }

          return SelectedItem;
        }

        void ClotheMurderer(NPCMurderer murderer)
        {

            var inv_wear = murderer.inventory.containerWear;
            var inv_belt = murderer.inventory.containerBelt;

            Item gloweyes = ItemManager.CreateByName("gloweyes");

            Item itemHeadwear = GetItem(_config.Headwear);
            Item itemTorso = GetItem(_config.Torso);
            Item itemLegs = GetItem(_config.Legs);
            Item itemFeet = GetItem(_config.Feet);
            Item itemHands = GetItem(_config.Hands);

            inv_wear.Clear();
            if(_config.GlowingEyes) gloweyes.MoveToContainer(inv_wear);
            if(itemHeadwear != null) itemHeadwear.MoveToContainer(inv_wear);
            if(itemTorso != null) itemTorso.MoveToContainer(inv_wear);
            if(itemLegs != null) itemLegs.MoveToContainer(inv_wear);
            if(itemFeet != null) itemFeet.MoveToContainer(inv_wear);
            if(itemHands != null) itemHands.MoveToContainer(inv_wear);

            Item itemMelee = GetItem(_config.MeleeWeapon);

            if(itemMelee != null)
            {
                inv_belt.Clear();
                itemMelee.MoveToContainer(inv_belt);
            }

        }

        void ClotheScarecrow(HTNPlayer scarecrow)
        {

            var inv_wear = scarecrow.inventory.containerWear;
            var inv_belt = scarecrow.inventory.containerBelt;

            Item gloweyes = ItemManager.CreateByName("gloweyes");

            Item itemHeadwear = GetItem(_config.ScarecrowHeadwear);
            Item itemTorso = GetItem(_config.ScarecrowTorso);
            Item itemLegs = GetItem(_config.ScarecrowLegs);
            Item itemFeet = GetItem(_config.ScarecrowFeet);
            Item itemHands = GetItem(_config.ScarecrowHands);

            inv_wear.Clear();
            if(_config.GlowingScarecrowEyes) gloweyes.MoveToContainer(inv_wear);
            if(itemHeadwear != null) itemHeadwear.MoveToContainer(inv_wear);
            if(itemTorso != null) itemTorso.MoveToContainer(inv_wear);
            if(itemLegs != null) itemLegs.MoveToContainer(inv_wear);
            if(itemFeet != null) itemFeet.MoveToContainer(inv_wear);
            if(itemHands != null) itemHands.MoveToContainer(inv_wear);

            Item itemMelee = GetItem(_config.ScarecrowMeleeWeapon);

            if(itemMelee != null)
            {
                inv_belt.Clear();
                itemMelee.MoveToContainer(inv_belt);
            }

        }

        private static void GiveKitMurderer(NPCMurderer npc, string kit)
        {
            if (kit == null)
                return;

            Interface.Oxide.CallHook("GiveKit", npc, kit);

            Item item = npc.inventory.containerBelt.GetSlot(0);
            
            if (item == null)
            {
                return;
            }
            
            npc.UpdateActiveItem(item.uid);
        }

        private static void GiveKitScarecrow(HTNPlayer npc, string kit)
        {
            if (kit == null)
                return;

            Interface.Oxide.CallHook("GiveKit", npc, kit);

            Item item = npc.inventory.containerBelt.GetSlot(0);
            
            if (item == null)
            {
                return;
            }
            
            npc.UpdateActiveItem(item.uid);
        }

        #endregion

    }
}
