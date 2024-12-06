using HarmonyLib;
using SurvivalExpanded.Modulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;

namespace SurvivalExpanded.Modules.ToolPower
{
    internal class SEToolPowerModSystem : ModSystem
    {

        public static Dictionary<float, string> newMiningTierNames = new Dictionary<float, string>()
        {
            { 0, "game:tier_hands" },
            { 1, "game:tier_stone" },
            { 1.5f, "survivalexpanded:tier_bone" }, 
            { 2, "game:tier_copper" },
            { 3, "survivalexpanded:tier_tinbronze" },
            { 3.25f, "survivalexpanded:tier_bismuthbronze" },
            { 3.5f, "survivalexpanded:tier_blackbronze" },
            { 4, "game:tier_iron" },
            { 5, "game:tier_steel" },
            { 6, "game:tier_titanium" }
        };

        public static string GetAppropriateMiningTier(float value)
        {
            foreach (KeyValuePair<float, string> pair in newMiningTierNames)
            {
                if (value <= pair.Key)
                {
                    return pair.Value;
                }
            }
            return "?";
        }

        Harmony patcher;

        public override void Start(ICoreAPI api)
        {
            if (!SEModulationModSystem.IsModuleEnabled(api, Code())) return;
            base.Start(api);
            api.RegisterCollectibleBehaviorClass("se-CustomMiningTier", typeof(SEBehaviorCustomMiningTier));
            
            //Do patches.
            patcher = new Harmony("SEToolPowerPatches");
            if (patcher.GetPatchedMethods().Count() == 0)
            {
                patcher.PatchCategory("SEToolPowerPatches");
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (patcher != null)
            {
                patcher.UnpatchAll(Code());
            }
        }

        public static string Code()
        {
            return SEModuleCodes.ToolPower.Code();
        }
    }
}
