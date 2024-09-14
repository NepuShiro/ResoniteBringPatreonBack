using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using FrooxEngine.CommonAvatar;
using static HarmonyLib.Code;

namespace ResoniteBringPatreonBack
{
    public class ResoniteBringPatreonBack : ResoniteMod
    {
        internal const string VERSION_CONSTANT = "1.0.0";
        public override string Name => "ResoniteBringPatreonBack";
        public override string Author => "NepuShiro";
        public override string Version => VERSION_CONSTANT;
        public override string Link => "https://github.com/NepuShiro/ResoniteBringPatreonBack/";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("com.NepuShiro.ResoniteBringPatreonBack");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(AvatarManager), "AddModelBadge")]
        public class AvatarManagerPatch
        {
            public static bool Prefix(AvatarManager __instance, Uri uri, string name)
            {
                if (uri == Engine.Current.Cloud.Platform.GetInventoryItemUri("3D_Badges/Official/Supporter") && name == "Supporter")
                {
                    __instance.AddIconBadge(OfficialAssets.Graphics.Badges.Patreon, "Patreon Supporter", null, null, TextureFilterMode.Bilinear, 128);
                    return false;
                }
                return true;
            }
        }
    }
}
