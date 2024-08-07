using SurvivalExpanded.Modulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;

namespace SurvivalExpanded.Config
{
    public class SEModulesConfig : SEConfig
    {
        public override bool EnsureSide(EnumAppSide side)
        {
            return side != EnumAppSide.Client;
        }

        public bool EnableToolPowerModule = true;
        public bool EnableBetterKnappingModule = true;
        public bool EnableClayBreakingModule = true;
        public bool EnableEntityEffectsModule = true;
        public bool EnableHiddenNutritionModule = true;
        public bool EnableMiscModule = true;
        public bool EnablePlayerNeedsModule = true;
        public bool EnableEnhancedNutritionModule = true;
        public bool EnableSurvivalProgressionModule = true;

        /// <summary>
        /// Copies the modules config into the world config. This allows them to easily be sent to clients immediately on joining.
        /// </summary>
        /// <param name="config"></param>
        public void CopyToWorldProperties(ITreeAttribute config)
        {
            config.SetBool(SEModuleCodes.ToolPower.Code(), EnableToolPowerModule);
            config.SetBool(SEModuleCodes.BetterKnapping.Code(), EnableBetterKnappingModule);
            config.SetBool(SEModuleCodes.ClayBreaking.Code(), EnableClayBreakingModule);
            config.SetBool(SEModuleCodes.EntityEffects.Code(), EnableEntityEffectsModule);
            config.SetBool(SEModuleCodes.HiddenNutrition.Code(), EnableHiddenNutritionModule);
            config.SetBool(SEModuleCodes.Misc.Code(), EnableMiscModule);
            config.SetBool(SEModuleCodes.PlayerNeeds.Code(), EnablePlayerNeedsModule);
            config.SetBool(SEModuleCodes.EnhancedNutrition.Code(), EnableEnhancedNutritionModule);
            config.SetBool(SEModuleCodes.SurvivalProgression.Code(), EnableSurvivalProgressionModule);
        }
    }
}
