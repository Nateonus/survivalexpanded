using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;

namespace SurvivalExpanded.Modules.ToolPower
{
    [HarmonyPatchCategory("SEToolPowerPatches")]
    public static class SEToolPowerPatches
    {

        [HarmonyPrefix()]
        [HarmonyPatch(typeof(CollectibleObject), "OnBlockBreaking")]
        public static bool PreOnBlockBreaking(CollectibleObject __instance, ref float __result, BlockSelection blockSel, float remainingResistance)
        {
            if (__instance.GetCustomMiningTier() < blockSel.Block.GetCustomMiningTier())
            {
                __result = remainingResistance;
                return false;
            }
            return true;
        }

        [HarmonyPrefix()]
        [HarmonyPatch(typeof(Block), "AddMiningTierInfo")]
        public static bool AddMiningTierInfo(Block __instance, StringBuilder sb) 
        {
            float requiredTier = __instance.GetCustomMiningTier();
            string text = SEToolPowerModSystem.GetAppropriateMiningTier(requiredTier);

            sb.AppendLine(Lang.Get("Requires tool tier {0} ({1}) to break", requiredTier, (text == "?") ? text : Lang.Get(text)));
            return false;
        }

    }
}
