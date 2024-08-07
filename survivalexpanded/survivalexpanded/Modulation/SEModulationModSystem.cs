using System;
using SurvivalExpanded.Config;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using Vintagestory.Server;

namespace SurvivalExpanded.Modulation
{
    /// <summary>
    /// The modulation mod system is used to decide which modules should be loaded.
    /// Server 
    /// - Loads the config and decides what modules should be enabled.
    /// - Uploads this to the world config.
    /// Client
    /// - Retrieves the modules from the world config.
    /// 
    /// Due to this being in the world config, we can also use this to enable certain patches.
    /// </summary>
    internal class SEModulationModSystem : ModSystem
    {
        /// <summary>
        /// It is extremely important that this runs before any other mod system.
        /// </summary>
        public override double ExecuteOrder()
        {
            return -1;
        }

        /// <summary>
        /// We want to determine the modules as early as possible.
        /// </summary>
        /// <param name="api"></param>
        public override void StartPre(ICoreAPI api)
        {
            //This config is entirely server side.
            if (api.Side == EnumAppSide.Server)
            {
                SEConfigLoader.GetOrLoadConfig<SEModulesConfig>(api, ConfigPaths.ENABLED_MODULES)
                    .CopyToWorldProperties(api.World.Config);
                api.Logger.Event("[Survival Expanded] SE Modules Config loaded and analaysed");
            }
            base.StartPre(api);
        }

        /// <summary>
        /// Checks the world config to see if a module is enabled.
        /// This will work on the server or client.
        /// </summary>
        public static bool IsModuleEnabled(ICoreAPI api, string moduleCode)
        {
            //There should never be any instance where moduleCode doesn't exist; Throw an error if it's not in the world config.
            if (!api.World.Config.HasAttribute(moduleCode))
            {
                throw new ArgumentException("This module code does not exist in the world config.");
            }
            return api.World.Config.GetAsBool(moduleCode);
        }

    }
}
