using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace SurvivalExpanded.Modules.ToolPower
{
    public static class SEToolPowerExtensions
    {

        public static float GetCustomMiningTier(this CollectibleObject collectible)
        {
            if (collectible == null) return 0;
            SEBehaviorCustomMiningTier tier = collectible.GetBehavior<SEBehaviorCustomMiningTier>();
            if (tier == null)
            {
                if (collectible is Block b)
                {
                    return b.RequiredMiningTier;
                }
                return collectible.ToolTier;
            }
            return tier.customMiningTier;
        }
    }
}
