using System;
using System.Text;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;

namespace SurvivalExpanded.Modules.ToolPower
{
    public class SEBehaviorCustomMiningTier : CollectibleBehavior
    {
        public float customMiningTier;

        public SEBehaviorCustomMiningTier(CollectibleObject collObj) : base(collObj)
        {
        }

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            //Get default values.
            float def = collObj.ToolTier;
            if (collObj is Block b)
            {
                def = b.RequiredMiningTier;
            }
            if (collObj == null || collObj.Attributes == null) customMiningTier = def;
            else customMiningTier = collObj.Attributes["se-CustomMiningTier"].AsFloat(def);
            if (customMiningTier == 0) customMiningTier = def;
        }

        public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            dsc.Replace(Lang.Get("Tool Tier: {0}", collObj.ToolTier), Lang.Get("Tool Tier: {0}", customMiningTier));
            base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);
        }
    }
}
