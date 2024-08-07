using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace SurvivalExpanded.Config
{
    public class SEConfigLoader
    {

        private static Dictionary<string, SEConfig> loadedConfigs = null;

        public static T GetOrLoadConfig<T>(ICoreAPI api, string path) where T : SEConfig, new()
        {
            if (loadedConfigs == null) loadedConfigs = new Dictionary<string, SEConfig>();

            if (loadedConfigs.ContainsKey(path)) return loadedConfigs[path] as T;
            loadedConfigs.Add(path, LoadConfig<T>(api, path));
            return loadedConfigs[path] as T;
        }

        private static SEConfig LoadConfig<T>(ICoreAPI api, string path) where T : new()
        {
            T config;
            try
            {
                config = api.LoadModConfig<T>(path);
                if (config == null)
                {
                    config = new T();
                }
                api.StoreModConfig<T>(config, path);
            }
            catch
            {
                //Couldn't load the mod config... Create a new one with default settings, but don't save it.
                api.Logger.Error("[Survival Expanded] Failed to load Survival Expanded "+path+" config. Loading default settings instead.");
                config = new T();
            }

            //Two validation points:
            // - Check the config can be used on this side.
            // - Check the config is a valid type.
            if (config is SEConfig seconfig)
            {
                if (!seconfig.EnsureSide(api.Side))
                {
                    throw new ArgumentException("[Survival Expanded] The config provided should not be being loaded on this side! This will cause unpredictable behavior.");
                }
                return seconfig;
            }
            else
            {
                throw new ArgumentException("[Survival Expanded] The config provided does not extend from SEConfig.");
            }
        }
    }
}
